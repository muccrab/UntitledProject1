using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject lButton,uButton,rButton,dButton,fromButton,toButton;
    public string Selected = "r0";
    public string from,to;
    public string left,up,right,down;
    public bool type = true;
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
        
    }






    public void pushLeft(){ Selected = left;}
    public void pushUp(){ Selected = up;}
    public void pushRight(){ Selected = right;}
    public void pushDown(){ Selected = down;}
    public void pushFrom(){ Selected = from;}
    public void pushTo(){ Selected = to;}

     

}
