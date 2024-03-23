using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit  playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] EnemyBattleHud enemyHud;
    [SerializeField] BattleDialogueBox dialogueBox;

    private void Start()
    {
        SetupBattle();

    }

    public void SetupBattle(){
        //create player pokemon
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetDataEnemy(enemyUnit.Pokemon);
        
        StartCoroutine(dialogueBox.TypeDialogue($"A wild {enemyUnit.Pokemon.PkmTemplate.GetPkmName()} appeared!"));
    }

}

