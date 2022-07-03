using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
//*********************************************************************************************************************************************************************
    public int str;
    public int dex;
    public int health;
    public int def;
    public int attackS;
    public int willP;
    public int morale;
    public int minDmg;
    public int maxDmg;
    public int maxHealth;
    public bool isAlive = true;
    public bool myTurn = false;
    // Staty a zakladne logicke parametre
    //*********************************************************************************************************************************************************************

    public string name = "Skelly";
    public string type = "Undead";

    private void Update()
    {
        if(myTurn)
        {
            gameObject.GetComponent<EnemySpells>().spell1use();
        }
        checkDeath();
    }

    private void checkDeath()
    {
        if (health <= 0)
        {
            if (!isAlive)
            {
                Destroy(gameObject);
            }
            else
            {
                health = 0;
                int deathChance = Random.Range(1, 3);
                if (deathChance == 1)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Sprite grave = Resources.Load<Sprite>("graveStone");
                    isAlive = false;
                    gameObject.GetComponent<SpriteRenderer>().sprite = grave;
                    gameObject.transform.localScale = new Vector2(6, 6);
                    gameObject.transform.localPosition = new Vector2(0, gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2);
                    gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.35f, 0.5f);
                    health = 20;
                }
            }
            
        }


    }

}
