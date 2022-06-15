using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //IDK wtf it means, but Brackeys said that it makes it able to save in a File
public class SaveDataObj //Object that I'm saving into the file
{
   public string path, name, date;
   public SaveDataObj(string path, string name){
      this.path = path;
      this.name = name;
      this.date = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm");
   }


}
