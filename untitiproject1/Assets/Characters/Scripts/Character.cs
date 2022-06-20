using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    public readonly string[] BMNames = { "German", "Spanish", "Corrects", "Wrongs", "Nicadasd" };
    public readonly string[] KnightNames = { "German", "Spanish", "Corrects", "Wrongs", "Nicadasd" };
    public readonly string[] MarksmanNames = { "German", "Spanish", "Corrects", "Wrongs", "Nicadasd" };
    public readonly string[] ThiefNames = { "German", "Spanish", "Corrects", "Wrongs", "Nicadasd" };
    public readonly string[] PaladinNames = { "German", "Spanish", "Corrects", "Wrongs", "Nicadasd" };
    public readonly string[] PriestNames = { "German", "Spanish", "Corrects", "Wrongs", "Nicadasd" };
    public readonly string[] BerserkerNames = { "German", "Spanish", "Corrects", "Wrongs", "Nicadasd" };
    public readonly string[] HunterNames = { "German", "Spanish", "Corrects", "Wrongs", "Nicadasd" };
    public readonly string[] MaidenNames = { "German", "Spanish", "Corrects", "Wrongs", "Nicadasd" };

    const string Hunter = "Hunter";
    const string Knight = "Knight";
    const string Thief = "Thief";
    const string Marksman = "Marksman";
    const string Paladin = "Paladin";
    const string Berserker = "Berserker";
    const string Priest = "Priest";
    const string BeastMaster = "BeastMaster";
    const string Maiden = "Maiden";

    public int str;
    public int dex;
    public int health;
    public int def;
    public int attackS;
    public int willP;
    public int morale;
    public int minDmg;
    public int maxDmg;

    public string name;
    public string Class;
    public string religion;
    public Sprite CharImg;


    public void SetName()
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
        

  

}
