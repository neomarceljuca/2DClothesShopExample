using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    public List<Item> Items;


    private void OnEnable()
    {
        Items = new List<Item>(Items);
    }
}
