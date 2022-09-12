using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttns : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject tavernPanel;
    public GameObject armoryPanel;
    public GameObject hospitalPanel;
    public GameObject churchPanel;

    public GameObject shopButt;
    public GameObject tavernButt;
    public GameObject armoryButt;
    public GameObject hospitalButt;
    public GameObject churchButt;

    private bool panelActie = false;

    void Update()
    {
        if (panelActie)
        {
            shopButt.SetActive(false);
            tavernButt.SetActive(false);
            armoryButt.SetActive(false);
            hospitalButt.SetActive(false);
            churchButt.SetActive(false);
        }
        else
        {
            shopButt.SetActive(true);
            tavernButt.SetActive(true);
            armoryButt.SetActive(true);
            hospitalButt.SetActive(true);
            churchButt.SetActive(true);
        }
    }

    public void ShopButtOn()
    {
        shopPanel.SetActive(true);
        panelActie = true;
    }
    public void ShopButtOff()
    {
        shopPanel.SetActive(false);
        panelActie = false;
    }

    public void TavernButtOn()
    {
        tavernPanel.SetActive(true);
        panelActie = true;
    }
    public void TavernButtOff()
    {
        tavernPanel.SetActive(false);
        panelActie = false;
    }

    public void ArmoryButtOn()
    {
        armoryPanel.SetActive(true);
        panelActie = true;
    }
    public void ArmoryButtOff()
    {
        armoryPanel.SetActive(false);
        panelActie = false;
    }

    public void HospitalButtOn()
    {
        hospitalPanel.SetActive(true);
        panelActie = true;
    }
    public void HospitalButtOff()
    {
        hospitalPanel.SetActive(false);
        panelActie = false;
    }

    public void ChurchButtOn()
    {
        churchPanel.SetActive(true);
        panelActie = true;
    }
    public void ChurchButtOff()
    {
        churchPanel.SetActive(false);
        panelActie = false;
    }
}
