using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] GameObject FirstSelected;
    [SerializeField] ItemBox CurrentlySellected;
    [SerializeField] Vendor Vendor;
    public List<ItemBox> ItemSpots;
    public List<ItemBox> SellingItemSpots;

    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;
    public TextMeshProUGUI ItemCost;

    private void OnEnable()
    {
        int spotIndex = 0;
        foreach (Item item in Vendor.Items)
        {
            if (spotIndex > 29)
            {
                Debug.LogError("List index out of range!");
                break;
            }


            ItemSpots[spotIndex].AssignItem(item);
            spotIndex++;
        }

        Singleton.Instance.currentPlayer.playerActions.EventSystem.SetSelectedGameObject(FirstSelected);

    }

    private void FixedUpdate()
    {
        HandleBoxSelection();
    }


    private void HandleBoxSelection() 
    {
        //Handle selection box update
        ItemBox mostRecentSelection = Singleton.Instance.currentPlayer.playerActions.EventSystem.currentSelectedGameObject.GetComponent<ItemBox>();
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


}
