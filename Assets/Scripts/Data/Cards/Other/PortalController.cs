using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

    [HideInInspector]
    public Sprite cardSprite;

    private int playerHealth;
    private int playerMana;
    private int currentLevel;




    void Start()
    {
        
        cardSprite = this.GetComponent<SpriteRenderer>().sprite;
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("zeq76fkwtd");
    }


    void OnMouseDown()
    {
        if (this.gameObject.GetComponent<CardController>().numberOfClicks > 1)
        {
            if (!GameObject.Find("Player").GetComponent<PlayerController>().isDied)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cardSprite;
                playerHealth = GameObject.Find("Player").GetComponent<PlayerAttributes>().health;
                playerMana = GameObject.Find("Player").GetComponent<PlayerAttributes>().mana;
                currentLevel = GameObject.Find("Player").GetComponent<PlayerController>().currentLevel;

                PlayerPrefs.SetInt("playerHealth", playerHealth);
                PlayerPrefs.SetInt("playerMana", playerMana);
                currentLevel += 1;
                PlayerPrefs.SetInt("currentLevel", currentLevel);
                Application.LoadLevel("Main");
              
            }            
        }
       


    }

}
