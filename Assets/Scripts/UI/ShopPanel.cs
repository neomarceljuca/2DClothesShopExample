using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    GameObject FirstSelected;
    [SerializeField]Vendor Vendor;
    public List<ItemBox> ItemSpots;
    public List<ItemBox> SellingItemSpots;
    private void OnEnable()
    {
        int spotIndex = 0;
      foreach(Item item in Vendor.Items) 
      {
            if (spotIndex > 29) 
            {
                Debug.LogError("List index out of range!");
                break;
            } 


            ItemSpots[spotIndex].AssignItem(item);
            spotIndex++;
      }  
    }


}
