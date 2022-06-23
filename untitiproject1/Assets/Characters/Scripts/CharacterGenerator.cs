using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerator : MonoBehaviour
{
    //*********************************************************************************************************************************************************************
    const string Hunter = "Hunter";
    const string Knight = "Knight";
    const string Thief = "Thief";
    const string Marksman = "Marksman";
    const string Paladin = "Paladin";
    const string Berserker = "Berserker";
    const string Priest = "Priest";
    const string BeastMaster = "BeastMaster";
    const string Maiden = "Maiden";                                                                                     // Konstanty pre nazvy class jednotlive
    //*********************************************************************************************************************************************************************

    //*********************************************************************************************************************************************************************

    public struct Stats
    {
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
    }                                                                                                                   // Struktura vsetkych statov od ktorych zavisi kombat
    //*********************************************************************************************************************************************************************

    //*********************************************************************************************************************************************************************

    public Stats[] HunterStats = new Stats[2];
    public Stats[] WarriorStats = new Stats[2];
    public Stats[] PriestStats = new Stats[2];
    public Stats[] MaidenStats = new Stats[2];
    public Stats[] BerserkerStats = new Stats[2];
    public Stats[] ThiefStats = new Stats[2];
    public Stats[] MarksmanStats = new Stats[2];
    public Stats[] BMStats = new Stats[2];
    public Stats[] PaladinStats = new Stats[2];
    //treba enum                                                                                                          // pooli statov pre jednotlive classy
    //*********************************************************************************************************************************************************************


    public static readonly string[] Classes = { "Hunter", "Knight", "Priest", "Maiden", "Marksman", "BeastMaster", "Berserker", "Paladin", "Thief" };                       // Konstatny nazvy class v poli
    public Sprite[] CharImg;                                                                                                                                 // Pole ikoniek postav ( musi byt rovnake poradie ako su classy )
    public GameObject[] Chars;                                                                                                                                              // Pole characterov ktore ma generovat

    private void Start()
    {
        GenerateChar();
    }

    public void GenerateChar()                                                                                                                                              // funckia ktora vygeneruje novy character
    {
        setUp();                                                                                                //  Nastav pool statov                                                                                                             

    //*********************************************************************************************************************************************************************
        for (int i = 0; i < Chars.Length; i++)
        {
            int Rnd = Random.Range(0, (Classes.Length));                                                        // Nahodne cislo od 0 po 8 ( dlzka pola classes ) - Je to index

            Chars[i].GetComponent<Character>().Class = Classes[Rnd];                                            // Podla nahodneho cisla mu prirad classu z poolu classes
    //      Chars[i].GetComponent<Character>().CharImg = CharImg[Rnd];                          testing                // Prirad mu prislusny Obrazok ( obrazky musia byt v rovnakom poradi ako je pool classov )
            Chars[i].GetComponent<Character>().SetName();                                                       // Vygeneruje mu nahodne meno podla classi
            Chars[i].GetComponent<Character>().SetReligion();                                                   // Vygeneruje mu nahodny religion podla classy 
    //      Chars[i].GetComponent<Image>().sprite = Chars[i].GetComponent<Character>().CharImg; testing                // Ten isty obrazok da ikonke

            for (int y = 0; y < 9; y++)
            {
                Chars[i].GetComponent<Character>().UnlockedSpells[y] = false;                                   // odstranit - toto je pre testovacie ucely :-)
            }
            for (int x = 0; x < 5; x++)                                                                         // For loop na odomknutie 5 nahodnych spellov
            {
                do
                {
                    Rnd = Random.Range(0, 9);
                }
                while (Chars[i].GetComponent<Character>().UnlockedSpells[Rnd]);                                 // Generuj nahodne cislo dokym nenajde nejake ktore uz nieje odomknute
                Chars[i].GetComponent<Character>().UnlockSpell(Rnd);                                            // Odomkni spell na danom indexe


            }

            switch (Chars[i].GetComponent<Character>().Class)                                                   // Podla classy prirad nahodne staty z daneho poolu                                            
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
                                                                                                                                        // Koniec for loopu pre vygenerovanie vsetkych novych postav
        //*********************************************************************************************************************************************************************
    }




    public void setStats(Stats a, int who)                                                                                      // Nastavi staty podla struktury, ktoru posleme do parametru characteru z pola Chars
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
            Chars[who].GetComponent<Character>().maxHealth = a.maxHealth;

    }
































































    private void setUp()                                                                                // Setup poolu statov pre vsetky postavy
    {
        HunterStats[0].str = 1;                                                                         // stat maxmaxHealth treba preme
        HunterStats[0].dex = 1;
        HunterStats[0].maxHealth = 1;
        HunterStats[0].def = 1;
        HunterStats[0].attackS = 1;
        HunterStats[0].willP = 1;
        HunterStats[0].morale = 1;
        HunterStats[0].minDmg = 1;
        HunterStats[0].maxDmg = 1;
        
        HunterStats[1].str = 2;
        HunterStats[1].dex = 2;
        HunterStats[1].maxHealth = 2;
        HunterStats[1].def = 2;
        HunterStats[1].attackS = 2;
        HunterStats[1].willP = 2;
        HunterStats[1].morale = 2;
        HunterStats[1].minDmg = 2;
        HunterStats[1].maxDmg = 2;

        WarriorStats[0].str = 3;
        WarriorStats[0].dex = 3;
        WarriorStats[0].maxHealth = 3;
        WarriorStats[0].def = 3;
        WarriorStats[0].attackS = 3;
        WarriorStats[0].willP = 3;
        WarriorStats[0].morale = 3;
        WarriorStats[0].minDmg = 3;
        WarriorStats[0].maxDmg = 3;

        WarriorStats[1].str = 4;
        WarriorStats[1].dex = 4;
        WarriorStats[1].maxHealth = 4;
        WarriorStats[1].def = 4;
        WarriorStats[1].attackS = 4;
        WarriorStats[1].willP = 4;
        WarriorStats[1].morale = 4;
        WarriorStats[1].minDmg = 4;
        WarriorStats[1].maxDmg = 4;

        MaidenStats[0].str = 5;
        MaidenStats[0].dex = 5;
        MaidenStats[0].maxHealth = 5;
        MaidenStats[0].def = 5;
        MaidenStats[0].attackS = 5;
        MaidenStats[0].willP = 5;
        MaidenStats[0].morale = 5;
        MaidenStats[0].minDmg = 5;
        MaidenStats[0].maxDmg = 5;

        MaidenStats[1].str = 6;
        MaidenStats[1].dex = 6;
        MaidenStats[1].maxHealth = 6;
        MaidenStats[1].def = 6;
        MaidenStats[1].attackS = 6;
        MaidenStats[1].willP = 6;
        MaidenStats[1].morale = 6;
        MaidenStats[1].minDmg = 6;
        MaidenStats[1].maxDmg = 6;

        PriestStats[0].str = 7;
        PriestStats[0].dex = 7;
        PriestStats[0].maxHealth = 7;
        PriestStats[0].def = 7;
        PriestStats[0].attackS = 7;
        PriestStats[0].willP = 7;
        PriestStats[0].morale = 7;
        PriestStats[0].minDmg = 7;
        PriestStats[0].maxDmg = 7;

        PriestStats[1].str = 8;
        PriestStats[1].dex = 8;
        PriestStats[1].maxHealth = 8;
        PriestStats[1].def = 8;
        PriestStats[1].attackS = 8;
        PriestStats[1].willP = 8;
        PriestStats[1].morale = 8;
        PriestStats[1].minDmg = 8;
        PriestStats[1].maxDmg = 8;

        PaladinStats[0].str = 7;
        PaladinStats[0].dex = 7;
        PaladinStats[0].maxHealth = 7;
        PaladinStats[0].def = 7;
        PaladinStats[0].attackS = 7;
        PaladinStats[0].willP = 7;
        PaladinStats[0].morale = 7;
        PaladinStats[0].minDmg = 7;
        PaladinStats[0].maxDmg = 7;

        PaladinStats[1].str = 8;
        PaladinStats[1].dex = 8;
        PaladinStats[1].maxHealth = 8;
        PaladinStats[1].def = 8;
        PaladinStats[1].attackS = 8;
        PaladinStats[1].willP = 8;
        PaladinStats[1].morale = 8;
        PaladinStats[1].minDmg = 8;
        PaladinStats[1].maxDmg = 8;

        BMStats[0].str = 7;
        BMStats[0].dex = 7;
        BMStats[0].maxHealth = 7;
        BMStats[0].def = 7;
        BMStats[0].attackS = 7;
        BMStats[0].willP = 7;
        BMStats[0].morale = 7;
        BMStats[0].minDmg = 7;
        BMStats[0].maxDmg = 7;

        BMStats[1].str = 8;
        BMStats[1].dex = 8;
        BMStats[1].maxHealth = 8;
        BMStats[1].def = 8;
        BMStats[1].attackS = 8;
        BMStats[1].willP = 8;
        BMStats[1].morale = 8;
        BMStats[1].minDmg = 8;
        BMStats[1].maxDmg = 8;

        ThiefStats[0].str = 7;
        ThiefStats[0].dex = 7;
        ThiefStats[0].maxHealth = 7;
        ThiefStats[0].def = 7;
        ThiefStats[0].attackS = 7;
        ThiefStats[0].willP = 7;
        ThiefStats[0].morale = 7;
        ThiefStats[0].minDmg = 7;
        ThiefStats[0].maxDmg = 7;

        ThiefStats[1].str = 8;
        ThiefStats[1].dex = 8;
        ThiefStats[1].maxHealth = 8;
        ThiefStats[1].def = 8;
        ThiefStats[1].attackS = 8;
        ThiefStats[1].willP = 8;
        ThiefStats[1].morale = 8;
        ThiefStats[1].minDmg = 8;
        ThiefStats[1].maxDmg = 8;

        MarksmanStats[0].str = 7;
        MarksmanStats[0].dex = 7;
        MarksmanStats[0].maxHealth = 7;
        MarksmanStats[0].def = 7;
        MarksmanStats[0].attackS = 7;
        MarksmanStats[0].willP = 7;
        MarksmanStats[0].morale = 7;
        MarksmanStats[0].minDmg = 7;
        MarksmanStats[0].maxDmg = 7;

        MarksmanStats[1].str = 8;
        MarksmanStats[1].dex = 8;
        MarksmanStats[1].maxHealth = 8;
        MarksmanStats[1].def = 8;
        MarksmanStats[1].attackS = 8;
        MarksmanStats[1].willP = 8;
        MarksmanStats[1].morale = 8;
        MarksmanStats[1].minDmg = 8;
        MarksmanStats[1].maxDmg = 8;

        BerserkerStats[0].str = 7;
        BerserkerStats[0].dex = 7;
        BerserkerStats[0].maxHealth = 7;
        BerserkerStats[0].def = 7;
        BerserkerStats[0].attackS = 7;
        BerserkerStats[0].willP = 7;
        BerserkerStats[0].morale = 7;
        BerserkerStats[0].minDmg = 7;
        BerserkerStats[0].maxDmg = 7;

        BerserkerStats[1].str = 8;
        BerserkerStats[1].dex = 8;
        BerserkerStats[1].maxHealth = 8;
        BerserkerStats[1].def = 8;
        BerserkerStats[1].attackS = 8;
        BerserkerStats[1].willP = 8;
        BerserkerStats[1].morale = 8;
        BerserkerStats[1].minDmg = 8;
        BerserkerStats[1].maxDmg = 8;


    }
}
