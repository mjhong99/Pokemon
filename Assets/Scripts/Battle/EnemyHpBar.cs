using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{

    [SerializeField] Image hpBar;
    [SerializeField] Color green = new Color((25f/255f),(192f/255f),(33f/255f));
    [SerializeField] Color yellow = new Color((230f/255f),(177f/255f),(73f/255f));
    [SerializeField] Color red = new Color((225f/255f),(79f/255f),(63f/255f));

    // may modify these function incase of making it independent and easier for reusability.
    // later, try to // Find the "HealthGreen" GameObject and get its Image component in separate func to encapsulate


    void Start()
    {
    // Find the "EnemyHealthGreen" GameObject and get its Image component
    GameObject EnemyHealthGreen = GameObject.Find("EnemyHealthGreen");

    if (EnemyHealthGreen != null)
    {
        hpBar = EnemyHealthGreen.GetComponent<Image>();
        if (hpBar != null)
        {
            Debug.Log(" Enemy Image component found and assigned successfully.");
        }
        else
        {
            Debug.LogWarning("Enemy Image component not found on HealthGreen GameObject.");
        }
    }
    else
    {
        Debug.LogWarning("Enemy HealthGreen GameObject not found.");
    }
    // call this for testing the hp bar color
    SetEnemyHpBar(0.4f);
    }

    public void SetEnemyHpBar(float hpNormalized){

        hpBar.transform.localScale = new Vector3(hpNormalized, 1f);

        if (hpNormalized > 0.5f){
            SetEnemyBarColor(green);
        }
        else if (hpNormalized >0.1f){
            SetEnemyBarColor(yellow);
        }

        else {
            SetEnemyBarColor(red);
        }


    }

    private void SetEnemyBarColor(Color color){
        
        if (hpBar != null){
            hpBar.color = color;
        }
        else {
            Debug.LogWarning("Image Component not found in Hp bar");
        }
    }
}
