using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryPanel : ItemPanel
{
    public override void OnClick(int id)
    {
        GameManager.instance.dragAndDropController.OnClick(inventory.slots[id]);  
    }
    private void Update()
    {
        Show();
    }


}
