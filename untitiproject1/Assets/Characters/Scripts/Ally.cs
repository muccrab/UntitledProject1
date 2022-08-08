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


    public Button spell1ButtonPrefab;
    public RectTransform button1pos;

    public Button spell2ButtonPrefab;
    public RectTransform button2pos;

    public Button spell3ButtonPrefab;
    public RectTransform button3pos;

    public Button spell4ButtonPrefab;
    public RectTransform button4pos;

    public Button spell5ButtonPrefab;
    public RectTransform button5pos;

    public Button spell6ButtonPrefab;
    public RectTransform button6pos;

    public Button spell7ButtonPrefab;
    public RectTransform button7pos;

    public Button spell8ButtonPrefab;
    public RectTransform button8pos;


    private Button spellbutton1;
    private Button spellbutton2;
    private Button spellbutton3;
    private Button spellbutton4;
    private Button spellbutton5;
    private Button spellbutton6;
    private Button spellbutton7;
    private Button spellbutton8;

    //*********************************************************************************************************************************************************************
    public string name;
    public string Class;
    public string religion;
    public Sprite CharImg;                                                                                                              // Meno, Trieda. Vierovyznanie a Obrazok postavy
    //*********************************************************************************************************************************************************************
    public bool isGenerated = false;
    //*********************************************************************************************************************************************************************



    private void Update()
    {
        if (!isGenerated)
        {
            isGenerated = true;
            spellbutton1 = Instantiate(spell1ButtonPrefab);
            spellbutton1.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            spellbutton1.transform.position = button1pos.position;
            spellbutton1.gameObject.SetActive(true);
            spellbutton1.onClick = spell1ButtonPrefab.onClick;

            spellbutton2 = Instantiate(spell2ButtonPrefab);
            spellbutton2.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            spellbutton2.transform.position = button2pos.position;
            spellbutton2.gameObject.SetActive(true);
            spellbutton2.onClick = spell2ButtonPrefab.onClick;

            spellbutton3 = Instantiate(spell3ButtonPrefab);
            spellbutton3.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            spellbutton3.transform.position = button3pos.position;
            spellbutton3.gameObject.SetActive(true);
            spellbutton3.onClick = spell3ButtonPrefab.onClick;

            spellbutton4 = Instantiate(spell4ButtonPrefab);
            spellbutton4.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            spellbutton4.transform.position = button4pos.position;
            spellbutton4.gameObject.SetActive(true);
            spellbutton4.onClick = spell4ButtonPrefab.onClick;

            spellbutton5 = Instantiate(spell5ButtonPrefab);
            spellbutton5.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            spellbutton5.transform.position = button5pos.position;
            spellbutton5.gameObject.SetActive(true);
            spellbutton5.onClick = spell5ButtonPrefab.onClick;

            spellbutton6 = Instantiate(spell6ButtonPrefab);
            spellbutton6.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            spellbutton6.transform.position = button6pos.position;
            spellbutton6.gameObject.SetActive(true);
            spellbutton6.onClick = spell6ButtonPrefab.onClick;

            spellbutton7 = Instantiate(spell7ButtonPrefab);
            spellbutton7.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            spellbutton7.transform.position = button7pos.position;
            spellbutton7.gameObject.SetActive(true);
            spellbutton7.onClick = spell7ButtonPrefab.onClick;

            spellbutton8 = Instantiate(spell8ButtonPrefab);
            spellbutton8.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            spellbutton8.transform.position = button8pos.position;
            spellbutton8.gameObject.SetActive(true);
            spellbutton8.onClick = spell8ButtonPrefab.onClick;




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
        spellbutton1.gameObject.SetActive(true);
        spellbutton2.gameObject.SetActive(true);
        spellbutton3.gameObject.SetActive(true);
        spellbutton4.gameObject.SetActive(true);
        spellbutton5.gameObject.SetActive(true);
        spellbutton6.gameObject.SetActive(true);
        spellbutton7.gameObject.SetActive(true);
        spellbutton8.gameObject.SetActive(true);
    }

    public void SetSpellsActiveFalse()
    {
        spellbutton1.gameObject.SetActive(false);
        spellbutton2.gameObject.SetActive(false);
        spellbutton3.gameObject.SetActive(false);
        spellbutton4.gameObject.SetActive(false);
        spellbutton5.gameObject.SetActive(false);
        spellbutton6.gameObject.SetActive(false);
        spellbutton7.gameObject.SetActive(false);
        spellbutton8.gameObject.SetActive(false);
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
