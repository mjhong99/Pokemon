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
   Pokemon pkm;

    // might fix 
   public void SetData(Pokemon pokemon){
      pkm = pokemon;
      nameText.text = pokemon.PkmTemplate.GetPkmName();
      levelText.text = "" + pokemon.Level;
      hpBar.SetHP((float) pokemon.CurrHp / pokemon.Hp());// this line might be needed to be repeatd for enemyhpbar
   }

   public IEnumerator UpdateHp(){
      yield return hpBar.SetHpSmooth((float) pkm.CurrHp / pkm.Hp());
   }
   

}
