using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //IDK wtf it means, but Brackeys said that it makes it able to save in a File
public class SaveDataObj //Object that I'm saving into the file
{
   public string path, name, date, scene;
   public SaveDataObj(string path, string name, string scene){
      this.path = path;
      this.name = name;
      this.date = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm");
      this.scene = scene;
   }
}


//Idiot cant spell in 5,4,3,2,1...
[System.Serializable]
public class SaveChatacterObj //Character I'll be saving in files
{
   int str,dex,health,maxHealth,def,attackS,willP,morale,minDmg,maxDmg;
   string name, Class, religion, CharImg;
   bool[] UnlockedSpells;
   public SaveChatacterObj(Character character){
      this.str=character.str;
      this.dex=character.dex;
      this.health=character.health;
      this.maxHealth=character.maxHealth;
      this.def=character.def;
      this.attackS=character.attackS;
      this.willP=character.willP;
      this.morale=character.morale;
      this.minDmg=character.minDmg;
      this.maxDmg=character.maxDmg;

      this.name = character.name;
      this.Class = character.Class;
      this.religion = character.religion;

      this.UnlockedSpells = character.UnlockedSpells;
   }
   public Character GetCharacter(){
      Character character = new Character();
      character.str = this.str;
      character.dex = this.dex;
      character.health = this.health;
      character.maxHealth = this.maxHealth;
      character.def = this.def;
      character.attackS = this.attackS;
      character.willP = this.willP;
      character.morale = this.morale;
      character.minDmg = this.minDmg;
      character.maxDmg = this.maxDmg;

      character.name = this.name;
      character.Class = this.Class;
      character.religion = this.religion;
      
      character.UnlockedSpells = this.UnlockedSpells;

      return character;
   }


}

[System.Serializable]
public class SaveChatactersObj //All Characters I'll be saving in files
{
   SaveChatacterObj[] characters;
   public SaveChatactersObj(SaveChatacterObj[] loadCharacters){
        this.characters = loadCharacters;
     }
   public SaveChatacterObj[] getCharacters(){
         return characters;
   }
}
