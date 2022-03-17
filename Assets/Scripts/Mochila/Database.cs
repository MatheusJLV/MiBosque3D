using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Database")]
public class Database : ScriptableObject
{
    public List<Item> items = new List<Item>();

    public Item FindItemInDatabase(int id)
    {
        foreach (Item item in items)
        {
            if (item.id == id)
            {
                return item;
            }
        }
        return null;
    }
}


[System.Serializable]
public class Item
{
    public int id;
    public string name;
    [TextArea(5, 5)]
    public string description;
    public bool isStackable;
    public ItemType itemType;
    public Vector2 scrollPos;
    public Sprite itemImage;
    
    public enum ItemType { SEMILLAS, HERRAMIENTAS, MISION, BASURA }

}

