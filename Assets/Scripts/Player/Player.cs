using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    public Inventory Inventory;
    public PlayerActions playerActions;
    public bool CanBuy = false;


    private void Awake()
    {
        playerInput = GetComponentInChildren<PlayerInput>();
        playerActions = GetComponentInChildren<PlayerActions>();
        
        // Subscribe to the PanelShown and PanelClosed events from UIManager
        UIManager.PanelShown += OnPanelShown;
        UIManager.PanelClosed += OnPanelClosed;
    }

    private void Start()
    {
        Singleton.Instance.currentPlayer = this;
        Singleton.Instance.UIManager.UpdateCurrentMoney();
    }

    private void Update()
    {
        HandleInput();   
    }

    public void HandleInput() 
    {
        if (playerActions.InteractInput) 
        {
            if (CanBuy) Singleton.Instance.UIManager.ShowShop(true);
            playerActions.InteractInput = false;
        } 
        
        //UI Action Map
        if (playerActions.CancelInput) 
        {
            Singleton.Instance.UIManager.ClosePanel();
            playerActions.CancelInput = false;
        }
    }



    private void OnDestroy()
    {
        // Unsubscribe from the events when the script is destroyed
        // Events on this matter might be overkill in the case of the player script itself, but it is extensible for other cases
        UIManager.PanelShown -= OnPanelShown;
        UIManager.PanelClosed -= OnPanelClosed;
    }

    private void OnPanelShown()
    {
        // Switch the player's input action map to "UI"
        playerInput.SwitchCurrentActionMap("UI");
    }

    private void OnPanelClosed()
    {
        // Switch the player's input action map to "Gameplay"
        playerInput.SwitchCurrentActionMap("Player");
    }


}
