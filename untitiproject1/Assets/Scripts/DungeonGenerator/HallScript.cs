using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallScript : MonoBehaviour
{
    public bool left=false,right=false,up=false,down=false;
    public Vector2Int getNewTile(Vector2Int position, int tileLength, HashSet<Vector2> tilePositions){
        

        int[] newDirection = this.getAvailable(tilePositions);
        Vector2Int newTile = new Vector2Int();
        if (newDirection.Length > 0)
            switch(newDirection[Random.Range(0,newDirection.Length)]){
                case 1:
                    newTile.x = position.x-tileLength;
                    newTile.y = position.y;
                    break;
                case 2:
                    newTile.x = position.x;
                    newTile.y = position.y+tileLength;
                    break;
                case 3:
                    newTile.x = position.x+tileLength;
                    newTile.y = position.y;
                    break;
                case 4:
                    newTile.x = position.x;
                    newTile.y = position.y-tileLength;
                    break;
            }
        Debug.Log(name + " = "+debugArray(newDirection));
        //Debug.Log(name + " = " + left + " - " + up + " - " + right + " - " + down + " - - " + newTile);
        return newTile;
        
    }
    
    private int[] getAvailable(HashSet<Vector2> tilePositions)
    {
        Vector2 curPosition = new Vector2(transform.position.x,transform.position.y);

        // Left Checkers
        left |= tilePositions.Contains(curPosition+new Vector2(-1,0)); //-1 X | 0 Y 
        left |= tilePositions.Contains(curPosition+new Vector2(-2,0)); //-2 X | 0 Y 
        left |= tilePositions.Contains(curPosition+new Vector2(-1,1)); //-1 X | 1 Y 
        left |= tilePositions.Contains(curPosition+new Vector2(-1,-1)); //-1 X | -1 Y 

        // Up Checkers
        up |= tilePositions.Contains(curPosition+new Vector2(0,1)); //0 X | 1 Y 
        up |= tilePositions.Contains(curPosition+new Vector2(0,2)); //0 X | 2 Y  
        up |= tilePositions.Contains(curPosition+new Vector2(-1,1)); //-1 X | 1 Y  
        up |= tilePositions.Contains(curPosition+new Vector2(1,1)); //1 X | 1 Y   
        // Right Checkers
        right |= tilePositions.Contains(curPosition+new Vector2(1,0)); //1 X | 0 Y
        right |= tilePositions.Contains(curPosition+new Vector2(2,0)); //2 X | 0 Y  
        right |= tilePositions.Contains(curPosition+new Vector2(1,1)); //1 X | 1 Y  
        right |= tilePositions.Contains(curPosition+new Vector2(1,-1)); //1 X | -1 Y    
        // Down Checkers
        down |= tilePositions.Contains(curPosition+new Vector2(0,-1)); //0 X | -1 Y
        down |= tilePositions.Contains(curPosition+new Vector2(0,-2)); //0 X | -2 Y  
        down |= tilePositions.Contains(curPosition+new Vector2(-1,-1)); //-1 X | -1 Y  
        down |= tilePositions.Contains(curPosition+new Vector2(1,-1)); //1 X | -1 Y    
        
        
        
     
        ;
        bool[] bools = {left,up,right,down};
        int[] available = new int[countbools(bools)];
        
        int counter = 0;
        if (!left) { //Left
            available[counter]=1;
            counter++;
        }
        if (!up){  //Up
            available[counter]=2;
            counter++;
        }
        if (!right) {  //Right
            available[counter]=3;
            counter++;
        }
        if (!down) { //Right
            available[counter]=4;
            counter++;
        }
        return available;
    }



    static int countbools(bool[] list)
    {
        int counter = 0;
        foreach(bool lol in list) if(lol!=true) counter++;
        return counter;
    }
    static string debugArray(int[] array)
    {
        string a="(";
        foreach (int i in array)
        {
            a+=(i+",");
        }
        return a.Remove(a.Length-1,1)+")";
    }


   
}
