using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField] GameObject hpBar;


    public void SetHP(float hpNormalized){

        hpBar.transform.localScale = new Vector3(hpNormalized, 1f);

    }
}
