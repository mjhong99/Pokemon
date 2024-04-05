using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonTemplate pkmtemplate;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;
    public Pokemon Pokemon {get; set;}

    // cache image
    Image image;
    // store position of sprite to animate
    Vector3 originalPos; 
    // store original Color
    Color originalColor;

    private void Awake(){
        image = GetComponent<Image>();
        originalPos = image.transform.localPosition;
        originalColor = image.color;
    } 

    //sets up Pokemon
    public void Setup(){
        // create Pokemon by calling constructor
        Pokemon = new Pokemon(pkmtemplate, level);
        if ( isPlayerUnit){ // if true
            image.sprite = Pokemon.PkmTemplate.GetBackSprite();
        }
        else {
            image.sprite = Pokemon.PkmTemplate.GetFrontSprite();
        }
        image.color = originalColor;
        EnterBattleAnimation();

    }
    // moving image out of screen, adjust if needed
    public void EnterBattleAnimation(){
        if(isPlayerUnit){
            image.transform.localPosition = new Vector3(-500f,originalPos.y);
        }
        else {
            image.transform.localPosition = new Vector3(500f,originalPos.y);
        }
        image.transform.DOLocalMoveX(originalPos.x,1f);

    }

    //attack animation
    public void attackAnimation(){
        var sequence = DOTween.Sequence();
        if(isPlayerUnit){
            //move right
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x + 50f, 0.25f));
        }
        else {
            // move left
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x - 50f, 0.25f));
        }
        //original pos
        sequence.Append(image.transform.DOLocalMoveX(originalPos.x,0.25f));

    }

    public void hitAnimation(){
        var sequence = DOTween.Sequence();
        sequence.Append(image.DOColor(Color.gray, 0.1f));
        sequence.Append(image.DOColor(originalColor,0.1f));
    }

    public void faintAnimation(){
        var sequence = DOTween.Sequence(); 
        sequence.Append(image.transform.DOLocalMoveY(originalPos.y -150f,0.5f ));
        //fade image
        sequence.Join(image.DOFade(0f,0.5f));  

    }
}
