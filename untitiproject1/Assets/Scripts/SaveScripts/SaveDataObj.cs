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

[System.Serializable]
public class SaveAllObj
{
   public SaveChatactersObj Characters{get;}
   public SaveDungeonsObj Dungeons{get;}

   public SaveAllObj(SaveChatactersObj characters, SaveDungeonsObj dungeons){
      this.Characters = characters;
      this.Dungeons = dungeons;
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

[System.Serializable]
public class SaveDungeonObj //Dungeon I'll be saving to files
{
   Dictionary<string,Tile> dungeon;
   string playerRoom = "";
   bool finnished = false;
   public SaveDungeonObj(Dictionary<string,Tile> dungeon, string playerRoom){
      this.dungeon = dungeon;
      this.playerRoom = playerRoom;
   }
   public Dictionary<string,Tile> getDungeon(){
      return dungeon;
   }
}
[System.Serializable]
public class SaveDungeonsObj
{
   public bool isInDungeon = false;
   public string curDungeon = "";
   Dictionary<string, SaveDungeonObj> dunCollecrtion;
   public SaveDungeonsObj(Dictionary<string, SaveDungeonObj> dunCollecrtion){
      this.dunCollecrtion = dunCollecrtion; 
   }
   public SaveDungeonsObj(){
      this.dunCollecrtion = new Dictionary<string, SaveDungeonObj>();
   }
   public void addDungeon(string name, SaveDungeonObj dungeon){
      this.dunCollecrtion.Add(name,dungeon);
   }
   public void removeDungeon(string name){
      if (this.dunCollecrtion.ContainsKey(name)) this.dunCollecrtion.Remove(name);
   }
   public SaveDungeonObj getDungeon(string name){
      if (this.dunCollecrtion.ContainsKey(name)) return this.dunCollecrtion[name];
      return null;
   }

}



[System.Serializable]
public class Tile{
    string name;
    public int posx,posy; //position on screen (probably useless so I will delete it later....GET OFF MY BACK ABOUT IT Alright!!!!)
    int posinhall; //Hall specific - position in one hall
    public bool type; //F for Hall, T for Room
    string special; //Special condition in room
    string left, up, right, down; //Room specific - just direction where you can go 
    string from, to; //Hall specific - directions
    public Tile(string name, int posx,int posy,string special,int posinhall){
        this.name = name;
        this.posx = posx;
        this.posy = posy;
        this.posinhall = posinhall;
        this.type = false;
        this.special = special;
    }
    public Tile(string name, int posx,int posy, string special){
        this.name = name;
        this.posx = posx;
        this.posy = posy;
        this.type = true;
        this.special = special;
    }
    
    public void setLeft(string left) {this.left=left;}
    public void setUp(string up) {this.up=up;}
    public void setRight(string right) {this.right=right;}
    public void setDown(string down) {this.down=down;}
    public void setFrom(string from) {this.from=from;}
    public void setTo(string to) {this.to=to;}
    public string getLeft(){return this.left;}
    public string getUp(){return this.up;}
    public string getRight(){return this.right;}
    public string getDown(){return this.down;}
    public string getFrom(){return this.from;}
    public string getTo(){return this.to;}
    public string getName(){return this.name;}
}