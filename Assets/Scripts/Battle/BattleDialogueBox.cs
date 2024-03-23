using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class BattleDialogueBox : MonoBehaviour
{
    [SerializeField] int letterPerSecond;
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
}
