using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallScript : MonoBehaviour
{
    public GameObject[] Coliders;
    public bool left=false,right=false,up=false,down=false;
    public Vector2Int getNewTile(Vector2Int position, int tileLength){
        

        int[] newDirection = this.getAvailable();
        Vector2Int newTile = new Vector2Int();
        
        switch(newDirection[Random.Range(0,newDirection.Length)]){
            case 1:
                newTile.x = position.x-tileLength;
                newTile.y = position.y;
                break;
            case 2:
                newTile.x = position.x;
                newTile.y = position.y-tileLength;
                break;
            case 3:
                newTile.x = position.x+tileLength;
                newTile.y = position.y;
                break;
            case 4:
                newTile.x = position.x;
                newTile.y = position.y+tileLength;
                break;
        }
        
        return newTile;
        
    }
    
    private int[] getAvailable()
    {
        left = Coliders[0].GetComponent<Coliders>().collied;
        up = Coliders[1].GetComponent<Coliders>().collied;
        right = Coliders[2].GetComponent<Coliders>().collied;
        down = Coliders[3].GetComponent<Coliders>().collied;
        Debug.Log(name + " = " + left + " - " + up + " - " + right + " - " + down);
        bool[] bools = {left,up,right,down};
        int[] available = new int[countbools(bools)];
        int counter = 0;
        if (!left) {
            available[counter]=1;
            counter++;
        }
        if (!up){
            available[counter]=2;
            counter++;
        }
        if (!right) {
            available[counter]=3;
            counter++;
        }
        if (!down) {
            available[counter]=4;
            counter++;
        }
        return available;
    }
    static int countbools(bool[] list)
    {
        int counter = 0;
        foreach(bool lol in list) counter++;
        return counter;
    }


   
}
