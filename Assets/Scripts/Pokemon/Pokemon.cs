using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pokemon 
{
    public PokemonTemplate PkmTemplate {get; set;} 
    public int Level {get; set;}
    public int CurrHp {get; set; }
    
    //list for moves by getting class Move
    public List<Move> Moves { get; set; } // pokemon needs to learn all moves based on Level

    //constructor assign them to variables above
    
    //might add .Reverse to list to get the 4 previous moves it learns, might modify the actual list consider it..
   public Pokemon( PokemonTemplate pkm, int pLevel){
       PkmTemplate = pkm; 
       Level = pLevel;
       CurrHp = Hp();
       
       

       //generating moves
       Moves = new List<Move>();
       foreach (var move in PkmTemplate.GetLearnSet()){
            if(move.GetLearnLevel() <= Level){
                Moves.Add(new Move(move.GetmoveTemplate())); // create class Move with constructor
            }

            //if have more than 4 moves, break
            if(Moves.Count >=4) {
                break;
            }
       }
   }

   //calculate total stats of pokemon based on Level
    public int Hp(){
        int TotalHp = Mathf.FloorToInt((PkmTemplate.GetHp() * Level) / 100f) + 10;
        return TotalHp;
    }

    public int Attack(){
        int TotalAtk = Mathf.FloorToInt((PkmTemplate.GetAtk() * Level) / 100f) + 5;
        return TotalAtk;
    }

    public int Defense(){
        int TotalDef = Mathf.FloorToInt((PkmTemplate.GetDef() * Level) / 100f) + 5;
        return TotalDef;
    }

    public int SpecialAttack(){
        int TotalSpAtk = Mathf.FloorToInt((PkmTemplate.GetSpAtk() * Level) / 100f) + 5;
        return TotalSpAtk;
    }

    public int SpecialDefense(){
        int TotalSpDef = Mathf.FloorToInt((PkmTemplate.GetSpDef() * Level) / 100f) + 5;
        return TotalSpDef;
    }
    
    public int Speed(){
        int TotalSpd = Mathf.FloorToInt((PkmTemplate.GetSpd() * Level) / 100f) + 5;
        return TotalSpd;
    }

    public DamageDetails TakeDamage(Move move, Pokemon attacker){

        float critical = 1f;
        if (UnityEngine.Random.value * 100f <= 6.25f){
            //calc critical hit
            critical = 2f;
        }

        float type = TypeChart.GetEffectiveness(move.Template.Get_Type(), this.PkmTemplate.GetType1()) * TypeChart.GetEffectiveness(move.Template.Get_Type(), this.PkmTemplate.GetType2());

        //using class DamageDetails to specify which message plays
        var damageDetails = new DamageDetails(){
             TypeEffective = type,
             Critical = critical,
             Fainted = false
        };

        //formula for taking dmg
        float modifiers = UnityEngine.Random.Range(0.85f, 1f) * type * critical;
        float a = (2 * attacker.Level + 10) / 250f;

        float d = a * move.Template.GetPower() * ((float)attacker.Attack() / Defense()) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        CurrHp -= damage;
        if(CurrHp <=0 ){
            //pokemon fainted
            CurrHp = 0;
            damageDetails.Fainted = true;
        }

        return damageDetails;
    }

    //function that chooses random move for enemy
    public Move GetRandomMove(){
        int r = UnityEngine.Random.Range(0,Moves.Count);
        return Moves[r];
    }
}

public class DamageDetails {

    public bool Fainted {get; set;}
    public float Critical {get; set;}
    public float TypeEffective {get; set;}

}