using UnityEngine;
using System.Collections.Generic;

public class TotemDamageController : MonoBehaviour {

    CardAttributes CardAttributes;
    GameObject[] enemies;
    Sprite[] sprites = new Sprite[10];

    [HideInInspector]
    public Sprite cardSprite;

    public Transform player;
    int priceOfMana;
    Transform priceOfmanaText;

    private bool isBuffer = false;

    int buffDamage;

    GUI gui = new GUI();


    // Use this for initialization
    void Start()
    {
        priceOfMana = this.gameObject.GetComponent<TotemDamageAttributes>().priceOfMana;
        buffDamage = this.gameObject.GetComponent<TotemDamageAttributes>().buffDamage;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        sprites = Resources.LoadAll<Sprite>("font");
        CardAttributes = this.gameObject.GetComponent<CardAttributes>();
        cardSprite = this.GetComponent<SpriteRenderer>().sprite;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("zeq76fkwtd");
        priceOfmanaText = this.gameObject.transform.GetChild(6);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown() {
        if (!this.gameObject.GetComponent<CardAttributes>().isLocked || !this.gameObject.GetComponent<CardAttributes>().isEmpty)
        {
            
            this.gameObject.GetComponent<CardAttributes>().isOpen = true;
            isBuffer = true;
            priceOfmanaText.gameObject.SetActive(true);
            priceOfmanaText.GetComponent<SpriteRenderer>().sprite = sprites[25 + this.gameObject.GetComponent<TotemDamageAttributes>().buffDamage];

            if (!GameObject.Find("Player").GetComponent<PlayerController>().isDied)
            {

                if (!this.gameObject.GetComponent<CardAttributes>().isEmpty && isBuffer && this.gameObject.GetComponent<CardController>().numberOfClicks < 2)
                {
                    
                    foreach (GameObject t in enemies)
                    {
                        
                        t.GetComponent<Enemy>().damage += buffDamage;
                        
                        int temp = 26 + buffDamage;
                        gui.DrawEnemyStats(t);
                    }
                    
                    
                    
                }
                if (this.gameObject.GetComponent<CardController>().numberOfClicks == 2 && player.GetComponent<PlayerAttributes>().mana > priceOfMana)
                {
                    Debug.Log(player.GetComponent<PlayerAttributes>().mana);
                    Debug.Log(buffDamage);
                    player.GetComponent<PlayerAttributes>().mana -= priceOfMana;
                    player.GetComponent<PlayerController>().playerManaText.text = player.GetComponent<PlayerAttributes>().mana + " Mana";
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("emptyPlayground");
                    this.gameObject.GetComponent<CardAttributes>().isEmpty = true;

                    foreach (GameObject t in enemies)
                    {
                        t.GetComponent<Enemy>().damage -= buffDamage;
                        int temp = t.GetComponent<Enemy>().damage;

                        gui.DrawEnemyStats(t);
                    }

                    this.gameObject.GetComponent<CardAttributes>().isLocked = true;
                    isBuffer = false;
                    priceOfmanaText.gameObject.SetActive(false);
                }


            }
        }
    
    }
}
