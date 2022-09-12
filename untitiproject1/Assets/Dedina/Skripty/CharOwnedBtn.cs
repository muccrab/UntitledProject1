using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharOwnedBtn : MonoBehaviour
{

    private bool charPoolIsOpen = false;
    public GameObject charPool;

    public CharActionMenu charActionMenu;


    public void OpenCloseCharOwned()
    {
        if(charPoolIsOpen == false)
        {
            charPoolIsOpen = true;
            charPool.SetActive(true);
        }
        else if(charPoolIsOpen == true)
        {
            charPoolIsOpen = false;
            charPool.SetActive(false);

            charActionMenu.charActionMenuIsOpen = false;
            charActionMenu.charActionMenuObject.SetActive(false);
        }
    }
}
