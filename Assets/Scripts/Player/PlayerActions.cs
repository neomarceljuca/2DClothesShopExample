using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    //Public Input variables for other scripts' access
    public Vector2 MovementInput { get => movementInput;}
    public bool InteractInput { get => interactInput;}
    public bool ToggleInventoryInput { get => toggleInventoryInput;}
    public bool SubmitInput { get => submitInput;}

    private AnimationController animationController;
    private Vector2 movementInput;
    private bool interactInput;
    private bool toggleInventoryInput;
    private bool submitInput;

   

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

    private void OnSubmit(InputValue value) 
    {
        submitInput = value.isPressed;
    }



}
