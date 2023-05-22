using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryPanel : MonoBehaviour, SelectableBoxPanel
{
    [SerializeField] GameObject FirstSelected;
    [SerializeField] ItemBox CurrentlySellected;
    [SerializeField] Player player;
    public List<ItemBox> ItemSpots;
    public ItemBox EquippedHead;
    public ItemBox EquippedTorso;
    public ItemBox EquippedLegs;
    public ItemBox EquippedFeet;

    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;
    public TextMeshProUGUI ItemCost;

    private void OnEnable()
    {
        player = Singleton.Instance.currentPlayer;
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

    public void UpdatePlayerItemsDisplay()
    {
        int spotIndex = 0;
        foreach (Item item in player.Inventory.CurrentItems)
        {
            if (spotIndex > ItemSpots.Count - 1)
            {
                Debug.LogError("List index out of range!");
                break;
            }
            ItemSpots[spotIndex].AssignItem(item);
            spotIndex++;
        }
        //ensure the rest of the spots get cleared
        for (int i = spotIndex; i < ItemSpots.Count; i++)
        {
            ItemSpots[spotIndex].AssignItem(null);
        }
    }




    #region SelectableBoxPanelInterface
    public void SelectBox()
    {
        //Doesnt do anything if player doesnt have money or nothing is selected
        if (CurrentlySellected == null || CurrentlySellected.CurrentItem == null) return;
        if (!CurrentlySellected.isEquipped) //if clicking on a box that is in the inventory
        {
            EquipmentCategory currentCategory = CurrentlySellected.CurrentItem.category;
            ItemBox TargetItemBox = GetEquipmentItemBox(currentCategory);

            if (TargetItemBox.CurrentItem == null) //if no equipped item, just equip the selected
            {
                TargetItemBox.AssignItem(CurrentlySellected.CurrentItem);
                player.Inventory.EquippedItems.Add(CurrentlySellected.CurrentItem);
                player.Inventory.CurrentItems.Remove(CurrentlySellected.CurrentItem);
                CurrentlySellected.AssignItem(null);
                UpdatePlayerItemsDisplay();
            }
            else //otherwise switch items
            {
                player.Inventory.CurrentItems.Add(TargetItemBox.CurrentItem);
                player.Inventory.EquippedItems.Remove(TargetItemBox.CurrentItem);

                player.Inventory.CurrentItems.Remove(CurrentlySellected.CurrentItem);
                player.Inventory.EquippedItems.Add(CurrentlySellected.CurrentItem);

                Item tempItem = TargetItemBox.CurrentItem;
                TargetItemBox.AssignItem(CurrentlySellected.CurrentItem);
                CurrentlySellected.AssignItem(tempItem);               
            }
        }
        else //if clicking on a equipped box, Just unequip the item
        {
            player.Inventory.CurrentItems.Add(CurrentlySellected.CurrentItem);
            player.Inventory.EquippedItems.Remove(CurrentlySellected.CurrentItem);
            CurrentlySellected.AssignItem(null);
            UpdatePlayerItemsDisplay();
        }


        player.AnimationController.UpdateEquipmentVisuals();
    }
    GameObject SelectableBoxPanel.GameObject => gameObject;
    #endregion

    public ItemBox GetEquipmentItemBox(EquipmentCategory category) 
    {
        if (category == EquipmentCategory.Head) return EquippedHead;
        if (category == EquipmentCategory.Torso) return EquippedTorso;
        if (category == EquipmentCategory.Legs) return EquippedLegs;
        else return EquippedFeet;
    }
}
