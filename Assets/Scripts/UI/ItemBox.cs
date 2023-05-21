using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    Item CurrentItem;
    [SerializeField] Image Icon;
    Color filledCollor = new Color(255, 255, 255, 255);
    Color emptyCollor = new Color(255, 255, 255, 0);

    private void Awake()
    {
    }

    private void Start()
    {
        UpdateBoxVisual();
    }

    public void AssignItem(Item newItem) 
    {
        CurrentItem = newItem;
        UpdateBoxVisual();
    }


    public void UpdateBoxVisual() 
    {
        if (CurrentItem == null)
        {
            Icon.color = emptyCollor;
        }
        else
        {
            Icon.color = filledCollor;
            Icon.sprite = CurrentItem.Sprite;
        }
    }
}
