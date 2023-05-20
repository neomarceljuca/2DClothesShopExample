using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{

    Collider2D shopCollider;

    private void Awake()
    {
        shopCollider = GetComponent<Collider2D>();
    }
}
