using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{


    public string name = "Skelly";
    public string type = "Undead";

    private void Update()
    {
        if(gameObject.GetComponent<Character>().myTurn)
        {
            gameObject.GetComponent<EnemySpells>().spell1use();
        }
    }

   


    

}
