using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

[Serializable]
public class Inventory : MonoBehaviour
{
    public List<Item> Items;
    public List<ItemSlot> itemSlots;
    public ItemStore ItemStore;

    GameState gameState;

    void Start()
    {
        Items = new List<Item>();
        gameState = GameState.Instance;

        if(gameState.Inventory != null)
        {
            Items = gameState.Inventory.Items;
            itemSlots = gameState.Inventory.itemSlots;
        }
        else
        {
            gameState.Inventory = this;
        }
    }

    public void AddItem(int itemId)
    {
        var item = ItemStore.GetById(itemId);
        if (item != default(Item))
        {
            Items.Add(item);
            var freeSlot = itemSlots.Where(x => !x.hasItem).FirstOrDefault();
            freeSlot.AddToSlot(item.gameObject);
            UpdateGameState();
        }        
    }

    public void RemoveItem(GameObject item)
    {
        var itemToRemove = Items.SingleOrDefault(x => x.gameObject == item);
        if (itemToRemove != default(Item))
        {
            Items.Remove(itemToRemove);
            RemoveFromSlot(GetSlotByItem(item));
            item.SetActive(false);
            UpdateGameState();
        }
    }

    public void RemoveFromSlot(ItemSlot slot)
    {
        slot.RemoveItem();
        UpdateGameState();
    }

    public ItemSlot GetSlotByItem(GameObject item)
    {
        return itemSlots.Where(x => x.attachedItem == item).FirstOrDefault(); 
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

    void UpdateGameState()
    {
        gameState.Inventory.Items = Items;
        gameState.Inventory.itemSlots = itemSlots;
    }
}
