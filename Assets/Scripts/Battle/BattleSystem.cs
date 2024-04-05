using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {
    Start,
    PlayerAction,
    PlayerMove,
    EnemyMove,
    Busy

}
public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit  playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] EnemyBattleHud enemyHud;
    [SerializeField] BattleDialogueBox dialogueBox;

    public event Action<bool> BattleOver;
    BattleState state;
    int currentAction; // 0th index = fight, 1st index = run from dialoguebox game obj
    int currentMove; // similar algoirhtm to currentAction


    public void StartBattle()
    {
        StartCoroutine(SetupBattle());

    }

    public IEnumerator SetupBattle(){
        //create player pokemon
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetDataEnemy(enemyUnit.Pokemon);
        
        dialogueBox.SetMovenames(playerUnit.Pokemon.Moves);
        yield return dialogueBox.TypeDialogue($"A wild {enemyUnit.Pokemon.PkmTemplate.GetPkmName()} appeared!");

        PlayerAction();
    }

    void PlayerAction(){
        //changing states
        state = BattleState.PlayerAction;
        StartCoroutine(dialogueBox.TypeDialogue($"What will {playerUnit.Pokemon.PkmTemplate.GetPkmName()} do?"));
        // enable action selector
        dialogueBox.EnableActionSelector(true);
    }

    void PlayerMove(){
        state = BattleState.PlayerMove;
        //disable action selector
        dialogueBox.EnableActionSelector(false);
        dialogueBox.EnableDialogueText(false);
        dialogueBox.EnableMoveSelector(true);
    } 

    IEnumerator PerformPlayerMove(){
        //pokemon will perform the move, enemy take damage
        //get ref of move selected by player
        state = BattleState.Busy;
        var move = playerUnit.Pokemon.Moves[currentMove];
        yield return dialogueBox.TypeDialogue($"{playerUnit.Pokemon.PkmTemplate.GetPkmName()} used {move.Template.GetMoveName()}!");

        playerUnit.attackAnimation();
        yield return new WaitForSeconds(1f);
        //animate hit animation
        enemyUnit.hitAnimation();

        var damageDetails = enemyUnit.Pokemon.TakeDamage(move,playerUnit.Pokemon);
        yield return enemyHud.UpdateEnemyHp(); // remember i have two sepearte battlehuds 
        yield return ShowDamageDetails(damageDetails);

        if(damageDetails.Fainted){
            // show in dialog box
            yield return dialogueBox.TypeDialogue($"{enemyUnit.Pokemon.PkmTemplate.GetPkmName()} has fainted!");
            enemyUnit.faintAnimation();

            yield return new WaitForSeconds(2f);
            BattleOver(true);
        }
        else {
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMove(){
        state = BattleState.EnemyMove;
        var move = enemyUnit.Pokemon.GetRandomMove();
        yield return dialogueBox.TypeDialogue($"{enemyUnit.Pokemon.PkmTemplate.GetPkmName()} used {move.Template.GetMoveName()}!");

        enemyUnit.attackAnimation();
        yield return new WaitForSeconds(1f);

        playerUnit.hitAnimation();

        var damageDetails = playerUnit.Pokemon.TakeDamage(move,enemyUnit.Pokemon);
        yield return playerHud.UpdateHp();
        yield return ShowDamageDetails(damageDetails);
        if(damageDetails.Fainted){
            // show in dialog box
            yield return dialogueBox.TypeDialogue($"{playerUnit.Pokemon.PkmTemplate.GetPkmName()} has fainted!");
            playerUnit.faintAnimation();

            yield return new WaitForSeconds(2f);
            BattleOver(false);
        }
        else {
            PlayerAction();
        }
    
    }

    IEnumerator ShowDamageDetails(DamageDetails damageDetails){
        if(damageDetails.Critical >1f ){
            yield return dialogueBox.TypeDialogue("A critical hit!");
        }

        if(damageDetails.TypeEffective > 1f){
            yield return dialogueBox.TypeDialogue("It is super effective!");
        }
        else if (damageDetails.TypeEffective < 1f){
            yield return dialogueBox.TypeDialogue("It is not very effective!");
        }
    }

    public void HandleUpdate(){
        if( state == BattleState.PlayerAction){
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove){
            HandleMoveSelection();
        }
    }

    public void HandleActionSelection(){
        if( Input.GetKeyDown(KeyCode.DownArrow)){
            if(currentAction < 1){
                currentAction++;
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow)){
            if(currentAction > 0){
                currentAction--;
            }
        }
        dialogueBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.Z)){
             if(currentAction == 0){
                // clicking this will activate fight, activate moveselector state
                PlayerMove();
             } 
             else if ( currentAction == 1){
                // clicking this will activate Run
             }
        }

    }

    public void HandleMoveSelection(){
        if( Input.GetKeyDown(KeyCode.RightArrow)){
            //since pokemon moves is not a finite number but a number between 1-4
            if(currentMove < playerUnit.Pokemon.Moves.Count -1){
                currentMove++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            if(currentMove > 0){
                currentMove--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)){
            if(currentMove < playerUnit.Pokemon.Moves.Count -2){
                currentMove += 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)){
            if(currentMove > 1){
                currentMove -= 2;
            }
        } 

        dialogueBox.UpdateMoveSelection(currentMove, playerUnit.Pokemon.Moves[currentMove]); 

        //z key is pressed , perform player move, have ot disable move selector and enable dialog text
        // when move is pressed
        if(Input.GetKeyDown(KeyCode.Z))  {
            dialogueBox.EnableMoveSelector(false); 
            dialogueBox.EnableDialogueText(true);
            StartCoroutine(PerformPlayerMove());
        }   

    }

}

