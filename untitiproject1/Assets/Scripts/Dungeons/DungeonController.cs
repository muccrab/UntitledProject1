using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonController : MonoBehaviour
{
    public GameObject[] startHall, middleHall, endHall, Rooms;
    public GameObject lButton,uButton,rButton,dButton,fromButton,toButton,lastButton,nextButton;
    public GameObject Heroes;
    public string Selected = "r0";
    public int hallsize = 1, hallstanding = 0;
    public string from,to;
    public string left,up,right,down;
    public bool type = true;
    public bool holdBackward = false, holdForward = false;
    public bool goLast = false, goNext = false; //for hall movement controll, when you enter a gate
    public bool generate = true; 
    Tile SelectedTile=null;
    Classes.RoomNameDivided SelectedObj;
    
    void Start(){
        if(LoadController.location is not null) Selected = LoadController.location;
        else {Debug.Log("Jesus Christ what now?");}
    }
    void Update(){
        SelectedObj = new Classes.RoomNameDivided(Selected);
        Debug.Log ("Loaded Location -"+LoadController.location);
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
            if (generate) 
            {
                spawnRooms();
                if (SelectedObj.type=='h')
                    if (SelectedObj.hallNumber!=0)
                    {
                        Heroes.transform.position = new Vector3(22.5f*(hallsize-1), Heroes.transform.position.y, Heroes.transform.position.z);
                    }
                
                
            }
            generate = false;
        }
        if (!type)
        {
            lButton.SetActive(false);
            uButton.SetActive(false);
            rButton.SetActive(false);
            dButton.SetActive(false);
            
        }
        else{
            if (left is null)   lButton.SetActive(false);
                else    lButton.SetActive(true);
            if (up is null)   uButton.SetActive(false);
                else    uButton.SetActive(true);
            if (right is null)   rButton.SetActive(false);
                else    rButton.SetActive(true);
            if (down is null)   dButton.SetActive(false);
                else    dButton.SetActive(true);
        }

        lastButton.SetActive(goLast);
        nextButton.SetActive(goNext);

        if (holdForward) Heroes.GetComponent<HeroesController>().move_forward();
        if (holdBackward) Heroes.GetComponent<HeroesController>().move_backward();
        if (SelectedObj.type=='h') Selected = SelectedObj.type + SelectedObj.roomNumber.ToString()+ '-' + hallstanding;

        LoadController.location = Selected;
        LoadController.isInDungeon = true;
    }

    private void spawnRooms()
    {
        hallsize = 1;
        if (SelectedObj.type=='r')
        {
            Heroes.transform.position = new Vector3(0,Heroes.transform.position.y,Heroes.transform.position.z);
            NonUnityMethods.DestroyAll(GameObject.FindGameObjectsWithTag("Rooms"));
            Instantiate(
                Rooms[Random.Range(0,Rooms.Length)],
                new Vector3(0.25f,902.4f,100f),
                Quaternion.identity);
            hallsize = 1;
            return;
        }
        if (SelectedObj.type=='h')
        {
            string hallID = SelectedObj.type+SelectedObj.roomNumber.ToString()+'-';
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
    public void pushLast(){ Selected = from; generate = true;}
    public void pushNext(){ Selected = to; generate = true;}
    public void pushBackward() { holdBackward = true;}
    public void pushForward() { holdForward = true;}
    public void stopBackward() { holdBackward = false;}
    public void stopForward() { holdForward = false;}

}
