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
}

