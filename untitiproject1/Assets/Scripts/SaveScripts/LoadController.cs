using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemClasses;

/*Public Controller so that I can actualy pass the data between scenes.
 There will also be more methods for loading yet I cant bother with that shit this early in the Game Developement*/
public static class LoadController
{
    #region Global data
        public static string scene = "Lvl1";
        public static bool loadSave = false;
        public static string path = "";

        static void resetGlobal(){
            scene = "Lvl1";
            loadSave = false;
            path = "";
        }
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
        public static int sizeCharacters(){
            return characters.Count;
        }
        public static void resetCharacters(){
            characters = new List<SaveChatacterObj>();
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
        static void resetDungeon(){
            isInDungeon = false;
            nameofDungeon = "kokot1";
            location = null;
            Dungeon = new Dictionary<string, Tile>();
        }
    #endregion

    #region Player data
        static int position_x = 0;
        static int position_y = 0;
        public static SavePlayerObj getPlayer()
        {
            return new SavePlayerObj(position_x,position_y);
        }
    #endregion

    #region Guild data
        public static int money;
        public static List<OwnedItem> GuildInventory = new List<OwnedItem>();
        public static List<OwnedItem> PartyInventory = new List<OwnedItem>();
        public static void temporaryFillParty(){
            
            PartyInventory.Add(new OwnedItem(new BasicItem("Legendary Sword","","Sword"),1));
            PartyInventory.Add(new OwnedItem(new BasicItem("Random Strawberry","","Strawberry"),5));
            
        }
        public static SaveGuildObj GetGuild(){
            return new SaveGuildObj(money,GuildInventory,PartyInventory);
        }
        public static void SetGuild(SaveGuildObj obj){
            money = obj.money;
            GuildInventory = obj.GuildInventory;
            PartyInventory = obj.PartyInventory;

        }
        static void resetGuild(){
            money =0;
            GuildInventory = new List<OwnedItem>();
            PartyInventory = new List<OwnedItem>();
        }
    #endregion
    //reset Load Controller Data //wont do dungeons, only current one
    public static void resetController(){
       resetGlobal();
       resetCharacters();
       resetDungeon();  
       resetGuild();
    }
    
}
