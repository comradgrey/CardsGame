using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {

    Sprite[] sprites;

    public Transform damageText;
    public Transform hpText;
    int damage;
    int health;




    public void DrawEnemyStats(GameObject enemy) {
        SetReferences(enemy);

        if (enemy.GetComponent<CardAttributes>().isOpen) {
            if (enemy.GetComponent<Enemy>().health > 0) {
                damageText.gameObject.SetActive(true);
                hpText.gameObject.SetActive(true);
                damageText.GetComponent<SpriteRenderer>().sprite = sprites[25 + damage];
                hpText.GetComponent<SpriteRenderer>().sprite = sprites[25 + health];
            }
            else {
                damageText.gameObject.SetActive(false);
                hpText.gameObject.SetActive(false);
            }

        }
    }

    void SetReferences(GameObject obj)
    {
        sprites = Resources.LoadAll<Sprite>("font");
        damageText = obj.transform.GetChild(4);
        hpText = obj.transform.GetChild(5);
        damage = obj.GetComponent<Enemy>().damage;
        health = obj.GetComponent<Enemy>().health;

    }

}
