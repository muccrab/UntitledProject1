using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; //TextMeshPro....Text element but better



public class LoadMenu : MonoBehaviour
{

    void Start()
    {
        ResetMenu();
    }

    public void CreateButton(Vector3 position, Vector2 size, string path, string text)
    {
        //
        //Button Creation
        //
        GameObject button = new GameObject(); //Creates Button
        button.name = "SaveBTN";
        button.tag = "SaveBTN";
        button.transform.parent = GameObject.Find("Panel").transform; //Makes 'Panel' GameObject its parent
        button.transform.localPosition = position; //this took me longer than i dare to admit
        button.AddComponent<RectTransform>(); //Adds RectTransform Component....so that I can actually do shit with its size and scale and other bullshit
        button.AddComponent<Button>(); //Adds Button Functionality
        button.AddComponent<Image>(); //Image Functionality so that I can actaly see the fucker
        button.GetComponent<RectTransform>().sizeDelta = size; //Changes the size of the Button
        button.GetComponent<Button>().onClick.AddListener(delegate { LoadGame(path); }); //Fucking Event Listener


        //
        //Text Creation
        //
        GameObject txt = new GameObject(); //Creates Text
        txt.name = "Text";
        txt.transform.parent = button.transform; //Makes 'SaveBTN' GameObject its parent
        txt.transform.localPosition = Vector3.zero; //this didnt take long at all...progress
        txt.AddComponent<RectTransform>();
        txt.GetComponent<RectTransform>().sizeDelta = button.GetComponent<RectTransform>().sizeDelta; //sets the size the same as its parenting button
        txt.AddComponent<TextMeshProUGUI>(); //adds Text component
        txt.GetComponent<TMP_Text>().text = text;
        txt.GetComponent<TMP_Text>().color = Color.black;
        txt.GetComponent<TMP_Text>().fontSize = 24;

    }
    void LoadGame(string path) 
    {
        LoadController.loadSave = true;
        LoadController.path = path;
        SceneManager.LoadScene("Loader");
    }


    void ResetMenu() //Resets menu so there wont be any buttons that it created and cretes them updated
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("SaveBTN");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }


        SaveDataObj[] data = SaveLoad.loadSimpleAll("");
        for (int i = 1; i <= data.Length; i++)
        {
            CreateButton(new Vector3(0, 137 - 60 * i, 0), new Vector2(837, 50), data[i - 1].path, data[i - 1].name + " - " + data[i - 1].date);
        }
    }


}
