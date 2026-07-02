using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    public TextMeshProUGUI inventoryText;

    private Dictionary<string, int> items = new Dictionary<string, int>();

    private void Awake()
    {
        Instance = this;
        UpdateUI();
    }

    public void AddItem(string itemName, int amount)
    {
        if (items.ContainsKey(itemName))
            items[itemName] += amount;
        else
            items.Add(itemName, amount);

        UpdateUI();
    }

    void UpdateUI()
    {
        inventoryText.text = "";

        foreach (var item in items)
        {
            inventoryText.text += $"{item.Key}: {item.Value}\n";
        }
    }
}