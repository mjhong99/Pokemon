using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyBattleHud : MonoBehaviour
{
    
   [SerializeField] TextMeshProUGUI nameText;
   [SerializeField] TextMeshProUGUI levelText;
   [SerializeField] EnemyHpBar enemyHpBar;
   Pokemon pkm;
   public void SetDataEnemy(Pokemon pokemon){
      pkm = pokemon;
      nameText.text = pokemon.PkmTemplate.GetPkmName();
      levelText.text = "" + pokemon.Level;
      enemyHpBar.SetEnemyHpBar((float) pokemon.CurrHp / pokemon.Hp());
   }

   public IEnumerator UpdateEnemyHp(){
      yield return enemyHpBar.SetEnemyHpSmooth((float) pkm.CurrHp / pkm.Hp());
   }
}
