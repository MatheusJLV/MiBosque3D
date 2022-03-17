using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemModifyWindow : EditorWindow
{
    private static Database database;
    private static EditorWindow window;
    private static Item databaseItem;
    private static Item newItem;
    private GUILayoutOption[] options = { GUILayout.MaxWidth(150.0f), GUILayout.MinWidth(20.0f) };

    public static void ShowItemWindow(Database db, Item item)
    {
        database = db;
        window = GetWindow<ItemModifyWindow>();
        window.maxSize = new Vector2(300, 360);
        window.minSize = new Vector2(300, 360);
        databaseItem = item;
        newItem = new Item();
        newItem.id = item.id;
        newItem.name = item.name;
        newItem.itemType = item.itemType;
        newItem.itemImage = item.itemImage;
        newItem.isStackable = item.isStackable;
        newItem.description = item.description;

    }

    public void OnGUI()
    {
        DisplayItem(newItem);
        if (GUILayout.Button("Confirm"))
        {
            ModifyItem();
        }

    }
    private bool shouldDisable;
    private void DisplayItem(Item item)
    {
        GUIStyle textAreaStyle = new GUIStyle(GUI.skin.textArea);
        textAreaStyle.wordWrap = true;
        GUIStyle valueStyle = new GUIStyle(GUI.skin.label);
        valueStyle.wordWrap = true;
        valueStyle.alignment = TextAnchor.MiddleLeft;
        valueStyle.fixedWidth = 50;
        valueStyle.margin = new RectOffset(0, 50, 0, 0);

        EditorGUILayout.BeginVertical("Box");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name: ");
        item.name = EditorGUILayout.TextField(item.name, options);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Item Image: ");
        item.itemImage = (Sprite)EditorGUILayout.ObjectField(item.itemImage, typeof(Sprite), false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Type: ");
        item.itemType = (Item.ItemType)EditorGUILayout.EnumPopup(item.itemType, options);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Stackable: ");
        item.isStackable = EditorGUILayout.Toggle(item.isStackable, options);
        EditorGUILayout.EndHorizontal();
        GUILayout.Label("Description: ");
        item.description = EditorGUILayout.TextArea(item.description, textAreaStyle, GUILayout.MinHeight(100));
        EditorGUILayout.EndVertical();
    }

    private void ModifyItem()
    {
        Undo.RecordObject(database, "Item Modified");
        databaseItem.name = newItem.name;
        databaseItem.description = newItem.description;
        databaseItem.itemType = newItem.itemType;
        databaseItem.isStackable = newItem.isStackable;
        databaseItem.itemImage = newItem.itemImage;
        EditorUtility.SetDirty(database);
        window.Close();
    }


}