using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopPanel : MonoBehaviour, SelectableBoxPanel
{
    [SerializeField] GameObject FirstSelected;
    [SerializeField] ItemBox CurrentlySellected;
    [SerializeField] Vendor Vendor;
    [SerializeField] Player player;
    public List<ItemBox> ItemSpots;
    public List<ItemBox> SellingItemSpots;

    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;
    public TextMeshProUGUI ItemCost;

    private void OnEnable()
    {
        player = Singleton.Instance.currentPlayer;
        //Fill Vendor Items to buy
        UpdateVendorItemsDisplay();
        //Fill Player Items to buy
        UpdatePlayerItemsDisplay();

        player.playerActions.EventSystem.SetSelectedGameObject(FirstSelected);
    }

    private void FixedUpdate()
    {
        HandleBoxSelection();
    }


    private void HandleBoxSelection() 
    {
        //Handle selection box update
        ItemBox mostRecentSelection = player.playerActions.EventSystem.currentSelectedGameObject.GetComponent<ItemBox>();
        if (CurrentlySellected != mostRecentSelection) 
        {
            mostRecentSelection?.UpdateSelectionState(true);
            CurrentlySellected?.UpdateSelectionState(false);
            CurrentlySellected = mostRecentSelection;
        }

        //Handle Description Text Update
        if (CurrentlySellected != null && CurrentlySellected.CurrentItem != null)
        {

            ItemName.text = CurrentlySellected.CurrentItem.name;
            ItemDescription.text = CurrentlySellected.CurrentItem.description;
            ItemCost.text = CurrentlySellected.CurrentItem.cost.ToString();
        }
        else 
        {
            ItemName.text = "";
            ItemDescription.text = "";
            ItemCost.text = "";
        }
    }
    public void UpdateVendorItemsDisplay()
    {

        int spotIndex = 0;
        foreach (Item item in Vendor.Items)
        {
            if (spotIndex > ItemSpots.Count -1)
            {
                Debug.LogError("List index out of range!");
                break;
            }
            ItemSpots[spotIndex].AssignItem(item);
            spotIndex++;
        }

        //ensure the rest of the spots get cleared
        for(int i = spotIndex; i < ItemSpots.Count; i++) 
        {
            ItemSpots[spotIndex].AssignItem(null);
        }

    }


    public void UpdatePlayerItemsDisplay() 
    {
        int spotIndex = 0;
        foreach (Item item in player.Inventory.CurrentItems)
        {
            if (spotIndex > SellingItemSpots.Count - 1)
            {
                Debug.LogError("List index out of range!");
                break;
            }
            SellingItemSpots[spotIndex].AssignItem(item);
            spotIndex++;
        }
        //ensure the rest of the spots get cleared
        for (int i = spotIndex; i < SellingItemSpots.Count; i++)
        {
            SellingItemSpots[spotIndex].AssignItem(null);
        }
    }


    #region SelectableBoxPanelInterface
    public void SelectBox()
    {
        //Doesnt do anything if player doesnt have money or nothing is selected
        if (CurrentlySellected == null || CurrentlySellected.CurrentItem == null) return;
        if(!CurrentlySellected.playerCanSell &&  CurrentlySellected.CurrentItem.cost > player.Inventory.CurrentMoney) return;

        if (!CurrentlySellected.playerCanSell) 
        {
            //Transaction (Player buys item) 
            player.Inventory.CurrentItems.Add(CurrentlySellected.CurrentItem);
            Vendor.Items.Remove(CurrentlySellected.CurrentItem);
            player.Inventory.EditMoney(-CurrentlySellected.CurrentItem.cost);
            CurrentlySellected.AssignItem(null);
            UpdatePlayerItemsDisplay();
            UpdateVendorItemsDisplay();
            
        }
        else 
        {
            //Transaction (Player sells item) 
            Vendor.Items.Add(CurrentlySellected.CurrentItem);
            player.Inventory.CurrentItems.Remove(CurrentlySellected.CurrentItem);
            player.Inventory.EditMoney(+CurrentlySellected.CurrentItem.cost);
            CurrentlySellected.AssignItem(null);
            UpdatePlayerItemsDisplay();
            UpdateVendorItemsDisplay();
      
        }
        

    }
    GameObject SelectableBoxPanel.GameObject => gameObject;
    #endregion



}
