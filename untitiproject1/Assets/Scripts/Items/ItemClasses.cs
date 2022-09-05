using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClasses
{
    [System.Serializable]
    public class BasicItem
    {
        public string name;
        public string description;
        public string sprite;
        public BasicItem(string name, string description, string sprite){
            this.name = name;
            this.description = description;
            this.sprite = sprite;
        }
    }
    [System.Serializable]
    public class OwnedItem
    {
        public BasicItem ItemRef;
        public int amount;
        public OwnedItem(BasicItem ItemRef, int amount){
            this.ItemRef = ItemRef;
            this.amount = amount;
        }
        public OwnedItem(ItemGO item){
            this.ItemRef = new BasicItem(item.getName(),"",item.strsprite);
            this.amount = item.getAmount();
        }
    }


}
