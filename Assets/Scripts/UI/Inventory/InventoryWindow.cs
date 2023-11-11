using System.Collections.Generic;
using UnityEngine;

public class InventoryWindow : WindowDisplay
{
    [SerializeField] private InventoryChest _chest;
    [SerializeField] private ItemDisplay _itemDisplayTemplate;
    [SerializeField] private Transform _inventoryField;

    private void OnEnable()
    {
        _chest.Opened += DisplayItems;
    }

    private void DisplayItems(IEnumerable<Item> items)
    {
        ShowWindow();

        foreach (var item in items)
        {
            ItemDisplay newItem = Instantiate(_itemDisplayTemplate, _inventoryField);
            newItem.DisplayItem(item.Name, item.Cost.ToString(), item.Icon);
        }
    }

    private void OnDisable()
    {
        _chest.Opened -= DisplayItems;
    }
}
