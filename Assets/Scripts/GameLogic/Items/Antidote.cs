using UnityEngine;
using System.Collections;

public class Antidote : Item {

    InventoryController inventory = new InventoryController();

	// Use this for initialization
	void Start () {
        isUsed = true;
        numberOfCell = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public override void Use()
    {
        inventory.RemoveToCell(this.gameObject);
        GameObject.Find("Player").GetComponent<PlayerAttributes>().isPoisoned = false;
    }
}
