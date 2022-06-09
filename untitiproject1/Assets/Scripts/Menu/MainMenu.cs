using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    private AudioSource ButtonSound;

    private void Start()
    {
        ButtonSound = GetComponent<AudioSource>();
    }

    public void ExitButton()
    {
        Debug.Log("vypnute secko");
        Application.Quit();//v unity este nefunguje az v legit hre
    }

    public void ButtonSounds()
    {
        ButtonSound.Play();
    }
}
