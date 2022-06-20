using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerator : MonoBehaviour
{
    const string Hunter = "Hunter";
    const string Knight = "Knight";
    const string Thief = "Thief";
    const string Marksman = "Marksman";
    const string Paladin = "Paladin";
    const string Berserker = "Berserker";
    const string Priest = "Priest";
    const string BeastMaster = "BeastMaster";
    const string Maiden = "Maiden";

    public struct Stats
    {
        public int str;
        public int dex;
        public int health;
        public int def;
        public int attackS;
        public int willP;
        public int morale;
        public int minDmg;
        public int maxDmg;
    }
    public Stats[] HunterStats = new Stats[2];
    public Stats[] WarriorStats = new Stats[2];
    public Stats[] PriestStats = new Stats[2];
    public Stats[] MaidenStats = new Stats[2];
    public Stats[] BerserkerStats = new Stats[2];
    public Stats[] ThiefStats = new Stats[2];
    public Stats[] MarksmanStats = new Stats[2];
    public Stats[] BMStats = new Stats[2];
    public Stats[] PaladinStats = new Stats[2];
    //treba enum
    static string[] Classes = { "Hunter", "Knight", "Priest", "Maiden", "Marksman", "BeastMaster", "Berserker", "Paladin", "Thief" };
    public Sprite[] CharImg;
    public GameObject[] Chars;

    public void GenerateChar()
    {
        setUp();
        int Rnd = Random.Range(0, (Classes.Length));

        for (int i = 0; i < Chars.Length; i++)
        {
            Chars[i].GetComponent<Character>().Class = Classes[Rnd];
            Chars[i].GetComponent<Character>().CharImg = CharImg[Rnd];
            Chars[i].GetComponent<Character>().SetName();
            Chars[i].GetComponent<Image>().sprite = Chars[i].GetComponent<Character>().CharImg;


            switch (Chars[i].GetComponent<Character>().Class)
            {
                case Knight:
                    Rnd = Random.Range(0, WarriorStats.Length);
                    setStats(WarriorStats[Rnd], i);
                    break;

                case Hunter:
                    Rnd = Random.Range(0, HunterStats.Length);
                    setStats(HunterStats[Rnd], i);
                    break;

                case Priest:
                    Rnd = Random.Range(0, PriestStats.Length);
                    setStats(PriestStats[Rnd], i);
                    break;

                case Maiden:
                    Rnd = Random.Range(0, MaidenStats.Length);
                    setStats(MaidenStats[Rnd], i);
                    break;
                case Berserker:
                    Rnd = Random.Range(0, BerserkerStats.Length);
                    setStats(BerserkerStats[Rnd], i);
                    break;
                case Paladin:
                    Rnd = Random.Range(0, PaladinStats.Length);
                    setStats(PaladinStats[Rnd], i);
                    break;
                case Marksman:
                    Rnd = Random.Range(0, MarksmanStats.Length);
                    setStats(MarksmanStats[Rnd], i);
                    break;
                case BeastMaster:
                    Rnd = Random.Range(0, BMStats.Length);
                    setStats(BMStats[Rnd], i);
                    break;
                case Thief:
                    Rnd = Random.Range(0, ThiefStats.Length);
                    setStats(ThiefStats[Rnd], i);
                    break;
            }
        }
    }
        

       

    public void setStats(Stats a, int who) 
    {
        if (who == 1)
        {
            Chars[who].GetComponent<Character>().str = a.str;
            Chars[who].GetComponent<Character>().dex = a.dex;
            Chars[who].GetComponent<Character>().health = a.health;
            Chars[who].GetComponent<Character>().def = a.def;
            Chars[who].GetComponent<Character>().attackS = a.attackS;
            Chars[who].GetComponent<Character>().willP = a.willP;
            Chars[who].GetComponent<Character>().morale = a.morale;
            Chars[who].GetComponent<Character>().minDmg = a.minDmg;
            Chars[who].GetComponent<Character>().maxDmg = a.maxDmg;
        }
        else if (who == 2) 
        {
            Chars[who].GetComponent<Character>().str = a.str;
            Chars[who].GetComponent<Character>().dex = a.dex;
            Chars[who].GetComponent<Character>().health = a.health;
            Chars[who].GetComponent<Character>().def = a.def;
            Chars[who].GetComponent<Character>().attackS = a.attackS;
            Chars[who].GetComponent<Character>().willP = a.willP;
            Chars[who].GetComponent<Character>().morale = a.morale;
            Chars[who].GetComponent<Character>().minDmg = a.minDmg;
            Chars[who].GetComponent<Character>().maxDmg = a.maxDmg;
        }
    }

    private void setUp()
    {
        HunterStats[0].str = 1;
        HunterStats[0].dex = 1;
        HunterStats[0].health = 1;
        HunterStats[0].def = 1;
        HunterStats[0].attackS = 1;
        HunterStats[0].willP = 1;
        HunterStats[0].morale = 1;
        HunterStats[0].minDmg = 1;
        HunterStats[0].maxDmg = 1;
        
        HunterStats[1].str = 2;
        HunterStats[1].dex = 2;
        HunterStats[1].health = 2;
        HunterStats[1].def = 2;
        HunterStats[1].attackS = 2;
        HunterStats[1].willP = 2;
        HunterStats[1].morale = 2;
        HunterStats[1].minDmg = 2;
        HunterStats[1].maxDmg = 2;

        WarriorStats[0].str = 3;
        WarriorStats[0].dex = 3;
        WarriorStats[0].health = 3;
        WarriorStats[0].def = 3;
        WarriorStats[0].attackS = 3;
        WarriorStats[0].willP = 3;
        WarriorStats[0].morale = 3;
        WarriorStats[0].minDmg = 3;
        WarriorStats[0].maxDmg = 3;

        WarriorStats[1].str = 4;
        WarriorStats[1].dex = 4;
        WarriorStats[1].health = 4;
        WarriorStats[1].def = 4;
        WarriorStats[1].attackS = 4;
        WarriorStats[1].willP = 4;
        WarriorStats[1].morale = 4;
        WarriorStats[1].minDmg = 4;
        WarriorStats[1].maxDmg = 4;

        MaidenStats[0].str = 5;
        MaidenStats[0].dex = 5;
        MaidenStats[0].health = 5;
        MaidenStats[0].def = 5;
        MaidenStats[0].attackS = 5;
        MaidenStats[0].willP = 5;
        MaidenStats[0].morale = 5;
        MaidenStats[0].minDmg = 5;
        MaidenStats[0].maxDmg = 5;

        MaidenStats[1].str = 6;
        MaidenStats[1].dex = 6;
        MaidenStats[1].health = 6;
        MaidenStats[1].def = 6;
        MaidenStats[1].attackS = 6;
        MaidenStats[1].willP = 6;
        MaidenStats[1].morale = 6;
        MaidenStats[1].minDmg = 6;
        MaidenStats[1].maxDmg = 6;

        PriestStats[0].str = 7;
        PriestStats[0].dex = 7;
        PriestStats[0].health = 7;
        PriestStats[0].def = 7;
        PriestStats[0].attackS = 7;
        PriestStats[0].willP = 7;
        PriestStats[0].morale = 7;
        PriestStats[0].minDmg = 7;
        PriestStats[0].maxDmg = 7;

        PriestStats[1].str = 8;
        PriestStats[1].dex = 8;
        PriestStats[1].health = 8;
        PriestStats[1].def = 8;
        PriestStats[1].attackS = 8;
        PriestStats[1].willP = 8;
        PriestStats[1].morale = 8;
        PriestStats[1].minDmg = 8;
        PriestStats[1].maxDmg = 8;

        PaladinStats[0].str = 7;
        PaladinStats[0].dex = 7;
        PaladinStats[0].health = 7;
        PaladinStats[0].def = 7;
        PaladinStats[0].attackS = 7;
        PaladinStats[0].willP = 7;
        PaladinStats[0].morale = 7;
        PaladinStats[0].minDmg = 7;
        PaladinStats[0].maxDmg = 7;

        PaladinStats[1].str = 8;
        PaladinStats[1].dex = 8;
        PaladinStats[1].health = 8;
        PaladinStats[1].def = 8;
        PaladinStats[1].attackS = 8;
        PaladinStats[1].willP = 8;
        PaladinStats[1].morale = 8;
        PaladinStats[1].minDmg = 8;
        PaladinStats[1].maxDmg = 8;

        BMStats[0].str = 7;
        BMStats[0].dex = 7;
        BMStats[0].health = 7;
        BMStats[0].def = 7;
        BMStats[0].attackS = 7;
        BMStats[0].willP = 7;
        BMStats[0].morale = 7;
        BMStats[0].minDmg = 7;
        BMStats[0].maxDmg = 7;

        BMStats[1].str = 8;
        BMStats[1].dex = 8;
        BMStats[1].health = 8;
        BMStats[1].def = 8;
        BMStats[1].attackS = 8;
        BMStats[1].willP = 8;
        BMStats[1].morale = 8;
        BMStats[1].minDmg = 8;
        BMStats[1].maxDmg = 8;

        ThiefStats[0].str = 7;
        ThiefStats[0].dex = 7;
        ThiefStats[0].health = 7;
        ThiefStats[0].def = 7;
        ThiefStats[0].attackS = 7;
        ThiefStats[0].willP = 7;
        ThiefStats[0].morale = 7;
        ThiefStats[0].minDmg = 7;
        ThiefStats[0].maxDmg = 7;

        ThiefStats[1].str = 8;
        ThiefStats[1].dex = 8;
        ThiefStats[1].health = 8;
        ThiefStats[1].def = 8;
        ThiefStats[1].attackS = 8;
        ThiefStats[1].willP = 8;
        ThiefStats[1].morale = 8;
        ThiefStats[1].minDmg = 8;
        ThiefStats[1].maxDmg = 8;

        MarksmanStats[0].str = 7;
        MarksmanStats[0].dex = 7;
        MarksmanStats[0].health = 7;
        MarksmanStats[0].def = 7;
        MarksmanStats[0].attackS = 7;
        MarksmanStats[0].willP = 7;
        MarksmanStats[0].morale = 7;
        MarksmanStats[0].minDmg = 7;
        MarksmanStats[0].maxDmg = 7;

        MarksmanStats[1].str = 8;
        MarksmanStats[1].dex = 8;
        MarksmanStats[1].health = 8;
        MarksmanStats[1].def = 8;
        MarksmanStats[1].attackS = 8;
        MarksmanStats[1].willP = 8;
        MarksmanStats[1].morale = 8;
        MarksmanStats[1].minDmg = 8;
        MarksmanStats[1].maxDmg = 8;

        BerserkerStats[0].str = 7;
        BerserkerStats[0].dex = 7;
        BerserkerStats[0].health = 7;
        BerserkerStats[0].def = 7;
        BerserkerStats[0].attackS = 7;
        BerserkerStats[0].willP = 7;
        BerserkerStats[0].morale = 7;
        BerserkerStats[0].minDmg = 7;
        BerserkerStats[0].maxDmg = 7;

        BerserkerStats[1].str = 8;
        BerserkerStats[1].dex = 8;
        BerserkerStats[1].health = 8;
        BerserkerStats[1].def = 8;
        BerserkerStats[1].attackS = 8;
        BerserkerStats[1].willP = 8;
        BerserkerStats[1].morale = 8;
        BerserkerStats[1].minDmg = 8;
        BerserkerStats[1].maxDmg = 8;


    }
}
