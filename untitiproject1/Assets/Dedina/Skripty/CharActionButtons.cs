using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CharActionButtons : MonoBehaviour
{

   public CharActionMenu charActionMenu;


   public Sprite[] positionSprites = new Sprite[10];

   public SpriteRenderer mutationTreatmentHolder;
   public SpriteRenderer recoveryHolder1;
   public SpriteRenderer recoveryHolder2;


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
      GameObject.Find("mutationTreatment").GetComponent<Button>().enabled = false;
   }

   public void recovery1()
   {
      int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;
      Debug.Log(arrayPosition);
      recoveryHolder1.sprite = positionSprites[arrayPosition];
      GameObject.Find("recovery1").GetComponent<Button>().enabled = false;
   }

   public void recovery2()
   {
      int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;
      Debug.Log(arrayPosition);
      recoveryHolder2.sprite = positionSprites[arrayPosition];
      GameObject.Find("recovery2").GetComponent<Button>().enabled = false;
   }

   public void drink()
   {
      int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;
      Debug.Log(arrayPosition);
      drinkHolder.sprite = positionSprites[arrayPosition];
      GameObject.Find("drink").GetComponent<Button>().enabled = false;
   }

   public void dance()
   {
      int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;
      Debug.Log(arrayPosition);
      danceHolder.sprite = positionSprites[arrayPosition];
      GameObject.Find("dance").GetComponent<Button>().enabled = false;
   }

   public void eat()
   {
      int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;
      Debug.Log(arrayPosition);
      eatHolder.sprite = positionSprites[arrayPosition];
      GameObject.Find("eat").GetComponent<Button>().enabled = false;
   }

   public void pray()
   {
      int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;
      Debug.Log(arrayPosition);
      prayHolder.sprite = positionSprites[arrayPosition];
      GameObject.Find("pray").GetComponent<Button>().enabled = false;
   }

   public void confess()
   {
      int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;
      Debug.Log(arrayPosition);
      confessHolder.sprite = positionSprites[arrayPosition];
      GameObject.Find("confess").GetComponent<Button>().enabled = false;
   }

   public void something()
   {
      int arrayPosition = Convert.ToInt32(charActionMenu.buttonName) - 1;
      Debug.Log(arrayPosition);
      somethingHolder.sprite = positionSprites[arrayPosition];
      GameObject.Find("something").GetComponent<Button>().enabled = false;
   }


}
