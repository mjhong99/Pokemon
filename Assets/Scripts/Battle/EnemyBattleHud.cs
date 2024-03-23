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
   public void SetDataEnemy(Pokemon pokemon){
        nameText.text = pokemon.PkmTemplate.GetPkmName();
        levelText.text = "" + pokemon.Level;
        enemyHpBar.SetEnemyHpBar((float) pokemon.CurrHp / pokemon.Hp());
   }
}
