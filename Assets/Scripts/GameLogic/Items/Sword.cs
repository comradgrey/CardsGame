using UnityEngine;
using System.Collections;

public class Sword : Item {

    InventoryController inventory = new InventoryController();

	// Use this for initialization
    void Start()
    {
        isUsed = false;
        numberOfCell = 2;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void ActivateItem() {
        GameObject.Find("Player").GetComponent<PlayerAttributes>().damage += 1;
    }
}
