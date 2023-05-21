using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory", order = 2)]
public class Inventory : ScriptableObject
{
    public int CurrentMoney = 1000;
    public List<Item> CurrentItems;


 

    public void EditMoney(int delta) 
    {
        CurrentMoney += delta;
        Singleton.Instance.UIManager.UpdateCurrentMoney();
    }

}
