using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    public Item CurrentItem { get => currentItem; }
    public bool playerCanSell = false;
    Item currentItem;
    [SerializeField] Image Icon;
    Color filledCollor = new Color(255, 255, 255, 255);
    Color emptyCollor = new Color(255, 255, 255, 0);
    [SerializeField] GameObject border;

    

    private void Start()
    {
        UpdateBoxVisual();
    }

    public void AssignItem(Item newItem) 
    {
        currentItem = newItem;
        UpdateBoxVisual();
    }


    public void UpdateBoxVisual() 
    {
        if (currentItem == null)
        {
            Icon.color = emptyCollor;
        }
        else
        {
            Icon.color = filledCollor;
            Icon.sprite = currentItem.Sprite;
        }
    }

    public void UpdateSelectionState(bool isSelected) 
    {
        if (isSelected) border.gameObject.SetActive(true);
        else border.gameObject.SetActive(false);
    }
}
