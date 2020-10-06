using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public List<Item> Items;
    public List<ItemSlot> itemSlots;
    ItemStore ItemStore;

    void Start()
    {
        Items = new List<Item>();
        ItemStore = ScriptableObject.CreateInstance<ItemStore>();
    }

    public void AddItem(int itemId)
    {
        var item = ItemStore.GetById(itemId);
        if (item != default(Item))
        {
            Items.Add(item);
        }
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
