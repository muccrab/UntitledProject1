/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singlton:Inventory

	public static Inventory Instance;

	void Awake ()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy (gameObject);
	}

	#endregion

    public class Item{
        public Sprite Image;
    }

    public List<Item> ItemsList;

    [SerializeField] GameObject ItemUITemplate;
	[SerializeField] Transform ItemsScrollView;

    void Start(){
        GetAvailaibleItems();
    }

    void GetAvailaibleItems(){
        for (int i = 0; i < Shop.Instance.ShopItemsList.Count; i++)
        {
            if (Shop.Instance.ShopItemsList[i].buyBtn.AddEventListener (i,OnShopItemBtnClicked))
            {

            }
        }
    }

}
*/