using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public string itemName = "Rock";
    public int amount =1;

   private void OnTriggerEnter(Collider other)
   {
        if(!other.CompareTag("Player"))
        return;

        InventoryUI.Instance.AddItem(itemName, amount);
        
        Destroy(gameObject);

   }
}
