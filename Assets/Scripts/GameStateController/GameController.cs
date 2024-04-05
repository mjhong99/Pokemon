using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Battle};

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerControl playerController;
    [SerializeField] BattleSystem battleSystem; 
    [SerializeField] Camera worldCamera;
    GameState state;

    private void Start(){
        playerController.OnEncounter += StartBattle;
        battleSystem.BattleOver += EndBattle;
    }

    public void StartBattle(){
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        //disable main camera
        worldCamera.gameObject.SetActive(false);
        //start battle
        battleSystem.StartBattle();

    }

    public void EndBattle(bool win){
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        //enable world camera
        worldCamera.gameObject.SetActive(true);
    }

    // this controls game states through state design pattern 
    // game contorller is passed to either the player or battle system depending on state
    private void Update(){
        if (state == GameState.FreeRoam){
            playerController.HandleUpdate();
        }
        else if (state == GameState.Battle){
            battleSystem.HandleUpdate();
        }
    }
}
