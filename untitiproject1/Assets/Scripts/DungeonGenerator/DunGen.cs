using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DunGen : MonoBehaviour
{
    public GameObject RoomTile; //Tile For 
    public GameObject Tile;
    public Vector2Int mainRange;
    public int Radius;
    int mainHops=0;
    int tileLength = 10;
    // Start is called before the first frame update
    void Start()
    {
        //Random.InitState((int)Time.time); //sets seed for Generation
        tileLength = (int)Tile.GetComponent<SpriteRenderer>().bounds.size.x; //Obtains the Length of Tile
        mainHops = Random.Range(mainRange.x+0,mainRange.y+1); //Gets Hops of Main Road


        #region Main Road Generator
        //Array of main Road stops
        TurnPoint[] mainPoints = new TurnPoint[mainHops];
        for(int i = mainHops-1; i >= 0; i--)
        {
            if (i != mainHops-1)
            {
                mainPoints[mainHops-i-1] = new TurnPoint(mainPoints[mainHops-2-i].nextHop,i,0.5f,Radius,tileLength,true);
                //Debug.Log(mainPoints[mainHops-i-1].nextHop.x);
            }
            else
            {
                mainPoints[mainHops-i-1] = new TurnPoint(new Vector2Int(0,0),i,0.5f,Radius,tileLength,true); 
            }
        }


        //Debug.Log(mainHops);
        for (int j = 0; j < mainHops; j++)
        {
            TurnPoint tp = mainPoints[j];
            GameObject tile = Instantiate(RoomTile);
            tile.name = "Room "+j;
            tile.transform.position = new Vector2(tp.position.x,tp.position.y);

            if (j!=mainHops-1)
            {
                TurnPoint ntp = mainPoints[j+1];
                int tilesBetweenLength = (int)Mathf.Abs((ntp.position.x-tp.position.x)/tileLength)+(int)Mathf.Abs((ntp.position.y-tp.position.y)/tileLength);
                Vector2[] tilesBetween = new Vector2[100];
                tilesBetween[0].y = tp.position.y;
                //Debug.Log(tp.position.x +" - "+ ntp.position.x);
                //Debug.Log(Mathf.Abs((tp.position.x-ntp.position.x))+" / "+ tileLength+" + "+ Mathf.Abs((tp.position.y-ntp.position.y)));
                //Debug.Log("Tiles Between - "+tilesBetweenLength);
                int tIndex = 0;
                

                int NToffset = (int)Mathf.Sign(ntp.position.x-tp.position.x)*tileLength;
                for(int i = tp.position.x+NToffset; nextPointCheck(i,tp.position.x,ntp.position.x,null); i+=NToffset)
                {
                   //Debug.Log(i);
                    if (tIndex==0) tilesBetween[0].y = tp.position.y;
                    else tilesBetween[tIndex].y = tilesBetween[tIndex-1].y;
                    tilesBetween[tIndex].x = i;
                    tIndex++;
                    //if (tIndex>100) break;
                    //Debug.Log("last position - "+tp.position.x+" - position - "+i+" - next position - "+ntp.position.x);
                }
                    
                 //tIndex--;
                
                NToffset = (int)Mathf.Sign(ntp.position.y-tp.position.y)*tileLength;
                for(int i = tp.position.y+NToffset; nextPointCheck(i,tp.position.y,ntp.position.y-NToffset,NToffset); i+=NToffset)
                {
                    //Debug.Log(i);
                    if (tIndex==0) tilesBetween[tIndex].x = tp.position.x;
                    else tilesBetween[tIndex].x = tilesBetween[tIndex-1].x;
                    tilesBetween[tIndex].y = i;
                    tIndex++;
                    //if (tIndex>100) break;
                }



                for(int i = 0; i < tilesBetweenLength; i++)
                {
                    if (tilesBetween[i].x != 0 || tilesBetween[i].y != 0)
                    {
                        GameObject tilebetween = Instantiate(Tile);
                        tilebetween.name = "Hall "+j;
                        tilebetween.transform.position = new Vector2(tilesBetween[i].x,tilesBetween[i].y);
                    }
                }
            }
        }
        #endregion
        #region Brech Generator
        #endregion









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

}

class TurnPoint{

    public Vector2Int position;
    public Vector2Int nextHop;
    public int hopCount;
    public bool branchable = false;
    int Radius;
    int tileLength;

    public TurnPoint(Vector2Int position,int hopCount, float brachChance, int Radius, int tileLength, bool isMain){
        this.position.x = position.x;
        this.position.y = position.y;
        this.hopCount = hopCount;
        this.Radius = Radius;
        this.tileLength = tileLength;
        
        branchable = Random.value < brachChance;
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