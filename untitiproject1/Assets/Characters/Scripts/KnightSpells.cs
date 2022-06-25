using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class KnightSpells : MonoBehaviour
{
    public Sprite[] spellIcons;
    public GameObject[] positions;

    private int CurrentSpell = 0;

    private bool enemyFound = false;

    private void Update()
    {
        spell1use();
    }

    


    public void spell1()
    {
        CurrentSpell = 1;
    }

    private void spell1use()
    {
        if (CurrentSpell == 1)
        {
            int pos = GetEnemy();
            if (enemyFound)
            {
                CurrentSpell = 0;
                enemyFound = false;
                positions[pos].GetComponentInChildren<Enemy>().health -= 20;
                
            }



        }
        
    }





    public int GetEnemy()
    {
        int pos = 0;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            for (int i = 0; i < 4; i++)
            {
                if (positions[i].GetComponentInChildren<BoxCollider2D>().bounds.Contains(mousePos2D))
                {
                    pos = i;
                    enemyFound = true;
                }
            }
        }
        return pos;
    }

}

