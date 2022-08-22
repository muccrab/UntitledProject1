using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelected : MonoBehaviour
{
    GameObject? collider = null;
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void DropObject()
    {
        if (collider is null){
            DropObjectWithoutCol();    
        }
        else{
            collider.GetComponent<INVcolliderGO>().dropItem();
        }
        Destroy(gameObject);
    }

    void DropObjectWithoutCol()
    {

    }

    #region Colliders
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "InventroyCollider"){
            collider = collision.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "InventroyCollider"){
            collider = null;
        }
    }
    #endregion
}
