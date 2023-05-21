using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour, SelectableBoxPanel
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region SelectableBoxPanelInterface
    public void SelectBox()
    {
        Debug.Log("Selecting Inventory Box.");
    }
    GameObject SelectableBoxPanel.GameObject => gameObject;
    #endregion
}
