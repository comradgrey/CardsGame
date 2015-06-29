using UnityEngine;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour {

    public Dictionary<string, int> itemsInInventory = new Dictionary<string, int>();
    public int countInFirstCell;
    public Transform invenotry;
    Transform countInCell;
    Sprite[] sprites;

    void Start() {
        countInFirstCell = 0;
    }

    public void AddToCell(GameObject item, int cellNumber)
    {
        if (PlayerPrefs.GetInt("countInFirstCell") == 0)
        {
            countInFirstCell++;
            PlayerPrefs.SetInt("countInFirstCell", countInFirstCell);
        }

        else {
            countInFirstCell = PlayerPrefs.GetInt("countInFirstCell");
            countInFirstCell++;
            PlayerPrefs.SetInt("countInFirstCell", countInFirstCell);
        }
        
        
        invenotry = GameObject.Find("Inventory").transform;
        item.gameObject.transform.parent = invenotry.GetChild(cellNumber - 1);
        item.gameObject.transform.position = invenotry.GetChild(cellNumber - 1).transform.position;
    }

    public void AddWeaponToCell(GameObject item, int cellNumber)
    {
        if (PlayerPrefs.GetInt("countInSecondCell") == 0)
        {
            countInFirstCell++;
            PlayerPrefs.SetInt("countInSecondCell", countInFirstCell);
        }

        else
        {
            countInFirstCell = PlayerPrefs.GetInt("countInSecondCell");
            countInFirstCell++;
            PlayerPrefs.SetInt("countInSecondCell", countInFirstCell);
        }

        //countInCell = GameObject.Find("Inventory").gameObject.transform.GetChild(1).gameObject.transform.GetChild(1);
        Debug.Log(item.gameObject);
        //item.gameObject.SetActive(true);
        invenotry = GameObject.Find("Inventory").transform;
        item.gameObject.transform.parent = invenotry.GetChild(cellNumber - 1);
        item.gameObject.transform.position = invenotry.GetChild(cellNumber - 1).transform.position;
    }

    public void RemoveToCell(GameObject item) {
        countInFirstCell = PlayerPrefs.GetInt("countInFirstCell");
        countInFirstCell--;
        PlayerPrefs.SetInt("countInFirstCell", countInFirstCell);
        Destroy(item);
    }

    public void DrawCount(int cellNumber) {
        if (cellNumber == 1)
        {
            countInFirstCell = PlayerPrefs.GetInt("countInFirstCell");
            sprites = Resources.LoadAll<Sprite>("font");
            countInCell = GameObject.Find("Inventory").gameObject.transform.GetChild(cellNumber - 1).gameObject.transform.GetChild(cellNumber - 1);
            if (countInFirstCell > 1)
            {
                countInCell.gameObject.SetActive(true);
                countInCell.GetComponent<SpriteRenderer>().sprite = sprites[25 + countInFirstCell];
            }
            else
            {
                countInCell.gameObject.SetActive(false);
            }
        }  
    }
}
