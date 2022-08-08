using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpells : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void spell1use()
    {
        GameController.EnemyFound enemyFound = FindTarget(0, 2);
        if (enemyFound.found)
        {
            DealDMG(enemyFound.pos, 20);
            transform.parent.parent.GetComponent<GameController>().Characters[enemyFound.pos].GetComponentInChildren<Character>().checkDeath();
            GoNextChar();
            
        }
    }



    private GameController.EnemyFound FindTarget(int min, int max)
    {
        GameController.EnemyFound enemy;
        enemy.pos = 0;
        enemy.found = false;

        for (int i = min; i <= max; i++)
        {
            
            if(GameController.FindChildWithTag(transform.parent.parent.GetComponent<GameController>().Characters[i], "Character") != null)
            {
                enemy.found = true;
                break;
            }
        }

        if (enemy.found)
        {
            do
            {
                enemy.pos = Random.Range(min, max + 1);
            }
            while (GameController.FindChildWithTag(transform.parent.parent.GetComponent<GameController>().Characters[enemy.pos], "Character") == null);
        }

        return enemy;

    }


    private void DealDMG(int who, int dmg)
    {
        transform.parent.parent.GetComponent<GameController>().Characters[who].GetComponentInChildren<Character>().health -= dmg;
    }


    private void GoNextChar()
    {
        transform.parent.parent.GetComponent<GameController>().SetNextActiveChar();
    }
}
