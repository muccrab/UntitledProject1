using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerator : MonoBehaviour
{
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
    //treba enum
    static string[] Classes = { "Hunter", "Warrior", "Priest", "Maiden" };
    public Sprite[] CharImg;
    public GameObject Char1;
    public GameObject Char2;
    public void GenerateChar()
    {
        setUp();
        int Rnd = Random.Range(0, (Classes.Length));
       
        Char1.GetComponent<Character>().Class = Classes[Rnd];
        Char1.GetComponent<Character>().CharImg = CharImg[Rnd];
        Char1.GetComponent<Image>().sprite = Char1.GetComponent<Character>().CharImg;

        Rnd = Random.Range(0, (Classes.Length));
        
        Char2.GetComponent<Character>().Class = Classes[Rnd];
        Char2.GetComponent<Character>().CharImg = CharImg[Rnd];
        Char2.GetComponent<Image>().sprite = Char2.GetComponent<Character>().CharImg;

        switch (Char1.GetComponent<Character>().Class) 
        {
            case "Warrior" :
                Rnd = Random.Range(0, WarriorStats.Length);
                setStats(WarriorStats[Rnd], 1);
                break;

            case "Hunter":
                Rnd = Random.Range(0, HunterStats.Length);
                setStats(HunterStats[Rnd], 1);
                break;

            case "Priest":
                Rnd = Random.Range(0, PriestStats.Length);
                setStats(PriestStats[Rnd], 1);
                break;

            case "Maiden":
                Rnd = Random.Range(0, MaidenStats.Length);
                setStats(MaidenStats[Rnd], 1);
                break;
        }

        switch (Char2.GetComponent<Character>().Class)
        {
            case "Warrior":
                Rnd = Random.Range(0, WarriorStats.Length);
                setStats(WarriorStats[Rnd], 2);
                break;

            case "Hunter":
                Rnd = Random.Range(0, HunterStats.Length);
                setStats(HunterStats[Rnd], 2);
                break;

            case "Priest":
                Rnd = Random.Range(0, PriestStats.Length);
                setStats(PriestStats[Rnd], 2);
                break;

            case "Maiden":
                Rnd = Random.Range(0, MaidenStats.Length);
                setStats(MaidenStats[Rnd], 2);
                break;
        }
    }

    public void setStats(Stats a, int who) 
    {
        if (who == 1)
        {
            Char1.GetComponent<Character>().str = a.str;
            Char1.GetComponent<Character>().dex = a.dex;
            Char1.GetComponent<Character>().health = a.health;
            Char1.GetComponent<Character>().def = a.def;
            Char1.GetComponent<Character>().attackS = a.attackS;
            Char1.GetComponent<Character>().willP = a.willP;
            Char1.GetComponent<Character>().morale = a.morale;
            Char1.GetComponent<Character>().minDmg = a.minDmg;
            Char1.GetComponent<Character>().maxDmg = a.maxDmg;
        }
        else if (who == 2) 
        {
            Char2.GetComponent<Character>().str = a.str;
            Char2.GetComponent<Character>().dex = a.dex;
            Char2.GetComponent<Character>().health = a.health;
            Char2.GetComponent<Character>().def = a.def;
            Char2.GetComponent<Character>().attackS = a.attackS;
            Char2.GetComponent<Character>().willP = a.willP;
            Char2.GetComponent<Character>().morale = a.morale;
            Char2.GetComponent<Character>().minDmg = a.minDmg;
            Char2.GetComponent<Character>().maxDmg = a.maxDmg;
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
    }
}
