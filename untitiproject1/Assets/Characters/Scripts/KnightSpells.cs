using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KnightSpells : MonoBehaviour
{
    public Sprite[] spellIcons;
    public GameObject[] positions;
    public bool[] target = { false, false, false, false };
    public bool[] targetable = { false, false, false, false };

    private int CurrentSpell = 0;

    private bool enemyFound = false;

    Vector3 mousePos;
    Vector2 mousePos2D;
    private void Start()
    {

    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos2D = new Vector2(mousePos.x, mousePos.y);
        spell1use();
        EnemyPointedAt();
        moveForv();
    }




    public void spell1()
    {
        CurrentSpell = 1;
        SetTargetable(0, 3);
    }


    private void spell1use()
    {
        if (CurrentSpell == 1)
        {
            int pos = GetEnemy();
            if (enemyFound)
            {
                CurrentSpell = 0;
                enemyFound = false;
                positions[pos].GetComponentInChildren<Enemy>().health -= 20;
                ResetTargets();
            }
        }

    }

    public int GetEnemy()
    {
        int pos = 0;

        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < 4; i++)
            {
                if (FindChildWithTag(positions[i], "Enemies") != null && targetable[i])
                {
                    if (positions[i].GetComponentInChildren<BoxCollider2D>().bounds.Contains(mousePos2D))
                    {
                        pos = i;
                        enemyFound = true;
                    }
                }
            }
        }
        return pos;
    }

    public void SetTargetable(int min, int max)
    {
        for (int i = min; i < max; i++)
        {
            if(FindChildWithTag(positions[i], "Enemies") != null)
            {
                targetable[i] = true;
                positions[i].transform.Find("TargetablePointer").gameObject.SetActive(true);
            }
        }
    }

    private void EnemyPointedAt()
    {

        //  Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        for (int i = 0; i < 4; i++)
        {
            if (FindChildWithTag(positions[i], "Enemies") != null) 
            {
                if (positions[i].GetComponentInChildren<BoxCollider2D>().bounds.Contains(mousePos2D))
                {
                    if (targetable[i] == true)
                    {
                        positions[i].transform.Find("TargetPointer").gameObject.SetActive(true);
                    }
                }
                else
                {
                    positions[i].transform.Find("TargetPointer").gameObject.SetActive(false);
                }

            }
        }
    }

    public void ResetTargets()
    {
        for (int i = 0; i < 4; i++)
        {
            targetable[i] = false;
            target[i] = false;
            positions[i].transform.Find("TargetablePointer").gameObject.SetActive(false);
            positions[i].transform.Find("TargetPointer").gameObject.SetActive(false);
        }
    }

    public void moveForv()
    {
        for (int i = 0; i < 4; i++)
        {
            if (FindChildWithTag(positions[i], "Enemies") == null)
            {
                for (int x = i + 1; x < 4; x++)
                {
                    if (FindChildWithTag(positions[x], "Enemies") != null)
                    {
                        GameObject clone = FindChildWithTag(positions[x], "Enemies");
                        clone.transform.SetParent(positions[i].transform);
                        clone.transform.localPosition = new Vector2(0, clone.transform.localPosition.y);
                        break;
                    }
                }
            }
        }
        
    }

    GameObject FindChildWithTag(GameObject parent, string tag)
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

