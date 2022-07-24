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
    bool fromGateOpen = false, toGateOpen = false;
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");
        /*
        if (collision.gameObject.name == "Gate")
        {
            if (collision.gameObject.tag == "GateFrom"){
                fromGateOpen = true;
                Debug.Log("From Gate Openned");
            }
            if (collision.gameObject.tag == "GateTo"){
                toGateOpen = true;
                Debug.Log("To Gate Openned");
            }
        }*/

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Avoided");
        /*
        if (collision.gameObject.name == "Gate")
        {
            if (collision.gameObject.tag == "GateFrom"){
                fromGateOpen = false;
                Debug.Log("From Gate Clossed");
            }
            if (collision.gameObject.tag == "GateTo"){
                toGateOpen = false;
                Debug.Log("To Gate Clossed");
            }
        }*/
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
