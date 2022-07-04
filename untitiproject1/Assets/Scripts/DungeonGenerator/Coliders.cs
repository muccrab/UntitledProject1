using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coliders : MonoBehaviour
{

    public bool collied = false;
    void OnTriggerStay2D(Collider2D terc){
        if (terc.tag=="HallTag")
        {
            //Debug.Log("Collision on "+name);
            collied = true;
        }
    }
}

