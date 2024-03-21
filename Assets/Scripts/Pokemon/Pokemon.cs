using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon 
{
    PokemonTemplate pkmTemplate;
    int level;
    public int CurrHp {get; set; }
    
    //list for moves by getting class Move
    public List<Move> Moves { get; set; } // pokemon needs to learn all moves based on level

    //constructor assign them to variables above
    
    //might add .Reverse to list to get the 4 previous moves it learns, might modify the actual list consider it..
   public Pokemon( PokemonTemplate pkm, int pLevel){
       pkmTemplate = pkm; 
       level = pLevel;
       CurrHp = Hp();
       
       

       //generating moves
       Moves = new List<Move>();
       foreach (var move in pkmTemplate.GetLearnSet()){
            if(move.GetLearnLevel() <= level){
                Moves.Add(new Move(move.GetmoveTemplate())); // create class Move with constructor
            }

            //if have more than 4 moves, break
            if(Moves.Count >=4) {
                break;
            }
       }
   }

   //calculate total stats of pokemon based on level
    public int Hp(){
        int TotalHp = Mathf.FloorToInt((pkmTemplate.GetHp() * level) / 100f) + 10;
        return TotalHp;
    }

    public int Attack(){
        int TotalAtk = Mathf.FloorToInt((pkmTemplate.GetAtk() * level) / 100f) + 5;
        return TotalAtk;
    }

    public int Defense(){
        int TotalDef = Mathf.FloorToInt((pkmTemplate.GetDef() * level) / 100f) + 5;
        return TotalDef;
    }

    public int SpecialAttack(){
        int TotalSpAtk = Mathf.FloorToInt((pkmTemplate.GetSpAtk() * level) / 100f) + 5;
        return TotalSpAtk;
    }

    public int SpecialDefense(){
        int TotalSpDef = Mathf.FloorToInt((pkmTemplate.GetSpDef() * level) / 100f) + 5;
        return TotalSpDef;
    }
    
    public int Speed(){
        int TotalSpd = Mathf.FloorToInt((pkmTemplate.GetSpd() * level) / 100f) + 5;
        return TotalSpd;
    }
}

