using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ItemStore : ScriptableObject
{
    List<Item> Items;

    void Awake()
    {
        Items = new List<Item>();
        InitializeItems();
    }

    void InitializeItems()
    {
        Items.Add(new Item(1, "testItem", null));
    }

    public Item GetById(int Id)
    {
        return Items.Where(x => x.Id == Id).FirstOrDefault();
    }
}