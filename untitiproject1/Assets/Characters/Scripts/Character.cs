using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    #region variables

    //*********************************************************************************************************************************************************************

    public bool isAlive = true;
    public bool myTurn = false;
    private bool startOfTurn = true;

    //*********************************************************************************************************************************************************************

    //*********************************************************************************************************************************************************************
    // Effects 

    #region definition

    public struct bleed
    {
        public int turns;
        public int dmg;
    }
    public struct effects
    {
        public bleed bleed;

    }

    #endregion definition

    #region implementation

    public effects Effects;

    #endregion implementation
    // Effects
    //*********************************************************************************************************************************************************************

    //*********************************************************************************************************************************************************************
    // Staty a zakladne logicke parametre
    public int str;
    public int dex;
    public int health;
    public int maxHealth;
    public int def;
    public int attackS;
    public int willP;
    public int morale;
    public int minDmg;
    public int maxDmg;
    // Staty a zakladne logicke parametre
    //*********************************************************************************************************************************************************************
    #endregion variables



    //*********************************************************************************************************************************************************************
    private void Update()
    {
        if(myTurn)
        {
            if(startOfTurn)
            {
                startOfTurn = false;
                CheckEffects();
            }
        }
        else
        {
            startOfTurn = true;
        }
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

    private void CheckEffects()
    {
        Bleed();
    }

    private void Bleed()
    {
        if(Effects.bleed.turns > 0)
        {
            Effects.bleed.turns -= 1;
            if(Effects.bleed.turns <= 0 )
            {
                CureBleed();
            }
            health -= Effects.bleed.dmg;
            Effects.bleed.dmg += Effects.bleed.dmg / 3;                                         // idk but sure makes sense ( dmg upgrade )
        }
    }

    public void CureBleed()
    {
        Effects.bleed.dmg = 0;
        Effects.bleed.turns = 0;
    }

    public void ApplyBleed( int turns, int dmg )
    {
        Effects.bleed.turns += turns;
        Effects.bleed.dmg += dmg;                           // musime sa dohodnut ako to bude fungovat
    }



}
