using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpells : MonoBehaviour
{
    public GameObject[] positions;

    public bool[] targetable = { false, false, false, false };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spell1use();
        moveForv();
    }

    private void spell1use()
    {
        positions[FindTarget(0,2)].GetComponentInChildren<Character>().health -= 20;
        //ResetTargets();
    }



    /*
    public void ResetTargets()
    {
        for (int i = 0; i < 4; i++)
        {
            targetable[i] = false;
        }
    }


    public void SetTargetable(int min, int max)
    {
        for (int i = min; i < max; i++)
        {
            if (KnightSpells.FindChildWithTag(positions[i], "Character") != null)
            {
                targetable[i] = true;
            }
        }
    }*/

    private int FindTarget(int min, int max)
    {
        int target;

        do
        {
            target = Random.Range(min, max + 1);
        }
        while (KnightSpells.FindChildWithTag(positions[target], "Character") == null);
       

        return target;

    }

    public void moveForv()
    {
        for (int i = 0; i < 4; i++)
        {
            if (KnightSpells.FindChildWithTag(positions[i], "Character") == null)
            {
                for (int x = i + 1; x < 4; x++)
                {
                    if (KnightSpells.FindChildWithTag(positions[x], "Character") != null)
                    {
                        GameObject clone = KnightSpells.FindChildWithTag(positions[x], "Character");
                        clone.transform.SetParent(positions[i].transform);
                        clone.transform.localPosition = new Vector2(0, clone.transform.localPosition.y);
                        break;
                    }
                }
            }
        }

    }
}
