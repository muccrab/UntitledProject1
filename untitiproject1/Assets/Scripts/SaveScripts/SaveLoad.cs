using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //wanted JSON so my stupid ass can read what is in the file, but I just....cant bother now and i will simply follow Brackeys tutorial
using System.Security.Cryptography;
using System.Text;


//It should work with any File Sytem including Androids...at least I hope it will
//Format for Path: '/path', it will automaticaly assign path folder based on Operating System, so you dont need to worry about it

public static class SaveLoad 
{
    //Simple save of one instance....obviously it will get makeover once we'll have shit to save, but for now its just simple name save
    public static void saveSimple (string path,string name,string scene)
    {
            BinaryFormatter formatter = new BinaryFormatter();
            path = Application.persistentDataPath + path; 
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            SaveDataObj data = new SaveDataObj(path.Substring(Application.persistentDataPath.Length),name,scene);
            formatter.Serialize(stream, data);
            stream.Close();
    }

    //Simple Load method which will return our save instance
    public static SaveDataObj loadSimple (string path) //input is specific save...It will fuck your ass if you feed it just a folder
    {
        path = Application.persistentDataPath + path;
        if (!File.Exists(path)) //It wont fuck with it when you fucked up your input
        {
            Debug.LogError("Save File not found in " + path);
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        SaveDataObj data = formatter.Deserialize(stream) as SaveDataObj;
        stream.Close();

        return data;
    }
    public static SaveDataObj[] loadSimpleAll (string path) //imput is the path of the folder where are saves located...Do not feed it one save, we have a method for that
    {
        path = Application.persistentDataPath + path;
        DirectoryInfo d = new DirectoryInfo(path);
        Debug.Log(path + "\n"+d.GetFiles("*.sus").Length);
        FileInfo[] Files = d.GetFiles("*.sus"); //Getting sus files
        if (Files.Length <= 0) //It wont fuck with it when you fucked up your input
        {
            Debug.LogError("Saves do not exists at " + path);
            return new SaveDataObj[0];
        }
        
        //Loops all files in the folder to get the data
        SaveDataObj[] data = new SaveDataObj[Files.Length];
        for (int i = 0; i< Files.Length; i++)   
        {
            data[i] = SaveLoad.loadSimple(Files[i].ToString().Substring(path.Length));
        }
        return data;
    }

    //saves All the data..gonna use this one in the end product, but I still want to keep saveSimple
    public static void saveAll (string path,string name, string scene)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        //SaveSimple
            string newpath = Application.persistentDataPath + path; 
            FileStream stream = new FileStream(newpath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            SaveDataObj data = new SaveDataObj(newpath.Substring(Application.persistentDataPath.Length),name,scene);
            formatter.Serialize(stream, data);
            stream.Close();
            
            
        //SaveGame
            //Init
            newpath = Application.persistentDataPath + path.Substring(0,path.Length-4)+".baka";
            stream = new FileStream(newpath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //Character Saving
            SaveChatacterObj[] characters = LoadController.getCharacters();
            SaveChatactersObj characterObj = new SaveChatactersObj(characters);
            //Dungeon Saving
            SaveDungeonsObj dungeonObj = LoadController.getDungeons();
            //Player Saving
            SavePlayerObj playerObj = LoadController.getPlayer();
            //Dump All into file
            SaveAllObj datas = new SaveAllObj(characterObj,dungeonObj,playerObj);
            formatter.Serialize(stream, datas);
            stream.Close();
    }

    //Loads Game (Fucking Everything other than name of the save,date saved and path to the complete save, becauseI already have those)
    public static SaveAllObj loadGame(string path)
    {
        string newpath;
        newpath = path.Substring(0,path.Length-4)+".baka";
        
        if (!fileExists(newpath)) //It wont fuck with it when you fucked up your input
        {
            Debug.LogError("Save File not found in " + newpath);
            return null;
        }

        newpath = Application.persistentDataPath + newpath; 
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(newpath, FileMode.Open);
        SaveAllObj data = formatter.Deserialize(stream) as SaveAllObj;
        stream.Close();
        return data;

    }





    public static bool fileExists(string path) //Checks if File Exists...didnt want to use System.IO namespace all around my code
    {
        path = Application.persistentDataPath + path;
        if (File.Exists(path))
        {
            return true;
        }
        return false;
    }
    public static bool filesExist(string path) //Needed to know if sus files exist in a folder
    {
        path = Application.persistentDataPath + path;
        DirectoryInfo d = new DirectoryInfo(path);
        FileInfo[] Files = d.GetFiles("*.sus"); //Getting sus files
        if (Files.Length <= 0)
        {
            return false;
        }
        return true;
    }

   
}
