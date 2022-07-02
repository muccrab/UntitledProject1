using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    //*********************************************************************************************************************************************************************
    public readonly string[] BMNames = { "Bobo", "Nidungus", "Giraldus", "Dimarus", "Sarilo" };
    public readonly string[] KnightNames = { "Raulf", "Wultgar", "Sewal", "Maneld", "Alienor" };
    public readonly string[] MarksmanNames = { "Ebrulf", "Grimold", "Kaenas", "Noemon", "Quintin" };
    public readonly string[] ThiefNames = { "Rayner", "Selle", "Theon", "Vane", "Zeno" };
    public readonly string[] PaladinNames = { "Cleisthenes", "Damasithymos", "Fraomanius", "Palladius", "Julius" };
    public readonly string[] PriestNames = { "Helena", "Nyrie", "Nysa", "Gracia", "Aldith" };
    public readonly string[] BerserkerNames = { "Ragnar", "Olaf", "Bjorn", "Ulf", "Torsten" };
    public readonly string[] HunterNames = { "Nihe", "Odger", "Uwen", "Gahiji", "Phorbas" };
    public readonly string[] MaidenNames = { "Mathilda", "Hylde", "Pylia", "Silke", "Frida" };                                                                              // konstanty pre mena jednotlivych postav
    //*********************************************************************************************************************************************************************


    public readonly string[] Religions = { "Harmony", "Dark", "Holy", "War", "None" };                                                  // konstanty pre viery

    public bool[] UnlockedSpells = {false, false, false, false, false, false, false, false, false};                                     // Pole odomknutych spellov - ak index je true tak spell na tom poradi je odomknuty


    //*********************************************************************************************************************************************************************
    const string Hunter = "Hunter";
    const string Knight = "Knight";
    const string Thief = "Thief";
    const string Marksman = "Marksman";
    const string Paladin = "Paladin";
    const string Berserker = "Berserker";
    const string Priest = "Priest";
    const string BeastMaster = "BeastMaster";
    const string Maiden = "Maiden";                                                                                                     // konstanty nazvy class
    //*********************************************************************************************************************************************************************

    //*********************************************************************************************************************************************************************
    public bool isAlive = true;

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

    public Button spell1ButtonPrefab;
    public RectTransform button1pos;

    public Button spell2ButtonPrefab;
    public RectTransform button2pos;

    //*********************************************************************************************************************************************************************
    public string name;
    public string Class;
    public string religion;
    public Sprite CharImg;                                                                                                              // Meno, Trieda. Vierovyznanie a Obrazok postavy
    //*********************************************************************************************************************************************************************

    public void UnlockSpell(int i)                                                                                                          // Unlocne spell na pozicie parametre ( je to pole takze prve je 0 )
    {
        UnlockedSpells[i] = true;
    }


   private void Update()
    {
        checkDeath();
    }



    private void Start()
    {
        Button spellbutton1 = Instantiate(spell1ButtonPrefab);
        spellbutton1.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        spellbutton1.transform.position = button1pos.position;
        spellbutton1.onClick = spell1ButtonPrefab.onClick;
/*
        Button spellbutton2 = Instantiate(spell2ButtonPrefab);
        spellbutton2.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        spellbutton2.transform.position = button2pos.position;
        spellbutton2.onClick = spell2ButtonPrefab.onClick;
           polebybolofajn        */
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
                    health = 20;
                }
            }

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
        
    }

    public void SetReligion()                                                                                       // Nastavi nahodnu vieru pre kazdu postavu podla ich moznych vierovyznani
    {
        int Rnd;
        switch (Class)
        {
            case Knight:
                Rnd = Random.Range(0, 5);                                                                           // All religions
                religion = Religions[Rnd];
                break;
            case Hunter:
                Rnd = Random.Range(0, 5);
                religion = Religions[Rnd];
                break;
            case Priest:
                Rnd = Random.Range(0, 4);                                                                           // All - Atheist
                religion = Religions[Rnd];
                break;
            case Maiden:
                Rnd = Random.Range(0, 5);
                religion = Religions[Rnd];
                break;
            case Berserker:
                Rnd = Random.Range(1, 5);                                                                           // All - Harmony
                religion = Religions[Rnd];
                break;
            case Paladin:
                Rnd = Random.Range(0, 4);
                religion = Religions[Rnd];
                break;
            case Marksman:
                Rnd = Random.Range(0, 5);
                religion = Religions[Rnd];
                break;
            case BeastMaster:
                Rnd = Random.Range(0, 5);
                religion = Religions[Rnd];
                break;
            case Thief:
                religion = "None";                                                                                  // None
                break;

        }

    }




}
