using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public struct CharAndSpeed
    {
        public GameObject character;
        public int Speed;
    }

    public struct EnemyFound
    {
        public int pos;
        public bool found;
    }

    private bool endC;
    private bool endD;


    const int speedKoef = 10;

    public GameObject[] Enemies;
    public GameObject[] Characters;


    public bool[] target = { false, false, false, false };
    public bool[] targetable = { false, false, false, false };

    public bool[] targetAlly = { false, false, false, false };
    public bool[] targetableAlly = { false, false, false, false };

    Vector3 mousePos;
    Vector2 mousePos2D;

    public List<CharAndSpeed> TurnOrderList = new List<CharAndSpeed>();


    // Start is called before the first frame update
    void Start()
    {
        SetMouse();
        GenerateFirstList();
    }

    // Update is called once per frame
    void Update()
    {/*
        if (TurnOrderList.Count <= 0)
        {
            TurnOrder();
        }*/
        SetMouse();
        EnemyPointedAt();
        AllyPointedAt();
        moveForv();
        CombatEnd();


        if (endD)
        {
            Debug.Log("DungeonEnd");
            // sem treba doplnit logiku
        }
        if (endC)
        {
            Debug.Log("CombatEnd");
            // sem treba doplnit logiku
        }
    }

    //*******************************************************************************************************************************************************************************************************
    // General game logic methods       

    public void ResetTargets()
    {
        for (int i = 0; i < 4; i++)
        {
            targetable[i] = false;
            target[i] = false;
            Enemies[i].transform.Find("TargetablePointer").gameObject.SetActive(false);
            Enemies[i].transform.Find("TargetPointer").gameObject.SetActive(false);

            // Ally cast
            targetableAlly[i] = false;
            targetAlly[i] = false;
            Characters[i].transform.Find("TargetablePointer").gameObject.SetActive(false);
            Characters[i].transform.Find("TargetPointer").gameObject.SetActive(false);
        }
    }

    private void CombatEnd()
    {
        endC = true;
        endD = true;
        for (int i = 0; i < 4; i++)
        {
            GameObject Enemy = FindChildWithTag(Enemies[i], "Enemies");
            if (Enemy != null)
            {
                if (Enemy.GetComponent<Character>().isAlive)
                {
                    endC = false;                                                   // End combat bool
                    break;
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            GameObject Char = FindChildWithTag(Characters[i], "Character");
            if (Char != null)
            {
                if (Char.GetComponent<Character>().isAlive)
                {
                    endD = false;                                                   // End dungeon bool
                    break;
                }
            }
        }
    }

    public void moveForv()
    {
        for (int i = 0; i < 4; i++)
        {
            if (FindChildWithTag(Enemies[i], "Enemies") == null)
            {
                for (int x = i + 1; x < 4; x++)
                {
                    if (FindChildWithTag(Enemies[x], "Enemies") != null)
                    {
                        GameObject clone = FindChildWithTag(Enemies[x], "Enemies");
                        clone.transform.SetParent(Enemies[i].transform);
                        clone.transform.localPosition = new Vector2(0, clone.transform.localPosition.y);
                        break;
                    }
                }
            }
        }



        for (int i = 0; i < 4; i++)
        {
            if (FindChildWithTag(Characters[i], "Character") == null)
            {
                for (int x = i + 1; x < 4; x++)
                {
                    if (FindChildWithTag(Characters[x], "Character") != null)
                    {
                        GameObject clone = FindChildWithTag(Characters[x], "Character");
                        clone.transform.SetParent(Characters[i].transform);
                        clone.transform.localPosition = new Vector2(0, clone.transform.localPosition.y);
                        break;
                    }
                }
            }
        }

    }

    //*******************************************************************************************************************************************************************************************************
    // General methods

    public static GameObject FindChildWithTag(GameObject parent, string tag)
    {
        GameObject child = null;

        foreach (Transform transform in parent.transform)
        {
            if (transform.CompareTag(tag))
            {
                child = transform.gameObject;
                break;
            }
        }

        return child;
    }

    //*******************************************************************************************************************************************************************************************************
    // Enemy methods

    public void SetTargetable(int min, int max)
    {
        for (int i = min; i <= max; i++)
        {
            if (GameController.FindChildWithTag(Enemies[i], "Enemies") != null)
            {
                targetable[i] = true;
                Enemies[i].transform.Find("TargetablePointer").gameObject.SetActive(true);
            }
        }
    }

    private void EnemyPointedAt()
    {
        for (int i = 0; i < 4; i++)
        {
            if (GameController.FindChildWithTag(Enemies[i], "Enemies") != null)
            {
                if (Enemies[i].GetComponentInChildren<BoxCollider2D>().bounds.Contains(mousePos2D))
                {
                    if (targetable[i] == true)
                    {
                        Enemies[i].transform.Find("TargetPointer").gameObject.SetActive(true);
                    }
                }
                else
                {
                    Enemies[i].transform.Find("TargetPointer").gameObject.SetActive(false);
                }

            }
        }
    }

    public EnemyFound GetEnemy()
    {
        EnemyFound enemy;
        enemy.found = false;
        enemy.pos = 0;

        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < 4; i++)
            {
                if (GameController.FindChildWithTag(Enemies[i], "Enemies") != null && targetable[i])
                {
                    if (Enemies[i].GetComponentInChildren<BoxCollider2D>().bounds.Contains(mousePos2D))
                    {
                        enemy.pos = i;
                        enemy.found = true;
                    }
                }
            }
        }
        return enemy;
    }

    //*******************************************************************************************************************************************************************************************************
    // Ally methods

    public void SetTargetableAlly(int min, int max)
    {
        for (int i = min; i <= max; i++)
        {
            if (GameController.FindChildWithTag(Characters[i], "Character") != null)
            {
                targetableAlly[i] = true;
                Characters[i].transform.Find("TargetablePointer").gameObject.SetActive(true);
            }
        }
    }

    public EnemyFound GetAlly()
    {
        EnemyFound ally;
        ally.found = false;
        ally.pos = 0;

        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < 4; i++)
            {
                if (GameController.FindChildWithTag(Characters[i], "Character") != null && targetableAlly[i])
                {
                    if (Characters[i].GetComponentInChildren<BoxCollider2D>().bounds.Contains(mousePos2D))
                    {
                        ally.pos = i;
                        ally.found = true;
                    }
                }
            }
        }
        return ally;
    }

    private void AllyPointedAt()
    {
        for (int i = 0; i < 4; i++)
        {
            if (GameController.FindChildWithTag(Characters[i], "Character") != null)
            {
                if (Characters[i].GetComponentInChildren<BoxCollider2D>().bounds.Contains(mousePos2D))
                {
                    if (targetableAlly[i] == true)
                    {
                        Characters[i].transform.Find("TargetPointer").gameObject.SetActive(true);
                    }
                }
                else
                {
                    Characters[i].transform.Find("TargetPointer").gameObject.SetActive(false);
                }

            }
        }
    }

    //*******************************************************************************************************************************************************************************************************
    // Order list methods

    private void GenerateFirstList()
    {
        TurnOrder();
        TurnOrderList[0].character.gameObject.GetComponent<Character>().myTurn = true;
    }

    private void TurnOrder()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject character;
            CharAndSpeed OrderListComponent;

            character = FindChildWithTag(Characters[i], "Character");
            if (character != null && character.GetComponent<Character>().isAlive)
            {
                OrderListComponent.Speed = character.GetComponent<Character>().attackS + (speedKoef * Random.Range(0, 11));
                OrderListComponent.character = character;
                TurnOrderList.Add(OrderListComponent);
            }


            character = FindChildWithTag(Enemies[i], "Enemies");
            if (character != null && character.GetComponent<Character>().isAlive)
            {
                OrderListComponent.Speed = character.GetComponent<Character>().attackS + (speedKoef * Random.Range(0, 11));
                OrderListComponent.character = character;
                TurnOrderList.Add(OrderListComponent);
            }
        }

        TurnOrderList.Sort((p, q) => p.Speed.CompareTo(q.Speed));
        TurnOrderList.Reverse();
    }

    public void SetNextActiveChar()
    {
        TurnOrderList[0].character.GetComponent<Character>().myTurn = false;
        TurnOrderList.RemoveAt(0);
        if (TurnOrderList.Count <= 0)
        {
            TurnOrder();
        }
        if(TurnOrderList[0].character is not null)
        {
            TurnOrderList[0].character.GetComponent<Character>().myTurn = true;
        }
    }

//*******************************************************************************************************************************************************************************************************
// Mouse methods


    private void SetMouse()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos2D = new Vector2(mousePos.x, mousePos.y);
    }
}
