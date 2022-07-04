using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    #region Singlton:Shop

	public static Shop Instance;

	void Awake ()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy (gameObject);
	}

	#endregion
    
    [System.Serializable] class ShopItem
    {
        public Sprite Image;
        public int Price;
    }
    
    public List<ShopItem> ShopItemsList;
    [SerializeField] TMP_Text CoinsText;

    GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;
    Button buyBtn;

    void Start()
    {
        ItemTemplate = ShopScrollView.GetChild (0).gameObject;

        int len = ShopItemsList.Count;
        for (int i = 0; i < len; i++)
        {
            g = Instantiate (ItemTemplate, ShopScrollView);
            g.transform.GetChild (0).GetComponent <Image> ().sprite = ShopItemsList [i].Image;
            //g.transform.GetChild (1).GetChild (0).GetComponent <Text> ().text = ShopItemsList [i].Price.ToString();
            buyBtn = g.transform.GetChild (2).GetComponent <Button>();
            buyBtn.AddEventListener (i,OnShopItemBtnClicked);
			
        }
        Destroy (ItemTemplate);
        SetCoinsUI();

    void OnShopItemBtnClicked(int itemIndex){
        
        if(Game.Instance.HasEnoughCoins(ShopItemsList[itemIndex].Price)){
            Game.Instance.UseCoins(ShopItemsList[itemIndex].Price);


        SetCoinsUI();
        }else{
            Debug.Log("no moners");
        }
        
        
    }


}

    void SetCoinsUI(){
        CoinsText.text = Game.Instance.Coins.ToString();
    }

}
