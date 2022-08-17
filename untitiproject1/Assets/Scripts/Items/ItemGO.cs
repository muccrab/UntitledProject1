using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemGO : MonoBehaviour
{
    public int ID;
    public GameObject nameObj, amountObj, spriteObj;
    public GameObject Inventory;

    #region SpriteValues
    public List<SpriteString> keyvalue = new List<SpriteString>();
    Dictionary<string,Sprite> TxttoSprite = new Dictionary<string, Sprite>();
    //AKA Screw Optimisation
    void Awake(){
        foreach (SpriteString s in keyvalue)
        {
            TxttoSprite[s.key] = s.val;
        }
    }
    #endregion

    #region setters
    public void setName(string name){
        nameObj.GetComponent<TextMeshProUGUI>().text = name;
    }
    public void setAmount(int amount){
        if (amount == 0) amountObj.GetComponent<TextMeshProUGUI>().text = "";
        else amountObj.GetComponent<TextMeshProUGUI>().text = amount.ToString();
    }
    public void setSprite(string sprite){
        if (!TxttoSprite.ContainsKey(sprite)) return;
        spriteObj.GetComponent<Image>().sprite = TxttoSprite[sprite];
    }
    public void setOutline(){

    }
    #endregion
    
    #region getters
    public string getName(){
        return nameObj.GetComponent<TextMeshProUGUI>().text;
    }
    public int getAmount(){
        int number;
        bool success = int.TryParse(amountObj.GetComponent<TextMeshProUGUI>().text,out number);
        if (success) return number;
        else return 0;
    }
    [System.Serializable]
    public class SpriteString{
        public string key;
        public Sprite val;
    }
    #endregion

    #region BTNfunctions
    public void debugBTN(){
        Debug.Log("Works");
    }
    public void pickupItem(){
        List<GameObject> INV = Inventory.GetComponent<PlayerInventoryGO>().PartyInventoryGOS;
        INV.RemoveAt(ID);
        for(int i = ID; i < INV.Count;i++)
        {
            INV[i].GetComponent<ItemGO>().ID = i;
            INV[i].transform.position = Inventory.GetComponent<PlayerInventoryGO>().ItemParent.transform.position-new Vector3(0,60*i,0);
        }
        Inventory.GetComponent<PlayerInventoryGO>().PartyInventoryGOS = INV;
        Destroy(gameObject);
    }
    #endregion
}
