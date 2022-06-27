using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using TMPro;

public class CharActionMenu : MonoBehaviour
{
    public bool charActionMenuIsOpen = false;
    public GameObject charActionMenuObject;

    public TextMeshProUGUI charPositionText;
    public TextMeshProUGUI stat1;


    public string buttonName = "0";
    public string lastPressed = "-1";


    public GameObject hospital;
    public GameObject tavern;
    public GameObject church;
    public GameObject armory;


    public GameObject hospitalBtns;
    public GameObject tavernBtns;
    public GameObject churchBtns;
    public GameObject armoryBtns;


    void Update()
    {
        vypisCharActions(buttonName);
    }

    public void OpenCharActionMenu()
    {
        buttonName =  EventSystem.current.currentSelectedGameObject.name;

        if(lastPressed != buttonName)
        {
            charActionMenuObject.SetActive(true);

            lastPressed = buttonName;

            vypisCharActions(buttonName);

        }
        else if(lastPressed == buttonName)
        {
            buttonName = "0";
            lastPressed = "-1";
            charActionMenuObject.SetActive(false);
        }
    }

    public void vypisCharActions(string name)
    {
        charPositionText.text = name.ToString();
        stat1.text = name.ToString();

        if(hospital.activeSelf)
        {
            Debug.Log("hospital active");
            hospitalBtns.SetActive(true);

            tavernBtns.SetActive(false);
            churchBtns.SetActive(false);
            armoryBtns.SetActive(false);
        }
        else if(tavern.activeSelf)
        {
            Debug.Log("tavern active");
            tavernBtns.SetActive(true);

            hospitalBtns.SetActive(false);
            churchBtns.SetActive(false);
            armoryBtns.SetActive(false);
        }
        else if(church.activeSelf)
        {
            Debug.Log("church active");
            churchBtns.SetActive(true);

            hospitalBtns.SetActive(false);
            tavernBtns.SetActive(false);
            armoryBtns.SetActive(false);
        }
        else if(armory.activeSelf)
        {
            Debug.Log("armory active");
            armoryBtns.SetActive(true);

            hospitalBtns.SetActive(false);
            tavernBtns.SetActive(false);
            churchBtns.SetActive(false);
        }
        else
        {
            hospitalBtns.SetActive(false);
            tavernBtns.SetActive(false);
            churchBtns.SetActive(false);
            armoryBtns.SetActive(false);
        }

        ////TU SA BUDE PROGRAMOVAT CO SA VYPISE

        // 1. zatvorit jedno pri otvoreni druheho - DONE
        // 2. vysrat sa na kliknutie mimo zatvorenie - DONE
        // 3. stats pre cava button je univerzalny - DONE
        // 4. ci je otvoren hospital, tawern atd - DONE
        // 5. podla toho spravit buttons - DONE
        // 6. deaktivacia used button -
    }

    public void charStatsMenu()
    {
    }
}
