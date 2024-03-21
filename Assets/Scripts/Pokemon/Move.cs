using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move 
{
    public MoveTemplate Template {get; set;}
    public int PP {get; set;}
    
    public Move(MoveTemplate pkmTemplate){
        Template = pkmTemplate;
        PP = pkmTemplate.GetPP();
    }
}
