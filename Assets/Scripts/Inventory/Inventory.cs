using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public List<Item> Items;
    public List<ItemSlot> itemSlots;
    public ItemStore ItemStore;

    void Start()
    {
        Items = new List<Item>();
    }

    public void AddItem(int itemId)
    {
        var item = ItemStore.GetById(itemId);
        if (item != default(Item))
        {
            Items.Add(item);
        }

        var freeSlot = itemSlots.Where(x => !x.hasItem).FirstOrDefault();
        freeSlot.AddToSlot(item.UIElement);
    }

    public void RemoveItem(int itemId)
    {
        var itemToRemove = Items.SingleOrDefault(s => s.Id == itemId);
        if (itemToRemove != default(Item))
        {
            Items.Remove(itemToRemove);
        }
    }

    public bool HasItem(int itemId)
    {
        var item = ItemStore.GetById(itemId);
        if (item != default(Item))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
