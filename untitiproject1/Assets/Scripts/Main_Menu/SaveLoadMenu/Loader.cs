using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(LoadController.loadSave)
        {
            SaveAllObj data = SaveLoad.loadGame(LoadController.path);
            LoadController.setCharacters(data.Characters.getCharacters());
            LoadController.dungeons = data.Dungeons;
            if (data.Dungeons.isInDungeon)
            {
                LoadController.nameofDungeon = data.Dungeons.curDungeon;
                LoadController.isInDungeon = data.Dungeons.isInDungeon;
                LoadController.location = data.Dungeons.getDungeon(data.Dungeons.curDungeon).playerRoom;
                LoadController.Dungeon = data.Dungeons.getDungeon(data.Dungeons.curDungeon).getDungeon();
            }
            LoadController.SetGuild(data.Guild);
        }
        LoadController.loadSave = false;
        //Had to find antoher way around to check if scene is in built settings....
        int sceneIndex = SceneUtility.GetBuildIndexByScenePath("Scenes/"+LoadController.scene);
        if(sceneIndex>=0)
            SceneManager.LoadScene(LoadController.scene);

        else
        {
            Debug.LogError("Couldn't load scene: " + LoadController.scene);
            SceneManager.LoadScene("MenuScene");
        }

    }

}
