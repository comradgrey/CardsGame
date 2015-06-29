using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

    public bool isInventory = false;

    InventoryController inventory = new InventoryController();


    void OnMouseDown() {
        if (!isInventory)
        {
            isInventory = true;
            inventory.AddToCell(this.gameObject, 1);
            
        }
        else {
            inventory.RemoveToCell(this.gameObject);
            GameObject.Find("Player").GetComponent<PlayerAttributes>().isPoisoned = false;
        }
        inventory.DrawCount(1);
    }

}
