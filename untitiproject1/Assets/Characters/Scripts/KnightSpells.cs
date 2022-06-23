using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class KnightSpells : MonoBehaviour
{
    public Button[] spellButtons;
    public Sprite[] spellIcons;
    public GameObject[] positions;

    private void Update()
    {
        
       if(positions[0].GetComponentInChildren<BoxCollider2D>().bounds.Contains(Input.mousePosition))
        {
            Debug.Log("negro v kleci");
        }
    }


    public void spell1()
    {
         GetEnemy();
    }





    public void GetEnemy()
    {
        WaitforClick();
    }
    IEnumerator WaitforClick()
    {

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                yield break;
            }
            yield return null;
        }
    }
}

