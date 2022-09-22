using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ally : MonoBehaviour
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

    public bool[] UnlockedSpells = { false, false, false, false, false, false, false, false, false };                                     // Pole odomknutych spellov - ak index je true tak spell na tom poradi je odomknuty
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
    //*********************************************************************************************************************************************************************


    private void Start()
    {
        //int Rnd;                                                          // petko robi veci na zatial kym nie sme spojeny s charGene scriptom
        for (int x = 0; x < 5; x++)                                       // For loop na odomknutie 5 nahodnych spellov
        {
            /*
            do
            {
                Rnd = Random.Range(0, 9);
            }
            while (UnlockedSpells[Rnd]);                                 // Generuj nahodne cislo dokym nenajde nejake ktore uz nieje odomknute
            UnlockSpell(Rnd);                                            // Odomkni spell na danom indexe
            */                             // Pre testovacie ucely potrebujem mat pevne spelly so fix by Jakub
            UnlockSpell(x);
        }
    }

    private void Update()
    {
        if (!isGenerated)
        {
            isGenerated = true;
            GenerateAllSpells();

            SetSpellsActiveFalse();
        }

        if (gameObject.GetComponent<Character>().myTurn)
        {
            SetSpellsActiveTrue();
        }
        else
        {
            SetSpellsActiveFalse();
        }

    }



    public void UnlockSpell(int i)                                                                                                          // Unlockne spell na pozicie parametre ( je to pole takze prve je 0 )
    {
        UnlockedSpells[i] = true;
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
