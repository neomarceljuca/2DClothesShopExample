using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject InventoryPanel;
    [SerializeField] GameObject ShopPanel;
    [SerializeField] TextMeshProUGUI CurrentMoney;


    public delegate void PanelShownEventHandler();
    public delegate void PanelClosedEventHandler();
    public static event PanelShownEventHandler PanelShown;
    public static event PanelClosedEventHandler PanelClosed;

    private void Start()
    {
        UpdateCurrentMoney();
    }


    public void UpdateCurrentMoney() 
    {
        CurrentMoney.text = Singleton.Instance.currentPlayer.Inventory.CurrentMoney.ToString();
    }


    public void ShowShop(bool Active) 
    {
        ShopPanel.SetActive(Active);

        PanelShown?.Invoke();
    }

    public void ShowInventory(bool Active) 
    {
        InventoryPanel.SetActive(Active);

        PanelShown?.Invoke();
    }


    public void ClosePanel(string panelName)
    {
        // Implementation code for closing a specific UI panel

        // Raise the PanelClosed event
        PanelClosed?.Invoke();
    }




}