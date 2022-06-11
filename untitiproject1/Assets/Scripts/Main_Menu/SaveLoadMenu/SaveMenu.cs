using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class SaveMenu : MonoBehaviour
{
    public Button SaveBTN; //Its Button in SaveNameWindow...you must do it manualy because Im an idiot
    

    void Start()
    {
        ResetMenu();     
    }

    public void CreateButton(Vector3 position, Vector2 size, string path, string text)
    {
        GameObject button = new GameObject(); //Creates Button
        button.name = "SaveBTN";
        button.tag = "SaveBTN";
        button.transform.parent = GameObject.Find("Panel").transform; //Makes Saves GameObject its parent
        button.AddComponent<RectTransform>(); //Adds RectTrtansform Component....so that I can actually move it
        button.AddComponent<Button>(); //Adds Button Functionality
        button.AddComponent<Image>(); //Image Functionality so that I can actaly see the fucker
        button.GetComponent<RectTransform>().sizeDelta = size; //Changes the size of the Button
        button.GetComponent<Button>().onClick.AddListener(delegate{GetMenu(path);}); //Fucking Event Listener
        button.gameObject.SetActive(true); //this is pointless
        button.transform.localPosition = position; //this took me longer than i dare to admit
    }


    void GetMenu(string path)
    {
        Debug.Log("This is button for " + path);
        transform.Find("SaveNameWindow").gameObject.SetActive(true);
        SaveBTN.onClick.AddListener(delegate{SaveGame(path,GameObject.Find("NameText").GetComponent<TMP_Text>().text);});
    }
    void SaveGame(string path, string name)
    {
        SaveBTN.onClick.RemoveAllListeners();
        SaveLoad.saveSimple(path,name);
        ResetMenu();

    }
    public void CloseMenu()
    {
        SaveBTN.onClick.RemoveAllListeners();
        ResetMenu();
    }
    void ResetMenu()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag ("SaveBTN");
     
        for(var i = 0 ; i < gameObjects.Length ; i ++)
        {
            Destroy(gameObjects[i]);
        }
        transform.Find("SaveNameWindow").gameObject.SetActive(true);
        GameObject.Find("NameText").GetComponent<TMP_Text>().text = "";
        transform.Find("SaveNameWindow").gameObject.SetActive(false);
        SaveDataObj[] data = SaveLoad.loadSimpleAll("");
        CreateButton(new Vector3(0,137,0), new Vector2(837,50), "/save"+data.Length+".sus","New Save");

        for (int i = 1; i <= data.Length; i++)
        {
            CreateButton(new Vector3(0,137-60*i,0), new Vector2(837,50), "lol.sus","Save "+i);
        }
    }

}
