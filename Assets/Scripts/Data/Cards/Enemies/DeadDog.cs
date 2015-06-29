using UnityEngine;
using System.Collections;

public class DeadDog : Enemy {

    bool isPoison = false;

    CardsGenerator generator = new CardsGenerator();
    GUI gui = new GUI();
    Raycaster raycaster = new Raycaster();

	// Use this for initialization
	void Start () {
        health = 4;
        damage = 1;
	}

    void OnMouseDown()
    {

        if (health > 0)
        {

            if (!GameObject.Find("Player").GetComponent<PlayerController>().isDied && !this.gameObject.GetComponent<CardAttributes>().isLocked)
            {
                raycaster.LockedNeighborsCards(this.gameObject);

                if (health > 0)
                {
                    GameObject.Find("Player").GetComponent<PlayerAttributes>().isPoisoned = true;
                }

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
                        GameObject item = generator.GenerateItem("sword", 25);
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
	
	// Update is called once per frame
	void Update () {
        
	}
}
