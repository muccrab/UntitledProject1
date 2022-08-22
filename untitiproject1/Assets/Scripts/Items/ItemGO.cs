using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemGO : MonoBehaviour
{
    public int ID, amount;
    public string name;
    public Sprite sprite;
    public GameObject? nameObj = null, amountObj = null, spriteObj = null;
    public GameObject Inventory;
    public GameObject ItemSelected;

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
        this.name = name;
        if (nameObj is not null)
            nameObj.GetComponent<TextMeshProUGUI>().text = name;
    }
    public void setAmount(int amount){
        this.amount = amount;
        if (amountObj is not null)
        {
            if (amount == 0) amountObj.GetComponent<TextMeshProUGUI>().text = "";
            else amountObj.GetComponent<TextMeshProUGUI>().text = amount.ToString();
        }
    }
    public void setSprite(string sprite){
        if (!TxttoSprite.ContainsKey(sprite)) return;
        this.sprite = TxttoSprite[sprite];
        if (spriteObj is not null)
            spriteObj.GetComponent<Image>().sprite = this.sprite;
    }
    public void setSprite(Sprite sprite){
        this.sprite = sprite;
        if (spriteObj is not null)
            spriteObj.GetComponent<Image>().sprite = this.sprite;
    }
    #endregion
    
    #region getters
    public string getName(){
        return name;
    }
    public int getAmount(){
        return amount;
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
        GameObject newItem = Instantiate(ItemSelected, Vector3.zero, Quaternion.identity);
        ItemGO item = newItem.GetComponent<ItemGO>();
        item.setName(name);
        item.setAmount(amount);
        item.setSprite(sprite);
        item.ID = ID;
        item.Inventory = Inventory;
        item.transform.parent = transform.parent.parent;
        Destroy(gameObject);
    }
    public void selectItem(){
        Inventory.GetComponent<PlayerInventoryGO>().selectItem = ID;
        Inventory.GetComponent<PlayerInventoryGO>().selectChange = true;
    }
    #endregion
}
