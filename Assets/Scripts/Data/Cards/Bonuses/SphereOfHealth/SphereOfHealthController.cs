using UnityEngine;
using System.Collections;

public class SphereOfHealthController : BonusController {


    void Start()
    {
        alterableAttribute = GameObject.Find("Player").GetComponent<PlayerAttributes>().health;
        alterableValue = this.gameObject.GetComponent<SphereOfHealthAttributes>().healthRegeneration;
    }



    public override void DrawChangesPlayerAttributes()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().playerHealthText.text = this.alterableAttribute.ToString() + " HP";
    }

    public override void ChangeAttribute(int alterableAttribute, int alterableValue)
    {
        this.alterableAttribute = GameObject.Find("Player").GetComponent<PlayerAttributes>().health;
        this.alterableAttribute += alterableValue;
        GameObject.Find("Player").GetComponent<PlayerAttributes>().health = this.alterableAttribute;
    }
}
