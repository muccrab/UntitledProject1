using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemClasses;

public class PlayerInventoryGO : MonoBehaviour
{
    public GameObject ItemRef;
    public GameObject ItemParent;
    List<OwnedItem> PartyInventory;
    public List<GameObject> PartyInventoryGOS;
    public int? selectItem = null;
    public bool selectChange = false;
    Vector3 startPosition;

    #region Unity runtime
    void Start()
    {
        startPosition = ItemParent.transform.position;
        LoadController.temporaryFillParty();
        PartyInventory = LoadController.PartyInventory;
        resetItems();
    }
    void Update()
    {
        if (selectChange){
            
            selectChange = false;
        }
    }
    #endregion
    void createItem(int ID,string name, int amount, string sprite, Vector3 position){
        PartyInventoryGOS.Add(Instantiate(ItemRef,position,Quaternion.identity));
        GameObject itemframe = PartyInventoryGOS[PartyInventoryGOS.Count-1];
        itemframe.transform.parent = ItemParent.transform;
        ItemGO item = itemframe.GetComponent<ItemGO>();
        item.setName(name);
        item.setAmount(amount);
        item.setSprite(sprite);
        item.ID = ID;
        item.Inventory = gameObject;
    }
   public void resetItems(){
    PartyInventoryGOS = new List<GameObject>();
        for (int i = 0; i<PartyInventory.Count;i++){
            createItem(i,PartyInventory[i].ItemRef.name,PartyInventory[i].amount,PartyInventory[i].ItemRef.sprite,startPosition-new Vector3(0,60*i,0));
        }
   }

}
