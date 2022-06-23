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


    private int CurrentSpell = 0;

    private bool enemyFound = false;

    private void Update()
    {
        if (CurrentSpell == 1)
        {
            int pos;
            pos = GetEnemy();
            if (enemyFound)
            {
                spell1use(pos);
                enemyFound = false;
                CurrentSpell = 0;
            }
            


        }
        
        
    }


    public void spell1()
    {
        CurrentSpell = 1;
    }

    private void spell1use(int pos)
    {
        positions[pos].GetComponentInChildren<Enemy>().health -= 20;
    }





    public int GetEnemy()
    {
        int pos = 0;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[0].GetComponentInChildren<BoxCollider2D>().bounds.Contains(mousePos2D))
                {
                    pos = i;
                    enemyFound = true;
                }
            }
        }
        return pos;
    }

}

