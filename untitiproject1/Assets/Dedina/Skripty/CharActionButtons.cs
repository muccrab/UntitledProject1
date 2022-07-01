using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharActionButtons : MonoBehaviour
{

    public CharActionMenu charActionMenu;


    public Sprite[] positionSprites = new Sprite[10];

    public SpriteRenderer mutationTreatmentHolder;



    public SpriteRenderer drinkHolder;
    public SpriteRenderer danceHolder;
    public SpriteRenderer eatHolder;


    public SpriteRenderer prayHolder;
    public SpriteRenderer confessHolder;
    public SpriteRenderer somethingHolder;




    public void mutation()
    {
       int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;

       Debug.Log(arrayPosition);

       mutationTreatmentHolder.sprite = positionSprites[arrayPosition];
    }

    public void drink()
    {
       int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;

       Debug.Log(arrayPosition);

       drinkHolder.sprite = positionSprites[arrayPosition];
    }

    public void dance()
    {
       int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;

       Debug.Log(arrayPosition);

       danceHolder.sprite = positionSprites[arrayPosition];
    }

    public void eat()
    {
       int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;

       Debug.Log(arrayPosition);

       eatHolder.sprite = positionSprites[arrayPosition];
    }

    public void pray()
    {
       int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;

       Debug.Log(arrayPosition);

       prayHolder.sprite = positionSprites[arrayPosition];
    }

    public void confess()
    {
       int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;

       Debug.Log(arrayPosition);

       confessHolder.sprite = positionSprites[arrayPosition];
    }

    public void something()
    {
       int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;

       Debug.Log(arrayPosition);

       somethingHolder.sprite = positionSprites[arrayPosition];
    }


}
