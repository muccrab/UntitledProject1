using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource ButtonSound;

    public GameObject MenuSaves;
    public GameObject  Menu;
    private void Start()
    {
        LoadController.resetController();
        ButtonSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
        if (SaveLoad.filesExist(""))
        {
            Menu.SetActive(false);
            MenuSaves.SetActive(true);
        }
        else
        {
           Menu.SetActive(true);
           MenuSaves.SetActive(false);
        }
    }
    public void NewGame()
    {
        
        SceneManager.LoadScene("Loader"); //zatial to da do Pause menu, ale tu sa to este pomeni aj zo save-ami
    }

    public void ExitButton()
    {
        Debug.Log("vypnute secko");
        Application.Quit();//v unity este nefunguje az v legit hre
    }

    public void ButtonSounds()
    {
        //ButtonSound.Play();
    }
}
