using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject[] games;
    public GameObject PauseMenuUI;
    private bool gameStopped;

    public void ContinueButton()//Unpauses game, closes pause menu
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameStopped = false;
    }
    
    public void PauseButton()//pauses game, opens or closes pause menu depending if game is stopped or not
    {
            if (gameStopped)
            {
                PauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                gameStopped = false;
            }
            else
            {
                PauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                gameStopped = true;
            }
            stopresume();
    }

    public void ExitButton()
    {
        Application.Quit();//v unity este nefunguje az v legit hre
        Debug.Log("Vypnute secko");
    }

    
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    private void stopresume()
    {
        if (games != null)
        {
            foreach (GameObject game in games)
            {
                game.SetActive(!gameStopped);
            }
        }
    }
}//mono
