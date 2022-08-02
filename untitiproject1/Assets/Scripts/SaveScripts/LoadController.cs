using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Public Controller so that I can actualy pass the data between scenes.
 There will also be more methods for loading yet I cant bother with that shit this early in the Game Developement*/
public static class LoadController
{
    #region Global data
    public static string scene = "Lvl1";
    public static bool loadSave = false;
    public static string path = "";
    #endregion

    #region Character data
    private static List<SaveChatacterObj> characters = new List<SaveChatacterObj>();
    public static SaveChatacterObj[] getCharacters(){
        return characters.ToArray();
    }
    public static Character getCharacter(int characterID){
        if (characters.Count<=characterID) return null;
        return characters[characterID].GetCharacter();
    }
    public static void setCharacters(SaveChatacterObj[] character){
        characters = new List<SaveChatacterObj>(character);
    }
    public static void addCharacter(SaveChatacterObj character){
        characters.Add(character);
    }
    public static void resetCharacters(){
        characters = new List<SaveChatacterObj>();
    }
    public static int sizeCharacters(){
        return characters.Count;
    }
    #endregion

    #region Dungeon data
    public static bool isInDungeon = false;
    public static string nameofDungeon = "kokot1";
    public static string location;
    public static Dictionary<string,Tile> Dungeon = new Dictionary<string, Tile>();
    public static SaveDungeonsObj dungeons = new SaveDungeonsObj();
    public static void addCurrentDungeon()
    {
        dungeons.addDungeon(nameofDungeon,new SaveDungeonObj(Dungeon,location));
    }
    public static void removeCurrentDungeon()
    {
        dungeons.removeDungeon(nameofDungeon);
    }
    public static SaveDungeonsObj getDungeons()
    {
        dungeons.isInDungeon = isInDungeon;
        if (isInDungeon) {
            dungeons.curDungeon = nameofDungeon;
            removeCurrentDungeon();
            addCurrentDungeon();
        }
        return dungeons;
    }
    #endregion

    #region Player data
    static int position_x = 0;
    static int position_y = 0;

    #endregion

    //reset Load Controller Data //wont do dungeons, only current one
    public static void resetController(){
        scene = "Lvl1";
        loadSave = false;
        path = "";
        characters = new List<SaveChatacterObj>();
        isInDungeon = false;
        nameofDungeon = "kokot1";
        location = null;
        Dungeon = new Dictionary<string, Tile>();
    }
    
}
