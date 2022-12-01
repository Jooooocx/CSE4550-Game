using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject toolbarPanel;
    // [SerializeField] ItemPanel panelScript;
    // [SerializeField] ItemPanel toolbarPanelScript;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            panel.SetActive(!panel.activeInHierarchy);
            // toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
        }
    }
    // public void PanelShow()
    // {
        
    //     // ItemPanel panelScript = panel.GetComponent(typeof(ItemPanel));
    //     panelScript.Show();
    //     toolbarPanelScript.Show();
    // }
}
