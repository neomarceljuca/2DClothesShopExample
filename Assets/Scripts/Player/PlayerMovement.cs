using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private PlayerActions playerActions;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerActions = GetComponent<PlayerActions>();
    }

    private void FixedUpdate()
    {
        rb.velocity = playerActions.MovementInput * speed;
    }

    
}
