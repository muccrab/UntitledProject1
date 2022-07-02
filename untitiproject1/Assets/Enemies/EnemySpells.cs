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
        spell1use();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void spell1use()
    {
        int IndexOfTarget = FindTarget(0, 2);
        if(IndexOfTarget != 20)
        {
            positions[IndexOfTarget].GetComponentInChildren<Character>().health -= 20;
        }
        
        
        //ResetTargets();
    }



    private int FindTarget(int min, int max)
    {
        int target;
        bool possible = false;

        for (int i = min; i < max; i++)
        {
            
            if(GameController.FindChildWithTag(positions[i], "Character") != null)
            {
                possible = true;
                break;
            }
        }

        if (possible)
        {
            do
            {
                target = Random.Range(min, max + 1);
            }
            while (GameController.FindChildWithTag(positions[target], "Character") == null);
        }
        else
        {
            target = 20;
        }

        return target;

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


}
