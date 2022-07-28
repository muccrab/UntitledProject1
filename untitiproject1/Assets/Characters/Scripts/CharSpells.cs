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
    }




    public void spell1()
    {
        Debug.Log(transform.parent.name);
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
        Debug.Log(this.name);

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
                GoNextChar();
                transform.parent.parent.GetComponent<GameController>().ResetTargets();
            }
        }

    }



    private void DealDMG(int who, int dmg)
    {
        transform.parent.parent.GetComponent<GameController>().Enemies[who].GetComponentInChildren<Enemy>().health -= dmg;
    }

    private void SetTargets(int min, int max)
    {
        transform.parent.parent.GetComponent<GameController>().ResetTargets();
        transform.parent.parent.GetComponent<GameController>().SetTargetable(min, max);
    }

    private void GoNextChar()
    {
        transform.parent.parent.GetComponent<GameController>().nextTurn = true;
    }


}

