using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
   
    //*********************************************************************************************************************************************************************
    public bool isAlive = true;
    public bool myTurn = false;

    public int str;
    public int dex;
    public int health;
    public int maxHealth;
    public int def;
    public int attackS;
    public int willP;
    public int morale;
    public int minDmg;
    public int maxDmg;                                                                                                                  // Staty a zakladne logicke parametre
    //*********************************************************************************************************************************************************************




    private void Update()
    {
     //   checkDeath();
    }




    private void Start()
    {
        maxHealth = 100;
        /*
        Button spellbutton2 = Instantiate(spell2ButtonPrefab);
        spellbutton2.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        spellbutton2.transform.position = button2pos.position;
        spellbutton2.onClick = spell2ButtonPrefab.onClick;
           polebybolofajn        */
    }


    public void checkDeath()
    {
        if (health <= 0)
        {
            int whoToDestroy = 0;
            foreach (var Item in transform.parent.parent.GetComponent<GameController>().TurnOrderList)
            {
                if(Item.character != null)
                if (Item.character.name == this.name)
                {
                    
                    break;
                }
                whoToDestroy++;
            }
            if (whoToDestroy < transform.parent.parent.GetComponent<GameController>().TurnOrderList.Count)
            {
                transform.parent.parent.GetComponent<GameController>().TurnOrderList.RemoveAt(whoToDestroy);
            }


            if (!isAlive)
            {
                Destroy(gameObject);
            }
            else
            {
                health = 0;
                int deathChance = Random.Range(1, 6);
                if (deathChance != 1)
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
                    health = 20;
                }
            }

        }

        


    }


    public void Heal(int value)
    {
        health += value;
        if( health > maxHealth)
        {
            health = maxHealth;
        }
    }


}
