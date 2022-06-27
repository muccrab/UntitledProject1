using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharActionButtons : MonoBehaviour
{

    public CharActionMenu charActionMenu;


    public Sprite[] positionSprites = new Sprite[10];

    public SpriteRenderer mutationTreatmentHolder;


    public void mutation()
    {
       int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;

       Debug.Log(arrayPosition);

       mutationTreatmentHolder.sprite = positionSprites[arrayPosition];
    }

}
