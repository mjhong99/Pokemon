using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] Image hpBar;
    [SerializeField] Color green = new Color((25f/255f),(192f/255f),(33f/255f));
    [SerializeField] Color yellow = new Color((230f/255f),(177f/255f),(73f/255f));
    [SerializeField] Color red = new Color((225f/255f),(79f/255f),(63f/255f));

    // may modify these function incase of making it independent and easier for reusability.
    // later, try to // Find the "HealthGreen" GameObject and get its Image component in separate func to encapsulate


    void Start()
    {
    // Find the "HealthGreen" GameObject and get its Image component
    GameObject healthGreenObject = GameObject.Find("HealthGreen");

    if (healthGreenObject != null)
    {
        hpBar = healthGreenObject.GetComponent<Image>();
        if (hpBar != null)
        {
            Debug.Log("Image component found and assigned successfully.");
        }
        else
        {
            Debug.LogWarning("Image component not found on HealthGreen GameObject.");
        }
    }
    else
    {
        Debug.LogWarning("HealthGreen GameObject not found.");
    }
    // call this for testing the hp bar color
    //SetHP(0.09f);
    }

    public void SetHP(float hpNormalized){

        hpBar.transform.localScale = new Vector3(hpNormalized, 1f);

        if (hpNormalized > 0.5f){
            SetBarColor(green);
        }
        else if (hpNormalized >0.1f){
            SetBarColor(yellow);
        }

        else {
            SetBarColor(red);
        }

    
    }

    private void SetBarColor(Color color){
        
        if (hpBar != null){
            hpBar.color = color;
        }
        else {
            Debug.LogWarning("Image Componenet not found in Hp bar");
        }
    }

    //animate HpBar
    public IEnumerator SetHpSmooth(float newHp){
        float currHp = hpBar.transform.localScale.x;
        float changeAmt = currHp -newHp;

        while(currHp -newHp > Mathf.Epsilon){
            currHp -= changeAmt * Time.deltaTime;
            SetHP(currHp); //might cause problem ehre 
            yield return null;
        }
        SetHP(newHp);
    }
}
