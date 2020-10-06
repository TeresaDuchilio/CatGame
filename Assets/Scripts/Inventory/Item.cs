using UnityEngine;

public class Item
{
    public int Id;
    public string name;
    public Sprite image;

    public Item(int Id, string name, Sprite image)
    {
        this.Id = Id;
        this.name = name;
        this.image = image;
    }
}
