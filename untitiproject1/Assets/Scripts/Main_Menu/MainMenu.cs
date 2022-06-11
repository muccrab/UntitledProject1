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
        ButtonSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
        if (/*Saves Loaded*/false)
        {
            Menu.active = false;
            MenuSaves.active = true;
        }
        else
        {
           Menu.active = true;
           MenuSaves.active = false; 
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Lvl1"); //zatial to da do Pause menu, ale tu sa to este pomeni aj zo save-ami
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
