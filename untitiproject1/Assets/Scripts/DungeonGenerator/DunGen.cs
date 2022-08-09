using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DunGen : MonoBehaviour
{
    public GameObject parent; //parent so it is inside one Gameobject and that I can disable it
    public GameObject RoomTile; //Tile for Room 
    public GameObject Tile; //Tile for Hall
    public Vector2Int mainRange; //range how far it should generate main road
    public Vector2Int brenchRange; //range how far it should generate branches
    public int Radius; //radius that sets hall length
    public int mainHops=0;
    public int tileLength = 10;
    HashSet<Vector2> tilePositions = new HashSet<Vector2>(); //positions. Why am I using this shit...easier to check
    Dictionary<string,Tile> Tiles = new Dictionary<string, Tile>(); //For movement between tiles(also for saves)..now I know I'm using shit ton of resources, but Fuck you lol

    void Start()
    {
        if (LoadController.Dungeon.Count<=0) Generate();
        else Replicate();
    }

    void Generate(){
        tileLength = (int)Tile.GetComponent<SpriteRenderer>().bounds.size.x; //Obtains the Length of Tile
        mainHops = Random.Range(mainRange.x+0,mainRange.y+1); //Gets Hops of Main Road
        
        
        #region Main Road Generator
        //Array of main Road stops
        TurnPoint[] mainPoints = new TurnPoint[mainHops];
        //Generates turnpoints (Rooms) on the main path
        for(int i = mainHops-1; i >= 0; i--)
        {
            if (i != mainHops-1)
            {
                mainPoints[mainHops-i-1] = new TurnPoint(mainPoints[mainHops-2-i].nextHop,i,0.5f,Radius,tileLength,true);
            }
            else
            {
                mainPoints[mainHops-i-1] = new TurnPoint(new Vector2Int(0,0),i,0.5f,Radius,tileLength,true); 
            }
        }

        //Generates Halls between rooms
        for (int j = 0; j < mainHops; j++)
        {
            //changes turnpoints into room tiles on the map
            TurnPoint tp = mainPoints[j];
            GameObject tile = Instantiate(RoomTile);
            tile.name = "r"+j;
            tile.transform.position = new Vector2(tp.position.x,tp.position.y);
            tile.transform.parent = parent.transform;
            tp.HallCode = tile.GetComponent<HallScript>();
            tilePositions.Add(tile.transform.position);
            Tiles.Add(tile.name,new Tile(tile.name, (int)tile.transform.position.x,(int)tile.transform.position.y,""));
            //generates hallpoints between the rooms
            if (j!=mainHops-1)
            {
                TurnPoint ntp = mainPoints[j+1]; //next turnpoint
                int tilesBetweenLength = (int)Mathf.Abs((ntp.position.x-tp.position.x)/tileLength)+(int)Mathf.Abs((ntp.position.y-tp.position.y)/tileLength); //number of tiles between rooms
                Vector2[] tilesBetween = new Vector2[tilesBetweenLength]; //data structure to store positions of halls
                tilesBetween[0].y = tp.position.y; 
                int tIndex = 0;
                
                //x line
                int NToffset = (int)Mathf.Sign(ntp.position.x-tp.position.x)*tileLength;
                for(int i = tp.position.x+NToffset; nextPointCheck(i,tp.position.x,ntp.position.x,null); i+=NToffset)
                {
                    if (tIndex==0) tilesBetween[0].y = tp.position.y;
                    else tilesBetween[tIndex].y = tilesBetween[tIndex-1].y;
                    tilesBetween[tIndex].x = i;
                    tIndex++;
                }

                //y line
                NToffset = (int)Mathf.Sign(ntp.position.y-tp.position.y)*tileLength;
                for(int i = tp.position.y+NToffset; nextPointCheck(i,tp.position.y,ntp.position.y-NToffset,NToffset); i+=NToffset)
                {
                    if (tIndex==0) tilesBetween[tIndex].x = tp.position.x;
                    else tilesBetween[tIndex].x = tilesBetween[tIndex-1].x;
                    tilesBetween[tIndex].y = i;
                    tIndex++;
                }


                //creates Tiles for Halls
                for(int i = 0; i < tilesBetweenLength; i++)
                {
                    if (tilesBetween[i].x != 0 || tilesBetween[i].y != 0)
                    {
                        GameObject tilebetween = Instantiate(Tile);
                        tilebetween.name = "h"+j+"-"+i;
                        tilebetween.transform.position = new Vector2(tilesBetween[i].x,tilesBetween[i].y);
                        tilebetween.transform.parent = parent.transform;
                        tilePositions.Add(tilebetween.transform.position);
                        Tiles.Add(tilebetween.name,new Tile(tilebetween.name, (int)tilebetween.transform.position.x,(int)tilebetween.transform.position.y,"",i));
                        if (i==0) Tiles[tilebetween.name].setFrom(tile.name);
                        else Tiles[tilebetween.name].setFrom("h"+j+"-"+(int)(i-1));
                        if (i>=tilesBetweenLength-2) Tiles[tilebetween.name].setTo("r"+(int)(j+1));
                        else Tiles[tilebetween.name].setTo("h"+j+"-"+(int)(i+1));
                    }
                }
            }
        }
        #endregion
        #region Brech Generator
        int counter = mainHops;
        //for each main point checks if it is branchable and creates brench
        for(int k = 0; k < mainPoints.Length;k++)
        {
            TurnPoint point = mainPoints[k];
            if (point.branchable)
            {
                bool blockedroad = false;
                int BrechLength = Random.Range(brenchRange.x,brenchRange.y+1);
                TurnPoint[] BrenchPoints = new TurnPoint[BrechLength];
                Vector2Int newTile = point.HallCode.getNewTile(point.position,tileLength,tilePositions);
                for(int i = 0; i < BrechLength; i++)
                {
                    int tileRange = (int)Random.Range(Radius,2*Mathf.Sqrt(Radius*Radius/2));
                    for (int j = 0;j < tileRange;j++)
                    {                        
                        GameObject summon = Instantiate(Tile);
                        summon.transform.position = (Vector2)newTile;
                        summon.name = "h"+counter+"-"+j;
                        summon.transform.parent = parent.transform;
                        tilePositions.Add(summon.transform.position);
                        newTile = summon.GetComponent<HallScript>().getNewTile(newTile,tileLength,tilePositions);
                        if (newTile == Vector2Int.zero)
                        {
                            newTile = new Vector2Int ((int)summon.transform.position.x,(int)summon.transform.position.y);
                            Destroy(summon);
                            blockedroad = true;
                            break;
                        }
                        Tiles.Add(summon.name,new Tile(summon.name, (int)summon.transform.position.x,(int)summon.transform.position.y,"",i));
                        if (j==0) 
                        {
                            if (i==0) Tiles[summon.name].setFrom("r"+k);
                            else Tiles[summon.name].setFrom("r"+(int)(counter-1));
                        }
                        else Tiles[summon.name].setFrom("h"+counter+"-"+(int)(j-1));
                        if (j==tileRange-1) Tiles[summon.name].setTo("r"+counter);
                        else Tiles[summon.name].setTo("h"+counter+"-"+(int)(j+1));
                    }
                    BrenchPoints[i] = new TurnPoint(newTile,0,0.5f,Radius,tileLength,false);
                    GameObject Room = Instantiate(RoomTile);
                    Room.transform.position = (Vector2)newTile;
                    Room.name = "r"+counter;
                    Room.transform.parent = parent.transform;
                    tilePositions.Add(Room.transform.position);
                    newTile = Room.GetComponent<HallScript>().getNewTile(newTile,tileLength,tilePositions);
                    BrenchPoints[i].HallCode = Room.GetComponent<HallScript>();
                    Tiles.Add(Room.name,new Tile(Room.name, (int)Room.transform.position.x,(int)Room.transform.position.y,""));
                    counter++;
                    if (blockedroad) break;
                }

            }
        }
        #endregion
        //gets directions for rooms
        for (int i = 0;Tiles.ContainsKey("r"+i);i++){
            string tilename = "r"+i;
            string[] directions = getAvailibleDirections(tilename);
            Tiles[tilename].setLeft(directions[0]);
            Tiles[tilename].setUp(directions[1]);
            Tiles[tilename].setRight(directions[2]);
            Tiles[tilename].setDown(directions[3]);
        }
        LoadController.Dungeon = Tiles;

        //DEBUG ONLY
        foreach(var t in Tiles.Values){
            if (t.type)
            Debug.Log(t.getName() +" = "+ t.getLeft() +" / " + t.getUp() +" / " + t.getRight() + " / " + t.getDown());
            //else
            //Debug.Log(t.getName() +" - "+ t.getFrom() +" - " + t.getTo());
            //Debug.Log(t.getName() + " = " +t.posx+" - "+t.posy);
        } 
    }

    void Replicate(){
        Tiles = LoadController.Dungeon;
        foreach(Tile tile in Tiles.Values)
        {
            GameObject GO;
            if (tile.type) GO = Instantiate(RoomTile);
            else GO = Instantiate(Tile);
            GO.name = tile.getName();
            GO.transform.position = new Vector3(tile.posx,tile.posy,0f);
            GO.transform.parent = parent.transform;
        }
    }


    bool nextPointCheck(int pos, int lastpos, int nextpos, int? offset)
    {
        if (offset is not null) if (nextpos==lastpos-offset)return false;
        else if (nextpos==lastpos)return false;
        if (lastpos<nextpos)
        {
            if (pos <= nextpos) return true;
            return false;
        }
        if (pos >= nextpos) return true;
            return false;
    }
    //returns array with hallnames next to room
    string[] getAvailibleDirections(string room){
        string[] directions = new string[4];
        int roomnum = int.Parse(room.Substring(1));
        if (Tiles.ContainsKey(room))
        {
            Vector2Int location = new Vector2Int(Tiles[room].posx,Tiles[room].posy);
            if (tilePositions.Contains(location+new Vector2Int(-tileLength,0)))
            {
                directions[0] = getTileonLocation(location+new Vector2Int(-tileLength,0),roomnum,mainHops);
            }
            location = new Vector2Int(Tiles[room].posx,Tiles[room].posy);
            if (tilePositions.Contains(location+new Vector2Int(0,tileLength)))
            {
                directions[1] = getTileonLocation(location+new Vector2Int(0,tileLength),roomnum,mainHops);
            }
            location = new Vector2Int(Tiles[room].posx,Tiles[room].posy);
            if (tilePositions.Contains(location+new Vector2Int(tileLength,0)))
            {
                directions[2] = getTileonLocation(location+new Vector2Int(tileLength,0),roomnum,mainHops);
            }
            location = new Vector2Int(Tiles[room].posx,Tiles[room].posy);
            if (tilePositions.Contains(location+new Vector2Int(0,-tileLength)))
            {
                directions[3] = getTileonLocation(location+new Vector2Int(0,-tileLength),roomnum,mainHops);
            }
        }
        return directions;
    }
    string getTileonLocation(Vector2Int location,int roomnum, int mainroomsize)
    {
        int fromID;
        string tilename;
        //Checks where it came from
        if (roomnum < mainroomsize) fromID = roomnum-1;
        else fromID = roomnum;
        if (fromID>=0){
            int counter = 0;
            while (Tiles.ContainsKey("h"+fromID+"-"+counter))
            {
                tilename = "h"+fromID+"-"+counter;
                counter++;
                if (Tiles[tilename].posx==location.x && Tiles[tilename].posy==location.y) return tilename; 
            }
            
        }
        //Checks where its going
        fromID++;
        tilename = "h"+fromID+"-"+0;
        if (Tiles.ContainsKey(tilename))
            if (Tiles[tilename].posx==location.x && Tiles[tilename].posy==location.y) return tilename; 
        //CHecks for branches
        fromID = mainroomsize;
        while (Tiles.ContainsKey("r"+fromID))
        {
            tilename = "h"+fromID+"-"+0;
            fromID++;
            if (Tiles.ContainsKey(tilename))
                if (Tiles[tilename].posx==location.x && Tiles[tilename].posy==location.y) return tilename; 
        }
        return null;
    }

}

