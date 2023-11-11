using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class InventoryChest : MonoBehaviour, IInteracting
{
    [SerializeField] private InteractionType _interactionType;

    private List<Item> _items;

    public InteractionType InteractionType { get => _interactionType; set => _interactionType = value; }

    public UnityAction<IEnumerable<Item>> Opened;

    private void Awake()
    {
        _items = new List<Item>();
    }

    public void Interact()
    {
        Opened?.Invoke(_items);
    }

    public void PutItem(Item item)
    {
        if (item != null)
        {
            _items.Add(item);
        }
    }
}
