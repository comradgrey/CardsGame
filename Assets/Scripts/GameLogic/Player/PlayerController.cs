using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Text playerHealthText;
    public Text playerManaText;
    public Text levelText;
    public Text diedText;
    public Button restart;
    private int playerHealth;
    private int playerMana;

    Transform countInCell;
    InventoryController inventory = new InventoryController();

    private bool pauseStatus;

    [HideInInspector]
    public bool isDied = false;

    [HideInInspector]
    public int currentLevel;

	// Use this for initialization
	void Start () {
        

        //playerHealthText.rectTransform.anchoredPosition = new Vector2(325, 3);
        
        if (PlayerPrefs.GetInt("currentLevel") == 0)
        {
            currentLevel = 1;
            
        }
        else {
            currentLevel = PlayerPrefs.GetInt("currentLevel");
            GameObject.Find("Player").GetComponent<PlayerController>().levelText.text = "Level: " + currentLevel;

            if (PlayerPrefs.GetInt("countInFirstCell") > 0)
            {
                for (int i = 0; i < PlayerPrefs.GetInt("countInFirstCell"); i++)
                {
                    GameObject item = Instantiate(Resources.Load<GameObject>("Entity/Antidote"));
                    item.GetComponent<Antidote>().isInventory = true;
                    item.transform.parent = GameObject.Find("Inventory").gameObject.transform.GetChild(0).gameObject.transform;
                    item.transform.position = GameObject.Find("Inventory").gameObject.transform.GetChild(0).gameObject.transform.position;
                }
                if (PlayerPrefs.GetInt("countInFirstCell") > 1)
                {
                    countInCell = GameObject.Find("Inventory").gameObject.transform.GetChild(0).gameObject.transform.GetChild(0);
                    countInCell.gameObject.SetActive(true);
                    inventory.DrawCount(1);
                }
            }
            if (PlayerPrefs.GetInt("countInSecondCell") > 0)
            {
                GameObject item = Instantiate(Resources.Load<GameObject>("Entity/Sword"));
                item.GetComponent<Sword>().isInventory = true;
                item.transform.parent = GameObject.Find("Inventory").gameObject.transform.GetChild(1).gameObject.transform;
                item.transform.position = GameObject.Find("Inventory").gameObject.transform.GetChild(1).gameObject.transform.position;
                GameObject.Find("Player").GetComponent<PlayerAttributes>().damage += 1;
            }
        }
        playerHealth = PlayerPrefs.GetInt("playerHealth");
        playerMana = PlayerPrefs.GetInt("playerMana");
        if (playerHealth != 0)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().playerHealthText.text = playerHealth + " HP";
            this.gameObject.GetComponent<PlayerAttributes>().health = playerHealth;

            GameObject.Find("Player").GetComponent<PlayerController>().playerManaText.text = playerMana + " Mana";
            this.gameObject.GetComponent<PlayerAttributes>().mana = playerMana;
        }
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponent<PlayerAttributes>().health < 1)
        {
            restart.gameObject.SetActive(true);
            diedText.gameObject.SetActive(true);
            isDied = true;
        }
        if (Input.GetMouseButtonDown(0) && this.gameObject.GetComponent<PlayerAttributes>().isPoisoned)
        {
            GameObject.Find("Player").GetComponent<PlayerAttributes>().health -= 1;
            GameObject.Find("Player").GetComponent<PlayerController>().playerHealthText.text = GameObject.Find("Player").GetComponent<PlayerAttributes>().health + " HP";
        }
        if (this.gameObject.GetComponent<PlayerAttributes>().isPoisoned)
        {
            GameObject.Find("Player").transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (!this.gameObject.GetComponent<PlayerAttributes>().isPoisoned) {
            GameObject.Find("Player").transform.GetChild(0).gameObject.SetActive(false);
        }
	}

    public void RestartGame() {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel("Main");
    }
}
