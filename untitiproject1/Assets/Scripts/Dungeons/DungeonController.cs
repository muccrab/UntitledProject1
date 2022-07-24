using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonController : MonoBehaviour
{
    public GameObject[] startHall, middleHall, endHall, Rooms;
    public GameObject lButton,uButton,rButton,dButton,fromButton,toButton;
    public GameObject Heroes;
    public string Selected = "r0";
    public int hallsize = 1, hallstanding = 0;
    public string from,to;
    public string left,up,right,down;
    public bool type = true;
    public bool holdBackward = false, holdForward = false;
    public bool generate = false; 
    Tile SelectedTile=null;
    
    
    void Update(){
        if (SelectedTile is null || SelectedTile.getName()!=Selected)
        if (LoadController.Dungeon.ContainsKey(Selected))
        {
            SelectedTile = LoadController.Dungeon[Selected];
            left = SelectedTile.getLeft();
            up = SelectedTile.getUp();
            right = SelectedTile.getRight();
            down = SelectedTile.getDown();
            from = SelectedTile.getFrom();
            to = SelectedTile.getTo();
            type = SelectedTile.type;
            if (generate) spawnRooms();
            generate = false;
        }
        if (!type)
        {
            lButton.SetActive(false);
            uButton.SetActive(false);
            rButton.SetActive(false);
            dButton.SetActive(false);
            if (from is null)   fromButton.SetActive(false);
                else    fromButton.SetActive(true);
            if (to is null)   toButton.SetActive(false);
                else    toButton.SetActive(true);
        }
        else{
            fromButton.SetActive(false);
            toButton.SetActive(false);
            if (left is null)   lButton.SetActive(false);
                else    lButton.SetActive(true);
            if (up is null)   uButton.SetActive(false);
                else    uButton.SetActive(true);
            if (right is null)   rButton.SetActive(false);
                else    rButton.SetActive(true);
            if (down is null)   dButton.SetActive(false);
                else    dButton.SetActive(true);
        }
        
        if (holdForward) Heroes.GetComponent<HeroesController>().move_forward();
        if (holdBackward) Heroes.GetComponent<HeroesController>().move_backward();
        if (Selected[0]=='h') Selected = Selected.Substring(0,3) + hallstanding;
    }

    private void spawnRooms()
    {
        hallsize = 1;
        if (Selected[0] == 'r')
        {
            NonUnityMethods.DestroyAll(GameObject.FindGameObjectsWithTag("Rooms"));
            Instantiate(
                Rooms[Random.Range(0,Rooms.Length)],
                new Vector3(0.25f,902.4f,100f),
                Quaternion.identity);
            hallsize = 1;
            return;
        }
        if (Selected[0]=='h')
        {
            string hallID = Selected.Substring(0,3);
            NonUnityMethods.DestroyAll(GameObject.FindGameObjectsWithTag("Rooms"));
            Instantiate(
                startHall[Random.Range(0,startHall.Length)],
                new Vector3(0.25f,902.4f,100f),
                Quaternion.identity);
            while (LoadController.Dungeon.ContainsKey(hallID+(hallsize+1)))
            {
                Instantiate(
                    middleHall[Random.Range(0,middleHall.Length)],
                    new Vector3(0.25f+22.5f*hallsize,902.4f,100f),
                    Quaternion.identity);
                hallsize++;
            }
            Instantiate(
                    endHall[Random.Range(0,endHall.Length)],
                    new Vector3(0.25f+22.5f*hallsize,902.4f,100f),
                    Quaternion.identity);
                hallsize++;
            return;
        }
    }




    public void pushLeft(){ Selected = left; generate = true;}
    public void pushUp(){ Selected = up; generate = true;}
    public void pushRight(){ Selected = right; generate = true;}
    public void pushDown(){ Selected = down; generate = true;}
    public void pushFrom(){ Selected = from; generate = true;}
    public void pushTo(){ Selected = to; generate = true;}
    public void pushBackward() { holdBackward = true;}
    public void pushForward() { holdForward = true;}
    public void stopBackward() { holdBackward = false;}
    public void stopForward() { holdForward = false;}

}
