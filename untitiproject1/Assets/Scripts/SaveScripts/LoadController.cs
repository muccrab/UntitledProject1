using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Public Controller so that I can actualy pass the data between scenes.
 There will also be more methods for loading yet I cant bother with that shit this early in the Game Developement*/
public static class LoadController
{
    public static string scene = "Lvl1";
    public static bool loadSave = false;
    public static string path = "";
    private static List<SaveChatacterObj> characters = new List<SaveChatacterObj>();
    public static Dictionary<string,Tile> Dungeon = new Dictionary<string, Tile>();

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
   


    public static void resetController(){
        scene = "Lvl1";
        loadSave = false;
        path = "";
        characters = new List<SaveChatacterObj>();
    }
    
}
