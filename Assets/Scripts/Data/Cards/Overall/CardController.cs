using UnityEngine;
using System.Collections;

public class CardController : MonoBehaviour {

    public int numberOfClicks = 0;
    private CardAttributes cardAttributes;

    void Start()
    {
        cardAttributes = this.gameObject.GetComponent<CardAttributes>();
    }


    void OnMouseDown()
    {
        if (!this.gameObject.GetComponent<CardAttributes>().isLocked) {
            numberOfClicks++;
            cardAttributes.isOpen = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cardAttributes.cardSprite;
        }   
    }
}
