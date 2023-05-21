using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{

    Collider2D shopCollider;
    public string playerTag = "Player";

    private void Awake()
    {
        shopCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Player player = other.GetComponentInParent<Player>();
            if (player != null)
            {
                player.CanBuy = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Player playerComponent = other.GetComponentInParent<Player>();
            if (playerComponent != null)
            {
                playerComponent.CanBuy = false;
            }
        }
    }
}