class TurnPoint{

    public Vector2Int position;
    public Vector2Int nextHop;
    public int hopCount; //hopcount for main branch
    public bool branchable = false;
    int Radius;
    int tileLength;
    public Vector2Int InOut;
    public HallScript HallCode;

    public TurnPoint(Vector2Int position,int hopCount, float brachChance, int Radius, int tileLength, bool isMain, int In = 1, int Out = 3){
        this.position.x = position.x;
        this.position.y = position.y;
        this.hopCount = hopCount;
        this.Radius = Radius;
        this.tileLength = tileLength;
        this.branchable = Random.value < brachChance;
        this.InOut.x = In;
        this.InOut.y = Out;
        if (isMain)
        {
            if(hopCount>0)
            {
                nextHop = this.newPoint();
            }
        }
    }
    Vector2Int newPoint(){
        Vector2Int nextHopP = new Vector2Int();

        //Gets left corner of finishing tile
        nextHopP.x = Random.Range(position.x+tileLength*2,position.x+Radius); 
        nextHopP.x = nextHopP.x - (nextHopP.x % tileLength); 
        
        nextHopP.y = Random.Range(position.y-Radius,position.y+Radius);
        nextHopP.y = nextHopP.y - (nextHopP.y % tileLength);
        //Debug.Log("x = "+nextHopP.x + "y = "+nextHopP.y);
        return nextHopP;
    }
}


