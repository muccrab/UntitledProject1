using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static ItemClasses;

public class INVcolliderGO : MonoBehaviour
{
    
    #region parameters
    public UnityEvent m_function;
    public GameObject entagledFrame;
    public ItemGO item;
    public Sprite collisionSprite;
    public Sprite defaultSprite;
    #endregion
    #region Main Function
        public void dropItem(){
            m_function.Invoke();
        }
    #endregion
    #region side Functios
        public void dropUp(){
            ItemGO entangledItem = entagledFrame.GetComponent<ItemGO>();
            PlayerInventoryGO inv = entangledItem.Inventory.GetComponent<PlayerInventoryGO>();
            inv.Insertitems(entangledItem.ID,new OwnedItem(item));
        }
        public void dropDown(){
            ItemGO entangledItem = entagledFrame.GetComponent<ItemGO>();
            PlayerInventoryGO inv = entangledItem.Inventory.GetComponent<PlayerInventoryGO>();
            inv.Insertitems(entangledItem.ID+1,new OwnedItem(item));
        }
    #endregion

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ItemSelected"){
            GetComponent<Image>().sprite = collisionSprite;
        }
        else GetComponent<Image>().sprite = defaultSprite;
    }
     void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Image>().sprite = defaultSprite;
    }
    




}
