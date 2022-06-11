using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //IDK wtf it means, but Brackeys said that it makes it able to save in a File
public class SaveDataObj
{
   public string name;
   public string date;
   public SaveDataObj(string name){
        this.name = name;
        this.date = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm");
   }

}
