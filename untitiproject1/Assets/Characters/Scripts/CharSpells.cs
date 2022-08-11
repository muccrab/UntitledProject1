using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharSpells : MonoBehaviour
{

    private int CurrentSpell = 0;

    Vector3 mousePos;
    Vector2 mousePos2D;
    private void Start()
    {

    }

    private void Update()
    {
        spell1use();
        spell2use();
        spell3use();
        spell4use();
        spell5use();
        spell6use();
        spell7use();
        spell8use();
        spell9use();
    }




    public void spell1()
    {
        CurrentSpell = 1;
        SetTargets(0, 2);
    }


    private void spell1use()
    {
        if (CurrentSpell == 1)
        {
            GameController.EnemyFound enemyFound = transform.parent.parent.GetComponent<GameController>().GetEnemy();
            if (enemyFound.found)
            {
                CurrentSpell = 0;
                DealDMG(enemyFound.pos, 20);
                
                GoNextChar();
                transform.parent.parent.GetComponent<GameController>().ResetTargets();
            }
        }

    }



    public void spell2()
    {
        CurrentSpell = 2;

        SetTargets(0, 2);
    }

    private void spell2use()
    {
        if (CurrentSpell == 2)
        {
            GameController.EnemyFound enemyFound = transform.parent.parent.GetComponent<GameController>().GetEnemy();
            if (enemyFound.found)
            {
                CurrentSpell = 0;
                DealDMG(enemyFound.pos, 20);
                transform.parent.parent.GetComponent<GameController>().Enemies[enemyFound.pos].GetComponentInChildren<Character>().checkDeath();
                GoNextChar();
                transform.parent.parent.GetComponent<GameController>().ResetTargets();
            }
        }

    }

    public void spell3()
    {
        CurrentSpell = 3;

        SetTargets(0, 2);
    }

    private void spell3use()
    {
        if (CurrentSpell == 3)
        {
            GameController.EnemyFound enemyFound = transform.parent.parent.GetComponent<GameController>().GetEnemy();
            if (enemyFound.found)
            {
                CurrentSpell = 0;
                DealDMG(enemyFound.pos, 20);
                GoNextChar();
                transform.parent.parent.GetComponent<GameController>().ResetTargets();
            }
        }

    }

    public void spell4()
    {
        CurrentSpell = 4;

        SetTargets(0, 2);
    }

    private void spell4use()
    {
        if (CurrentSpell == 4)
        {
            GameController.EnemyFound enemyFound = transform.parent.parent.GetComponent<GameController>().GetEnemy();
            if (enemyFound.found)
            {
                CurrentSpell = 0;
                DealDMG(enemyFound.pos, 20);
                GoNextChar();
                transform.parent.parent.GetComponent<GameController>().ResetTargets();
            }
        }

    }

    public void spell5()
    {
        CurrentSpell = 5;

        SetTargets(0, 2);
    }

    private void spell5use()
    {
        if (CurrentSpell == 5)
        {
            GameController.EnemyFound enemyFound = transform.parent.parent.GetComponent<GameController>().GetEnemy();
            if (enemyFound.found)
            {
                CurrentSpell = 0;
                DealDMG(enemyFound.pos, 20);
                GoNextChar();
                transform.parent.parent.GetComponent<GameController>().ResetTargets();
            }
        }

    }

    public void spell6()
    {
        CurrentSpell = 6;

        SetTargets(0, 2);
    }

    private void spell6use()
    {
        if (CurrentSpell == 6)
        {
            GameController.EnemyFound enemyFound = transform.parent.parent.GetComponent<GameController>().GetEnemy();
            if (enemyFound.found)
            {
                CurrentSpell = 0;
                DealDMG(enemyFound.pos, 20);
                GoNextChar();
                transform.parent.parent.GetComponent<GameController>().ResetTargets();
            }
        }

    }

    public void spell7()
    {
        CurrentSpell = 7;

        SetTargets(0, 2);
    }

    private void spell7use()
    {
        if (CurrentSpell == 7)
        {
            GameController.EnemyFound enemyFound = transform.parent.parent.GetComponent<GameController>().GetEnemy();
            if (enemyFound.found)
            {
                CurrentSpell = 0;
                DealDMG(enemyFound.pos, 20);
                GoNextChar();
                transform.parent.parent.GetComponent<GameController>().ResetTargets();
            }
        }

    }

    public void spell8()
    {
        CurrentSpell = 8;

        SetTargets(0, 2);
    }

    private void spell8use()
    {
        if (CurrentSpell == 8)
        {
            GameController.EnemyFound enemyFound = transform.parent.parent.GetComponent<GameController>().GetEnemy();
            if (enemyFound.found)
            {
                CurrentSpell = 0;
                DealDMG(enemyFound.pos, 20);
                
                GoNextChar();
                transform.parent.parent.GetComponent<GameController>().ResetTargets();
            }
        }

    }

    public void spell9()
    {
        CurrentSpell = 9;
        Debug.Log(this.name);

        SetTargets(0, 2);
    }

    private void spell9use()
    {
        if (CurrentSpell == 9)
        {
            GameController.EnemyFound enemyFound = transform.parent.parent.GetComponent<GameController>().GetEnemy();
            if (enemyFound.found)
            {
                CurrentSpell = 0;
                DealDMG(enemyFound.pos, 20);
                GoNextChar();
                transform.parent.parent.GetComponent<GameController>().ResetTargets();
            }
        }

    }



    private void DealDMG(int who, int dmg)
    {
        transform.parent.parent.GetComponent<GameController>().Enemies[who].GetComponentInChildren<Character>().health -= dmg;
    }

    private void SetTargets(int min, int max)
    {
        transform.parent.parent.GetComponent<GameController>().ResetTargets();
        transform.parent.parent.GetComponent<GameController>().SetTargetable(min, max);
    }

    private void GoNextChar()
    {
        transform.parent.parent.GetComponent<GameController>().SetNextActiveChar();
    }


}

