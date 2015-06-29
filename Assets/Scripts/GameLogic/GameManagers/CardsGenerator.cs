using UnityEngine;
using System.Collections.Generic;

public class CardsGenerator : MonoBehaviour {

    public Dictionary<string, string> filledValueCards = new Dictionary<string, string>();
    public Dictionary<string, int> numberCardsOfType = new Dictionary<string, int>();
    public Dictionary<string, int> cardsOfKind = new Dictionary<string, int>();
    private List<int> emptyCells = new List<int>();
    int counterOfCards = 21;

    int tempValue;
    string tempKey;

    public Dictionary<string, string> GenerateCards()
    {
        GenerateListCells();

        GenerateCard(1, "portal");
        GenerateCard(15, "skeletWarrior");
        GenerateCard(3, "emptyPlayground", "bonus", 50);
        GenerateCard(3, "sphereOfHealth", "bonus", 25);
        GenerateCard(3, "sphereOfMana", "bonus", 25, true);
        GenerateCard(1, "totemDamage", "debuff", 50);
        GenerateCard(1, "skeletWarrior", "debuff", 50, true);
        GenerateCard(1, "skeletWarrior", "elite", 60);
        GenerateCard(1, "deadDog", "elite", 40, true);
        
        return filledValueCards;
    }


    void GenerateListCells() {
        for (int i = 1; i < 22; i++)
        {
            emptyCells.Add(i);
        }
    }


    void GenerateCard(int numberOfCards, string name, string type = "empty", int chance = 100, bool isLast = false)
    {
        if (type.Equals("empty"))
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                GenerateEntity(name);
            }
        }
        else {
            if (!isLast) {
                cardsOfKind.Add(name, chance);
            }
            else {
                cardsOfKind.Add(name, chance);
                GenerateChancesEntity(numberOfCards, cardsOfKind);
                cardsOfKind.Clear();
            }
             
        }

    }


    public GameObject GenerateItem(string nameItem, int chance) {
        if (nameItem.Equals("antidote"))
        {
            if (GenerateTrue(chance))
            {
                return Instantiate(Resources.Load<GameObject>("Entity/Antidote"));

            }
            else
            {
                return null;
            }           
        }
        else if (nameItem.Equals("sword")) {
            if (GenerateTrue(chance))
            {
                return Instantiate(Resources.Load<GameObject>("Entity/Sword"));

            }
            else
            {
                return null;
            } 
        }
        else {
            return null;
        }

        
    }


    bool GenerateTrue(int chance) {
        int number = Random.Range(1, 101);
        if (number <= chance)
        {
            return true;
        }
        else {
            return false;
        }
    }

    void GenerateEntity(string type)
    {  
        int emptyPos = Random.Range(0, counterOfCards);
        filledValueCards.Add("Card" + (emptyCells[emptyPos]).ToString(), type);
        RefreshEmptyCells(emptyCells, emptyPos);
        counterOfCards -= 1;
    }


    void GenerateChancesEntity(int numberOfCards, Dictionary<string, int> cards)
    {
        int k = 0;
        int min = 1;
        int max = 100;
        string value = null;
        for (int i = 0; i < numberOfCards; i++)
        {
            foreach (KeyValuePair<string, int> dict in cards)
            {
                if (value == null)
                {
                    k = Random.Range(min, max);
                    if (k < dict.Value)
                    {
                        value = dict.Key;
                        GenerateEntity(value);
                    }
                    else
                    {
                        max = max - dict.Value;
                    }
                }
            }
            value = null;
            min = 1;
            max = 100;
        }
    }


    void RefreshEmptyCells(List<int> list, int exception)
    {
        list.Remove(list[exception]);
        list.Sort();
    }

}
