using UnityEngine;
using System.Collections;

public class Enemy : EntityAttributes {

    public int health;
    public int damage;

    public int playerHealth;
    public int playerDamage;

    public Sprite tempSprite;

    CardsGenerator generator = new CardsGenerator();
    GUI gui = new GUI();
    Raycaster raycaster = new Raycaster();

    void Start() {
        health = 2;
        damage = 1;
        tempSprite = Resources.Load<Sprite>("zeq76fkwtd");
    }

    void OnMouseDown()
    {

        if (health > 0)
        {

            if (!GameObject.Find("Player").GetComponent<PlayerController>().isDied && !this.gameObject.GetComponent<CardAttributes>().isLocked)
            {
                raycaster.LockedNeighborsCards(this.gameObject);

                if (this.gameObject.GetComponent<CardController>().numberOfClicks > 1 && health > 0)
                {

                    playerHealth = GameObject.Find("Player").GetComponent<PlayerAttributes>().health;
                    playerDamage = GameObject.Find("Player").GetComponent<PlayerAttributes>().damage;


                    playerHealth -= damage;
                    health -= playerDamage;

                    GameObject.Find("Player").GetComponent<PlayerAttributes>().health = playerHealth;
                    this.gameObject.GetComponent<Enemy>().health = health;

                    GameObject.Find("Player").GetComponent<PlayerController>().playerHealthText.text = playerHealth + " HP";

                    if (health < 1)
                    {
                        this.gameObject.GetComponent<CardAttributes>().isLocked = true;
                        GameObject item = generator.GenerateItem("antidote", 35);
                        if (item != null)
                        {
                            item.transform.parent = this.gameObject.transform;
                            item.transform.position = this.gameObject.transform.position;
                        }

                        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("emptyPlayground");
                        raycaster.UnlockedNeighborsCards(this.gameObject);
                    }
                }
            }
        }
        gui.DrawEnemyStats(this.gameObject);
    }   
}
