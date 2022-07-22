using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesController : MonoBehaviour
{
    public float movespeed = 0.01f;
    float yoffset =0;
    float speed = 0.0015f;
    bool up = true;
    void Update(){
       if (up){
        if (yoffset < 0.05f)
        {
            transform.position += new Vector3(0,speed,0);
            yoffset += speed;
        }
        else up = false;
       }
       else{
        if (yoffset > -0.05f)
        {
            transform.position += new Vector3(0,-speed,0);
            yoffset -= speed;
        }
        else up = true;
       }
    }
    public void move_forward(){
        transform.position += new Vector3(movespeed,0,0);
    }
    public void move_backward(){
        transform.position += new Vector3(-movespeed,0,0);
    }
  
}
