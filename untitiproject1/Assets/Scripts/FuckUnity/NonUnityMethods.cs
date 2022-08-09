using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NonUnityMethods:MonoBehaviour
{
    public static void DestroyAll(GameObject[] gameObjects)
    {
        foreach(GameObject obj in gameObjects)
        {
            Destroy(obj);
        }
    }

    public class RoomNameDivided
    {
        public char type;
        public int roomNumber, hallNumber;
        public RoomNameDivided(string name){
            if (name[0]=='r')
            {
                type = 'r';
                string str = "";
                for (int i = 1; i<name.Length && name[i]>=48 && name[i]<=57;i++)
                {
                    str += name[i];
                }
                roomNumber = int.Parse(str);
                hallNumber = 0;
                return;
            }
            if (name[0]=='h')
            {
                type = 'h';
                string str = "";
                int i = 1;
                for (;i<name.Length && name[i]!='-' &&name[i]>=48 && name[i]<=57 ;i++){
                    str += name[i];
                }
                roomNumber = int.Parse(str);
                i++;
                str = "";
                for (;i<name.Length && name[i]>=48 && name[i]<=57;i++)
                {
                    str += name[i];
                }
                hallNumber = int.Parse(str);
                return;
            }

        }
    }
}
