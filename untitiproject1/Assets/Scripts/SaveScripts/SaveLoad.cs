using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //wanted JSON so my stupid ass can read what is in the file, but I just....cant bother now and i will simply follow Brackeys tutorial

//It should work with any File Sytem including Androids...at least I hope it will

public static class SaveLoad 
{
    //Simple save of one instance....obviously it will get makeover once we'll have shit to save, but for now its just simple name save
    public static void saveSimple (string name)
    {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/Simple.sus"; //sus is definitely short for simple unity saves and I definitely didnt choose it because of among us
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

            SaveDataObj data = new SaveDataObj(name);
        
            formatter.Serialize(stream, data);
            stream.Close();
    }

    //Simple Load method which will return our save instance
    public static SaveDataObj loadSimple (string path) //input is specific save...It will fuck your ass if you feed it just a folder
    {
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
        DirectoryInfo d = new DirectoryInfo(path);

        FileInfo[] Files = d.GetFiles("*.sus"); //Getting sus files
        if (Files.Length <= 0) //It wont fuck with it when you fucked up your input
        {
            Debug.LogError("Saves do not exists at " + path);
            return null;
        }
        
        //Loops all files in the folder to get the data
        SaveDataObj[] data = new SaveDataObj[Files.Length];
        for (int i = 0; i< Files.Length; i++)   
        {
            data[i] = SaveLoad.loadSimple(path + "/" + Files[i]);
        }
        return data;
    }
    

}
