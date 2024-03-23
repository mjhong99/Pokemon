using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonTemplate pkmtemplate;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;
    public Pokemon Pokemon {get; set;}

    //sets up Pokemon
    public void Setup(){
        // create Pokemon by calling constructor
        Pokemon = new Pokemon(pkmtemplate, level);
        if ( isPlayerUnit){ // if true
            GetComponent<Image>().sprite = Pokemon.PkmTemplate.GetBackSprite();
        }
        else {
            GetComponent<Image>().sprite = Pokemon.PkmTemplate.GetFrontSprite();
        }

    }

}
