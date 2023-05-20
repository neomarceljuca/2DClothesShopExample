using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    public Inventory Inventory;
    private PlayerActions playerActions;


    private void Awake()
    {
        playerInput = GetComponentInChildren<PlayerInput>();
        playerActions = GetComponentInChildren<PlayerActions>();
        Singleton.Instance.currentPlayer = this;
        // Subscribe to the PanelShown and PanelClosed events from UIManager
        UIManager.PanelShown += OnPanelShown;
        UIManager.PanelClosed += OnPanelClosed;
    }

    private void Update()
    {
        HandleInput();   
    }

    public void HandleInput() 
    {
        if (playerActions.InteractInput) Singleton.Instance.UIManager.ShowShop(true);
    
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
