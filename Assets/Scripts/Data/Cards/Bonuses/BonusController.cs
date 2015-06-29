using UnityEngine;
using System.Collections;

public abstract class BonusController : MonoBehaviour
{

    public int alterableAttribute;
    public int alterableValue;


    void OnMouseDown()
    {
        if (!this.gameObject.GetComponent<CardAttributes>().isLocked)
        {
            this.gameObject.GetComponent<CardAttributes>().isOpen = true;
            if (!GameObject.Find("Player").GetComponent<PlayerController>().isDied)
            {
                if (!this.gameObject.GetComponent<CardAttributes>().isEmpty && this.gameObject.GetComponent<CardController>().numberOfClicks > 1)
                {
                    SetEmptySprite();
                    ChangeAttribute(this.alterableAttribute, this.alterableValue);
                    DrawChangesPlayerAttributes();
                    LockedCard();
                }
            }
        }
    }


    void SetEmptySprite() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("emptyPlayground");
    }


    public abstract void ChangeAttribute(int attribute, int value);


    public abstract void DrawChangesPlayerAttributes();


    public void LockedCard() {
        this.gameObject.GetComponent<CardAttributes>().isEmpty = true;
        this.gameObject.GetComponent<CardAttributes>().isLocked = true;
    }
}
