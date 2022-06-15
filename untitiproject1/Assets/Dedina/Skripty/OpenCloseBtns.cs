using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseBtns : MonoBehaviour
{

    public GameObject Window;
    private bool windowIsOpen = false;


    public void OpenWindow(){

        if (Window.activeSelf == false && windowIsOpen == false){

            Window.SetActive(true);
            windowIsOpen = true;
        }
    }

    public void CloseWindow(){

        if (Window.activeSelf == true){

            Window.SetActive(false);
            windowIsOpen = false;
            //TODO problem moznosti otvorenia viacerych okien naraz
                //possible riesenie - accesovat premennu windowIsOpen v nadradenom skripte
        }
    }
}
