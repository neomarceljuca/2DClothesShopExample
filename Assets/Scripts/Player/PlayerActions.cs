using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    //Public Input variables for other scripts' access
    public Vector2 MovementInput { get => movementInput;}
    public bool InteractInput { get => interactInput; set => interactInput = value; }
    public bool ToggleInventoryInput { get => toggleInventoryInput; set => toggleInventoryInput = value; }


    private AnimationController animationController;
    private Vector2 movementInput;
    private bool interactInput;
    private bool toggleInventoryInput;
 
   

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
    }


    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        animationController.SetAnimationState(movementInput);
    }

    private void OnInteract(InputValue value) 
    {
        interactInput = value.isPressed;


    }

    private void OnToggleInventory(InputValue value)
    {
        toggleInventoryInput = value.isPressed;

    }


    //UI ACTION MAP 
    public bool SubmitInput { get => submitInput; set => submitInput = value; }
    public bool CancelInput { get => cancelInput; set => cancelInput = value; }

    private bool submitInput;
    private bool cancelInput;



    private void OnSubmit(InputValue value) 
    {
        submitInput = value.isPressed;
    }
    
    private void OnCancel(InputValue value) 
    {
        cancelInput = value.isPressed;
    }




}
