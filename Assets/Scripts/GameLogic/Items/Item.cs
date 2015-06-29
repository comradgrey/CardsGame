using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour {

    [HideInInspector]
    public bool isInventory = false;
    [HideInInspector]
    public bool isUsed = false;

    [HideInInspector]
    public int numberOfCell;

    InventoryController inventory = new InventoryController();


    void OnMouseDown() {
        if (!isInventory) {
            isInventory = true;
            if (isUsed)
            {
                AddToCell(this.gameObject, numberOfCell);
            }
            
            if (!isUsed) {
                AddWeaponToCell(this.gameObject, numberOfCell);
                ActivateItem();
            }
        }
        else {
            if (isUsed) {
                Use();
            }
            
        }
        DrawCount(numberOfCell);
        
    }

    public virtual void Use() {
        Debug.Log("use item");
    }

    public virtual void ActivateItem() {
        Debug.Log("activate item");
    }

    public void DrawCount(int i) {
        inventory.DrawCount(i);
    }

    public void AddToCell(GameObject obj, int i) {
        inventory.AddToCell(obj, i);
    }

    public void AddWeaponToCell(GameObject obj, int i)
    {
        inventory.AddWeaponToCell(obj, i);
    }
}
