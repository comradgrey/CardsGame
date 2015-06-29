using UnityEngine;
using System.Collections;

public class SphereOfManaController : BonusController {


    void Start()
    {
        alterableAttribute = GameObject.Find("Player").GetComponent<PlayerAttributes>().mana;
        alterableValue = this.gameObject.GetComponent<SphereOfManaAttributes>().manaRegeneration;
    }



    public override void DrawChangesPlayerAttributes()
    {
        alterableAttribute = GameObject.Find("Player").GetComponent<PlayerAttributes>().mana;
        GameObject.Find("Player").GetComponent<PlayerController>().playerManaText.text = this.alterableAttribute.ToString() + " Mana";
    }

    public override void ChangeAttribute(int alterableAttribute, int alterableValue)
    {
        
        this.alterableAttribute = GameObject.Find("Player").GetComponent<PlayerAttributes>().mana;
        this.alterableAttribute += alterableValue;
        GameObject.Find("Player").GetComponent<PlayerAttributes>().mana = this.alterableAttribute;
        
    }
}
