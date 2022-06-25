using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

	public GameObject[] bottomRooms;  // polia kde sa daju roomky ktore sa budu spawnovat 
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRoom;  //roomka na uzatvorenie miestnosti

	public List<GameObject> rooms; //list kde sa pridavaju roomky ktore sa spawnu

	public float waitTime;
	private bool spawnedBoss;
	public GameObject boss;

	void Update()
	{

		if (waitTime <= 0 && spawnedBoss == false)
		{
			for (int i = 0; i < rooms.Count; i++)
			{
				if (i == rooms.Count - 1) // spawne bossa ked pocet roomiek sa naplni
				{
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
				}
			}
		}
		else
		{
			waitTime -= Time.deltaTime;
		}
	}
}
