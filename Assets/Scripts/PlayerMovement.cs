using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private AnimationController animationController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = movementInput * speed;
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
        animationController.SetAnimationState(movementInput);
    }
}
