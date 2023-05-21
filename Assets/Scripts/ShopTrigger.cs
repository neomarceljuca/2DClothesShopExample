using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{

    Collider2D shopCollider;
    public string playerTag = "Player";
    [SerializeField] GameObject InteractionSign;

    private void Awake()
    {
        shopCollider = GetComponent<Collider2D>();
        if(InteractionSign != null) InteractionSign.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Player player = other.GetComponentInParent<Player>();
            if (player != null)
            {
                InteractionSign.SetActive(true);
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
                InteractionSign.SetActive(false);
                playerComponent.CanBuy = false;
            }
        }
    }
}
