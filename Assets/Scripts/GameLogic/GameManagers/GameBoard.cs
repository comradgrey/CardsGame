using UnityEngine;
using System.Collections.Generic;

public class GameBoard : MonoBehaviour {

    CardsGenerator generator = new CardsGenerator();
    public Dictionary<string, string> cardsValue = new Dictionary<string, string>();
    public Dictionary<string, string> dictionaryAttributes = new Dictionary<string, string>();
    public Dictionary<string, string> dictionaryControllers = new Dictionary<string, string>();
    public Dictionary<string, string> dictionaryTypes = new Dictionary<string, string>();

    void Awake() {
        dictionaryAttributes.Add("portal", "PortalAttributes");
        dictionaryControllers.Add("portal", "PortalController");
        dictionaryTypes.Add("portal", "Portal");

        dictionaryControllers.Add("skeletWarrior", "Enemy");
        dictionaryTypes.Add("skeletWarrior", "Enemy");

        dictionaryAttributes.Add("sphereOfHealth", "SphereOfHealthAttributes");
        dictionaryControllers.Add("sphereOfHealth", "SphereOfHealthController");
        dictionaryTypes.Add("sphereOfHealth", "Bonus");

        dictionaryAttributes.Add("sphereOfMana", "SphereOfManaAttributes");
        dictionaryControllers.Add("sphereOfMana", "SphereOfManaController");
        dictionaryTypes.Add("sphereOfMana", "Bonus");

        dictionaryAttributes.Add("totemDamage", "TotemDamageAttributes");
        dictionaryControllers.Add("totemDamage", "TotemDamageController");
        dictionaryTypes.Add("totemDamage", "Debuff");

        dictionaryTypes.Add("deadDog", "Elite");
        dictionaryControllers.Add("deadDog", "DeadDog");


    }

	// Use this for initialization
	void Start () {

        cardsValue = generator.GenerateCards();
        /*foreach (KeyValuePair<string, string> dict in cardsValue)
        {
            Debug.Log(dict.Key + "=>" + dict.Value);
            
        }*/
        DrawCards();
	}
	
    public void DrawCards() {
        foreach (KeyValuePair<string, string> dict in cardsValue)
        {
            Debug.Log(dict.Key + "=>" + dict.Value);
        }

        foreach (KeyValuePair<string, string> dict in cardsValue)
        {
            SetCardSprite(dict.Key, dict.Value);
            SetCardAttributes(dict.Key, dict.Value);
            SetCardType(dict.Key, dict.Value);
            SetCardController(dict.Key, dict.Value);
            SetCardBack(dict.Key);
        }
    }


    void SetCardSprite(string cardName, string spriteName) {
        GameObject.Find(cardName).GetComponent<CardAttributes>().cardSprite = Resources.Load<Sprite>(spriteName);
    }


    void SetCardController(string cardName, string type)
    {
        foreach (KeyValuePair<string, string> dict in dictionaryControllers)
        {
            if (type.Equals(dict.Key))
            {
                GameObject.Find(cardName).AddComponent(System.Type.GetType(dict.Value));
            }
        }
    }


    void SetCardAttributes(string cardName, string type)
    {
        foreach (KeyValuePair<string, string> dict in dictionaryAttributes)
        {
            if (type.Equals(dict.Key))
            {
                GameObject.Find(cardName).AddComponent(System.Type.GetType(dict.Value));
            }
        }
       
        
    }


    void SetCardType(string cardName, string type)
    {
        foreach (KeyValuePair<string, string> dict in dictionaryTypes)
        {
            if (type.Equals(dict.Key))
            {
                GameObject.Find(cardName).tag = dict.Value;
            }
        }
    }


    void SetCardBack(string cardName)
    {
        
        GameObject.Find(cardName).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("zeq76fkwtd");
    }


}
