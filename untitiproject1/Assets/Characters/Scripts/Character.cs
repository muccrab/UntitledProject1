using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

<<<<<<< Updated upstream

=======
  
    public Button[] spellButtonPrefabs = new Button[9];
    public RectTransform[] buttonPoss = new RectTransform[5];
    public Button[] spellButtons = new Button[5]; 

   

    //*********************************************************************************************************************************************************************
    public string name;
    public string Class;
    public string religion;
    public Sprite CharImg;                                                                                                              // Meno, Trieda. Vierovyznanie a Obrazok postavy
    //*********************************************************************************************************************************************************************

    public bool isGenerated = false;

    private void Start()
    {
        int Rnd;                                                          // petko robi veci na zatial kym nie sme spojeny s charGene scriptom
        for (int x = 0; x < 5; x++)                                       // For loop na odomknutie 5 nahodnych spellov
        {
            do
            {
               Rnd = Random.Range(0, 9);
            }
            while (UnlockedSpells[Rnd]);                                 // Generuj nahodne cislo dokym nenajde nejake ktore uz nieje odomknute
            UnlockSpell(Rnd);                                            // Odomkni spell na danom indexe
        }
    }

    public void UnlockSpell(int i)                                                                                                          // Unlocne spell na pozicie parametre ( je to pole takze prve je 0 )
    {
        UnlockedSpells[i] = true;
    }
>>>>>>> Stashed changes

    

    private void Update()
    {
<<<<<<< Updated upstream
     //   checkDeath();
    }
=======
        checkDeath();
        if (!isGenerated)
        {
            isGenerated = true;
            GenerateAllSpells();


            SetSpellsActiveFalse();
        }
>>>>>>> Stashed changes







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

<<<<<<< Updated upstream
=======

    }

    public void SetSpellsActiveTrue()
    {

        spellButtons[0].gameObject.SetActive(true);
        spellButtons[1].gameObject.SetActive(true);
        spellButtons[2].gameObject.SetActive(true);
        spellButtons[3].gameObject.SetActive(true);
        spellButtons[4].gameObject.SetActive(true);
     
    }

    public void SetSpellsActiveFalse()
    {
        spellButtons[0].gameObject.SetActive(false);
        spellButtons[1].gameObject.SetActive(false);
        spellButtons[2].gameObject.SetActive(false);
        spellButtons[3].gameObject.SetActive(false);
        spellButtons[4].gameObject.SetActive(false);

    }

    private void GenerateAllSpells()
    {
        int i = 0;

        for (int x = 0; x < 5; x++)                                                                        
        {
            while (!UnlockedSpells[i])
            {
                i++;
            }
            spellButtons[x] = Instantiate(spellButtonPrefabs[i]);
            spellButtons[x].transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            spellButtons[x].transform.position = buttonPoss[x].position;
            spellButtons[x].gameObject.SetActive(true);
            spellButtons[x].onClick = spellButtonPrefabs[i].onClick;
            i++;
        }

    }


















































    public void SetName()                                                                                   // Nahodne meno z poolu mien pre kazdy postavu zvlast
    {
        int Rnd = Random.Range(0, 5);
        switch (Class)
        {
            case Knight:
                name = KnightNames[Rnd];
                break;
            case Hunter:
                name = HunterNames[Rnd];
                break;
            case Priest:
                name = PriestNames[Rnd];
                break;
            case Maiden:
                name = MaidenNames[Rnd];
                break;
            case Berserker:
                name = BerserkerNames[Rnd];
                break;
            case Paladin:
                name = PaladinNames[Rnd];
                break;
            case Marksman:
                name = MarksmanNames[Rnd];
                break;
            case BeastMaster:
                name = BMNames[Rnd];
                break;
            case Thief:
                name = ThiefNames[Rnd];
                break;

        }
>>>>>>> Stashed changes
        


    }


}
