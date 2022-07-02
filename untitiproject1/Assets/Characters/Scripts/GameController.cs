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
    
    private bool endC;
    private bool endD;

    const int speedKoef = 10;

    public GameObject[] Enemies;
    public GameObject[] Characters;

    List<CharAndSpeed> TurnOrderList = new List<CharAndSpeed>();


    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        TurnOrder();
        foreach(CharAndSpeed character in TurnOrderList)
        {
            i++;
            Debug.Log(character.Speed);
            Debug.Log(character.character.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveForv();
        CombatEnd();
        if (endD)
        {
            Debug.Log("DungeonEnd");
        }
        if(endC)
        {
            Debug.Log("CombatEnd");
        }
    }


    private void TurnOrder()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject character;
            CharAndSpeed OrderListComponent;

            character = FindChildWithTag(Characters[i], "Character");
            if (character != null)
            {
                OrderListComponent.Speed = character.GetComponent<Character>().attackS + (speedKoef * Random.Range(0, 11));
                OrderListComponent.character = character;
                TurnOrderList.Add(OrderListComponent);
            }


            character = FindChildWithTag(Enemies[i], "Enemies");
            if (character != null)
            {
                OrderListComponent.Speed = character.GetComponent<Enemy>().attackS + (speedKoef * Random.Range(0, 11));
                OrderListComponent.character = character;
                TurnOrderList.Add(OrderListComponent);
            }
        }

        TurnOrderList.Sort((p, q) => p.Speed.CompareTo(q.Speed));
        TurnOrderList.Reverse();
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
                if(Enemy.GetComponent<Enemy>().isAlive)
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
}
