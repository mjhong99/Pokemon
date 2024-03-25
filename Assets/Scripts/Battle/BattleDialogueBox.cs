using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class BattleDialogueBox : MonoBehaviour
{
    [SerializeField] int letterPerSecond;
    [SerializeField] Color highlightedColor;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<TextMeshProUGUI> actionTexts;
    [SerializeField] List<TextMeshProUGUI> moveTexts;

    [SerializeField] TextMeshProUGUI ppText;
    [SerializeField] TextMeshProUGUI typeText;

    public void SetDialogue(string dialogue){
        dialogueText.text = dialogue;
    }

    //animate the dialogue text so letters appear one by one
    public IEnumerator TypeDialogue(string dialogue){
        dialogueText.text = "";
        foreach (var letter in dialogue.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f/letterPerSecond); // show 30 letters in 1 second?
        }
        
    }

    public void EnableDialogueText(bool enabled){
        dialogueText.enabled = enabled;
    }

    public void EnableActionSelector(bool active){
        actionSelector.SetActive(active); 
    }

    public void EnableMoveSelector(bool active){
        moveSelector.SetActive(active);
        moveDetails.SetActive(active);
    }

    public void UpdateActionSelection(int selectedAction){
        for (int i = 0; i < actionTexts.Count; i++){
            if( i == selectedAction){
                //change color of text to desired color else set to black
                actionTexts[i].color = highlightedColor;
            }
            else {
                actionTexts[i].color = Color.black;
            }
        }
    }

    public void UpdateMoveSelection(int selectedMove, Move move){
        for (int i =0; i < moveTexts.Count; i++){
            if( i == selectedMove){
                //chagne color of text to desired color or set to black 
                moveTexts[i].color = highlightedColor;
            }
            else {
                moveTexts[i].color = Color.black;
            }
        }
        ppText.text = $"PP {move.PP}/{move.Template.GetPP()}";
        typeText.text = move.Template.Get_Type().ToString();
    }

    // this function set the moves name
    public void SetMovenames(List<Move> moves){
        for( int i =0; i< moveTexts.Count; i++){
            //edge case if less than 4 moves
            if( i < moves.Count){
                moveTexts[i].text = moves[i].Template.GetMoveName();
            }
            else {
                moveTexts[i].text = "-"; // move slot is empty
            }
        }
    }

}
