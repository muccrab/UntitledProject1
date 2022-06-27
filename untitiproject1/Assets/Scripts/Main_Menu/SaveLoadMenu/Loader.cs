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
            SaveChatactersObj data = SaveLoad.loadGame(LoadController.path);
            LoadController.setCharacters(data.getCharacters());
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
