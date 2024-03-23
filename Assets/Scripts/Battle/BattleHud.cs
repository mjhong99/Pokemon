using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
   
   [SerializeField] TextMeshProUGUI nameText;
   [SerializeField] TextMeshProUGUI levelText;
   [SerializeField] HpBar hpBar;
   

    // might fix 
   public void SetData(Pokemon pokemon){
        nameText.text = pokemon.PkmTemplate.GetPkmName();
        levelText.text = "" + pokemon.Level;
        hpBar.SetHP((float) pokemon.CurrHp / pokemon.Hp());
   }

 
}
