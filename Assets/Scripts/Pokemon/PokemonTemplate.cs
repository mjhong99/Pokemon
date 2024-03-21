using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon",menuName = "Pokemon/Create new pokemon")]
public class PokemonTemplate : ScriptableObject
{

    // template of pokemon
    [SerializeField] string PkmName;
    [TextArea] 
    [SerializeField] string description;
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    // base stats

    [SerializeField] int Hp;
    [SerializeField] int Atk;
    [SerializeField] int Def;
    [SerializeField] int SpAtk;
    [SerializeField] int SpDef;
    [SerializeField] int Spd;
    
    //List of learnable moves
    [SerializeField] List<LearnableMove> LearnSet;


    // methods to get private variables

    public string GetPkmName(){
        return PkmName;
    }

    public string Getdescription(){
        return description;
    } 

    public Sprite GetFrontSprite(){
        return frontSprite;
    }

    public Sprite GetBackSprite(){
        return backSprite;
    }

    public PokemonType GetType1(){
        return type1;
    }    

    public PokemonType GetType2(){
        return type2;
    }

    public int GetHp(){
        return Hp;
    }

    public int GetAtk(){
        return Atk;
    }
    
    public int GetDef(){
        return Def;
    }

    public int GetSpAtk(){
        return SpAtk;
    }

    public int GetSpDef(){
        return SpDef;
    }

    public int GetSpd(){
        return Spd;
    }

    public List<LearnableMove> GetLearnSet(){
        return LearnSet;
    }

}

// Pokemon Learneset
[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveTemplate moveTemplate;
    [SerializeField] int LearnLevel;

    public MoveTemplate GetmoveTemplate(){
        return moveTemplate;
    }

    public int GetLearnLevel(){
        return LearnLevel;
    }

}
public enum PokemonType {
    Normal,
    Fire,
    Water,
    Grass,
    Electric,
    Ice,
    Fighting,
    Steel,
    Poison,
    Dragon,
    Rock,
    Ground,
    Ghost,
    Bug,
    Psychic,
    Flying,
    Dark,
    None


}