using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
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
        freeSlot.AddToSlot(item.gameObject);
    }

    public void RemoveItem(GameObject item)
    {
        var itemToRemove = Items.SingleOrDefault(x => x.gameObject == item);
        if (itemToRemove != default(Item))
        {
            Items.Remove(itemToRemove);
            RemoveFromSlot(GetSlotByPosition(item.transform.position));
        }
    }

    public void RemoveFromSlot(ItemSlot slot)
    {
        slot.RemoveItem();
    }

    public ItemSlot GetSlotByPosition(Vector2 position)
    {
        return itemSlots.Where(x => x.GetComponent<RectTransform>().anchoredPosition == position).FirstOrDefault();
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
