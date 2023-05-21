using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject InventoryPanel;
    [SerializeField] GameObject ShopPanel;
    [SerializeField] TextMeshProUGUI CurrentMoney;

    public GameObject CurrentOpenPanel;
    public delegate void PanelShownEventHandler();
    public delegate void PanelClosedEventHandler();
    public static event PanelShownEventHandler PanelShown;
    public static event PanelClosedEventHandler PanelClosed;

    public void UpdateCurrentMoney() 
    {
        CurrentMoney.text = Singleton.Instance.currentPlayer.Inventory.CurrentMoney.ToString();
    }


    public void ShowShop(bool Active) 
    {
        ShopPanel.SetActive(Active);
        CurrentOpenPanel = ShopPanel;
        PanelShown?.Invoke();
    }

    public void ShowInventory(bool Active) 
    {
        InventoryPanel.SetActive(Active);
        CurrentOpenPanel = InventoryPanel;
        PanelShown?.Invoke();
    }


    public void ClosePanel()
    {
        if (CurrentOpenPanel == null) return;
        CurrentOpenPanel.SetActive(false);
        CurrentOpenPanel = null;
        // Raise the PanelClosed event
        PanelClosed?.Invoke();
    }




}