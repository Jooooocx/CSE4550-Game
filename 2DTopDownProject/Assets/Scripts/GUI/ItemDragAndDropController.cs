using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController: MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject itemIcon;
    [SerializeField] ItemToolbarPanel toolBar;
    RectTransform iconTransform;
    Image itemIconImage;

    internal void OnClick(ItemSlot itemSelected)
    {
        if(this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSelected);
            itemSelected.Clear();
        }
        else
        {
            Item item = itemSelected.item;
            int count = itemSelected.count;

            itemSelected.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }
        UpdateIcon();
    }

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = itemIcon.GetComponent<RectTransform>();

        itemIconImage = itemIcon.GetComponent<Image>();

    }

    private void Update()
    {
        if(itemIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;

                    ItemSpawnManager.instance.SpawnItem(worldPosition, 
                        itemSlot.item, 
                        itemSlot.count);

                    itemSlot.Clear();
                    itemIcon.SetActive(false);
                }
            }
        }


    }
    
    private void UpdateIcon()
    {
        if(itemSlot.item == null)
        {
            itemIcon.SetActive(false);
        }
        else
        {
            itemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
        toolBar.Show();
    }
}
