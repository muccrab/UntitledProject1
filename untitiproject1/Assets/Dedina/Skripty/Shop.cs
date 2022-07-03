using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;

    void Start()
    {
        ItemTemplate = ShopScrollView.GetChild (0).gameObject;

        for (int i = 0; i < 8; i++)
        {
            g = Instantiate (ItemTemplate, ShopScrollView);
        }
        Destroy (ItemTemplate);
    }


}
