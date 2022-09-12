using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemClasses;

public class ItemSelected : MonoBehaviour
{
    GameObject? collider = null;
    void Update()
    {
        transform.position = Input.mousePosition;
        if (Input.GetMouseButtonUp(0)) DropObject();
    }

    public void DropObject()
    {
        if (collider is null){
            DropObjectWithoutCol();    
        }
        else{
            collider.GetComponent<INVcolliderGO>().item = GetComponent<ItemGO>();
            collider.GetComponent<INVcolliderGO>().dropItem();
        }
        Destroy(gameObject);
    }

    void DropObjectWithoutCol()
    {
        ItemGO item = GetComponent<ItemGO>();
        PlayerInventoryGO inv = item.Inventory.GetComponent<PlayerInventoryGO>();
        inv.Insertitems(item.ID,new OwnedItem(item));

    }

    #region Colliders
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "InventoryCollider"){
            collider = collision.gameObject;
        }
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "InventoryCollider"){
            collider = null;
        }
    }
    #endregion
}
