using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharSpells : MonoBehaviour
{

    private int CurrentSpell = 0;



    private void Start()
    {

    }

    private void Update()
    {
        useSpells();
    }



    #region spells
    public void spell1()                   
    {
        SetActiveSpell(1);
        SingleTargetSpell();
        SetTargetable(0, 2);
    }


    private void spell1use()                // treba urobit vlastnu classu pre vsetky use spelly kde bude to iste len to bude zamerane na jednotlive classy !!! nezabudni
    {                                       // Takto treba potom robit spelly ( Pattern )
        if (CurrentSpell == 1)
        {
            GameController.EnemyFound enemyFound = GetGameController().GetEnemy();
            if (enemyFound.found)
            {
                SpellReset();
                DealDMG(enemyFound.pos, 20);
                GoNextChar();
            }
        }

    }



    public void spell2()
    {
        SetActiveSpell(2);
        SingleTargetSpell();
        SetTargetableAlly(0, 3);
    }

    private void spell2use()
    {
        if (CurrentSpell == 2)
        {
            GameController.EnemyFound AllyFound = GetGameController().GetAlly();
            if (AllyFound.found)
            {
                SpellReset();
                Heal(AllyFound.pos, 20);
                GoNextChar();
            }
        }

    }

    public void spell3()
    {
        SetActiveSpell(3);
        AoeSpell();
        SetTargets(0, 1);
    }

    private void spell3use()
    {
        if (CurrentSpell == 3)
        {   
            if (GetGameController().AoeSpellUseEnemy())
            {
                SpellReset();
                DealAoeDMG(0, 1, 10);
                GoNextChar();
            }
        }

    }

    public void spell4()
    {
        SetActiveSpell(4);
    }

    private void spell4use()
    {
        if (CurrentSpell == 4)
        {
            
        }

    }

    public void spell5()
    {
        SetActiveSpell(5);
    }

    private void spell5use()
    {
        if (CurrentSpell == 5)
        {
            
        }

    }

    public void spell6()
    {
        CurrentSpell = 6;
    }

    private void spell6use()
    {
        if (CurrentSpell == 6)
        {
            
        }

    }

    public void spell7()
    {
        CurrentSpell = 7;
    }

    private void spell7use()
    {
        if (CurrentSpell == 7)
        {
            
        }

    }

    public void spell8()
    {
        CurrentSpell = 8;
    }

    private void spell8use()
    {
        if (CurrentSpell == 8)
        {
            
        }

    }

    public void spell9()
    {
        CurrentSpell = 9;
    }

    private void spell9use()
    {
        if (CurrentSpell == 9)
        {
            
        }

    }

    private void useSpells()
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

    #endregion spells



    private void DealDMG(int who, int dmg)
    {
        
            GetGameController().Enemies[who].GetComponentInChildren<Character>().health -= dmg;
            GetGameController().Enemies[who].GetComponentInChildren<Character>().checkDeath();
        
    }
    private void DealAoeDMG(int min, int max, int dmg)
    {
        for(int i = min; i <= max; i++)
        {
            DealDMG(i, 10);
        }
    }

    private void SetTargetable(int min, int max)
    {
        GetGameController().ResetTargets();
        GetGameController().SetTargetable(min, max);
    }

    private void SetTargets(int min, int max)
    {
        GetGameController().ResetTargets();
        GetGameController().SetTargets(min, max);
    }

    private void SetTargetableAlly(int min, int max)
    {
        GetGameController().ResetTargets();
        GetGameController().SetTargetableAlly(min, max);
    }
    private void SetTargetsAlly(int min, int max)
    {
        GetGameController().ResetTargets();
        GetGameController().SetTargetsAlly(min, max);
    }


    private void GoNextChar()
    {
        GetGameController().SetNextActiveChar();
    }

    private void Heal(int who, int value)
    {
        GetGameController().Characters[who].GetComponentInChildren<Character>().Heal(value);
    }

    private GameController GetGameController()
    {
        return transform.parent.parent.GetComponent<GameController>();
    }

    private void SingleTargetSpell()
    {
        GetGameController().DisableAoe();
    }

    private void AoeSpell()
    {
        GetGameController().ActivateAoe();
    }

    private void SetActiveSpell(int spell)
    {
        SpellReset();
        CurrentSpell = spell;
    }

    private void SpellReset()
    {
        CurrentSpell = 0;
    }


}

