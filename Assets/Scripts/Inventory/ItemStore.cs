using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ItemStore : MonoBehaviour
{
    
    public List<Item> Items;

    public Item GetById(int Id)
    {
        return Items.Where(x => x.Id == Id).FirstOrDefault();
    }
}