using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesController : MonoBehaviour
{
    public GameObject myCamera, myDungeon;
    public float movespeed = 0.01f;
    float yoffset =0;
    float speed = 0.0015f;
    bool up = true;
    int hallstanding;
    Rigidbody2D rigidBody;
    DungeonController dungeon;
    void Start(){
        rigidBody = GetComponent<Rigidbody2D>();
        dungeon = myDungeon.GetComponent<DungeonController>();
    }

    void Update(){
        move_vertical();
        hallstanding = (int)Mathf.Floor((transform.position.x+11.25f)/22.5f);
        dungeon.hallstanding = hallstanding;
        myCamera.transform.position = new Vector3(transform.position.x,myCamera.transform.position.y,myCamera.transform.position.z);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GateFrom")
        {
            dungeon.goLast = true;
        }
        if (collision.tag == "GateTo")
        {
            dungeon.goNext = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GateFrom")
        {
            dungeon.goLast = false;
        }
        if (collision.tag == "GateTo")
        {
            dungeon.goNext = false;
        }
    }





    private void move_vertical(){
        if (up){
            if (yoffset < 0.05f)
            {
                transform.position += new Vector3(0,speed,0);
                yoffset += speed;
                return;
            }
            up = false;
            return;
        }
        if (yoffset > -0.05f)
        {
            transform.position += new Vector3(0,-speed,0);
            yoffset -= speed;
            return;
        }
        up = true;
        return;
       }


    public void move_forward(){
        transform.position += new Vector3(movespeed,0,0);    
    }
    public void move_backward(){
       transform.position += new Vector3(-movespeed,0,0);
    }
    

  
}
