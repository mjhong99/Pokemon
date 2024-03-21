using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create new move") ]
public class MoveTemplate : ScriptableObject
{
    [SerializeField] string MoveName;
    [TextArea]

    [SerializeField] string description;
    [SerializeField] PokemonType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

//get helper functions

    public string GetMoveName(){
        return MoveName;
    }

    public string GetDescription(){
    return description;
    }

    public PokemonType Get_Type(){
        return type;
    }

    public int GetPower(){
        return power;
    }

    public int GetAccuracy(){
        return accuracy;
    }

    public int GetPP(){
        return pp;
    }
}
// move categories
public enum MoveCategory {
    Physical,
    Special,
    Status
}