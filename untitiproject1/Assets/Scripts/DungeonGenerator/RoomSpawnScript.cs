using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnScript : MonoBehaviour
{
    public int openingDirection;
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    private RoomTemplates templates;
    private int randNum;
    private bool spawned = false;
    private float Timer = 5f;
    private bool timePassed = true;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("RoomSpawn", 0.1f);
    }

    private void Update()
    {
        if (Timer != 0)//odpocet pre sapwnovanie roomiek
        {
            Timer = Timer - Time.deltaTime;
            timePassed = false;
        }
        else
        {
            timePassed = true;
        }
    }

    void RoomSpawn()// ak cas neuplinul tak sapwnuje roomky nahodne 
    {
        if (timePassed == false)
        {
            if (spawned == false)
            {
                if (openingDirection == 1)//need room with bottom door
                {
                    randNum = UnityEngine.Random.Range(0, templates.bottomRooms.Length); // generovanie nahodneho cilsa 
                    Instantiate(templates.bottomRooms[randNum], transform.position, templates.bottomRooms[randNum].transform.rotation); // sapwnovanie objektu na danaom objekte v hre pomocou nahodneho cisla sa vyberie roomka 
                }
                else if (openingDirection == 2)//need room with top door
                {
                    randNum = UnityEngine.Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[randNum], transform.position, templates.topRooms[randNum].transform.rotation);
                }
                else if (openingDirection == 3)//need room with left door
                {
                    randNum = UnityEngine.Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[randNum], transform.position, templates.leftRooms[randNum].transform.rotation);
                }
                else if (openingDirection == 4)//need room with right door
                {
                    randNum = UnityEngine.Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[randNum], transform.position, templates.rightRooms[randNum].transform.rotation);
                }
                spawned = true;
            }
        }
    }//roomSpawn

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoomSpawnPoint"))
        {
            if (other.GetComponent<RoomSpawnScript>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }

}//mono
