using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour {

    public Transform right;
    public Transform left;
    public Transform top;
    public Transform bottom;

    RaycastHit2D hit, hit2, hit3, hit4;
    RaycastHit2D hit_1, hit2_1, hit3_1, hit4_1;

    public Sprite tempSprite;

    public void LockedNeighborsCards(GameObject obj) {
        SetReferences(obj);
        SetRaycasts();
        LockedCards();
    }

    public void UnlockedNeighborsCards(GameObject obj) {
        SetReferences(obj);
        SetRaycasts();
        UnlockedCards();
    }

    void SetReferences(GameObject obj) {
        tempSprite = Resources.Load<Sprite>("zeq76fkwtd");
        bottom = obj.transform.GetChild(0);
        top = obj.transform.GetChild(1);
        left = obj.transform.GetChild(2);
        right = obj.transform.GetChild(3);
    }

    void SetRaycasts()
    {
        hit = Physics2D.Linecast(right.transform.position, Vector2.right);
        hit2 = Physics2D.Linecast(left.transform.position, -Vector2.right);
        hit3 = Physics2D.Linecast(top.transform.position, Vector2.up);
        hit4 = Physics2D.Linecast(bottom.transform.position, -Vector2.up);
    }

    void LockedCards()
    {
        LockedCard(hit);
        LockedCard(hit2);
        LockedCard(hit3);
        LockedCard(hit4);
    }

    void UnlockedCards()
    {
        UnlockedCard(hit);
        UnlockedCard(hit2);
        UnlockedCard(hit3);
        UnlockedCard(hit4);
    }

    void LockedCard(RaycastHit2D hit)
    {
        if (hit.collider != null && !hit.collider.gameObject.GetComponent<CardAttributes>().isOpen)
        {
            hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("blockingCard");
            hit.collider.gameObject.GetComponent<CardAttributes>().isLocked = true;
        }
    }

    void UnlockedCard(RaycastHit2D hit)
    {
        if (hit.collider != null && !hit.collider.gameObject.GetComponent<CardAttributes>().isOpen)
        {
            hit_1 = Physics2D.Linecast(hit.collider.gameObject.transform.GetChild(3).transform.position, Vector2.right);
            hit2_1 = Physics2D.Linecast(hit.collider.gameObject.transform.GetChild(2).transform.position, -Vector2.right);
            hit3_1 = Physics2D.Linecast(hit.collider.gameObject.transform.GetChild(1).transform.position, Vector2.up);
            hit4_1 = Physics2D.Linecast(hit.collider.gameObject.transform.GetChild(0).transform.position, -Vector2.up);

            if (enemyNeighbor(hit_1, hit2_1, hit3_1, hit4_1))
            {
                hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = tempSprite;
                hit.collider.gameObject.GetComponent<CardAttributes>().isLocked = false;
            }


        }
    }

    bool enemyNeighbor(RaycastHit2D hit, RaycastHit2D hit2, RaycastHit2D hit3, RaycastHit2D hit4)
    {
        int i = 0;

        if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
        {
            if (hit.collider.gameObject.GetComponent<CardAttributes>().isOpen)
            {
                if (hit.collider.gameObject.GetComponent<Enemy>().health > 0)
                {
                    i++;
                }
            }

        }

        if (hit2.collider != null && hit2.collider.gameObject.tag == "Enemy")
        {
            if (hit2.collider.gameObject.GetComponent<CardAttributes>().isOpen)
            {
                if (hit2.collider.gameObject.GetComponent<Enemy>().health > 0)
                {
                    i++;
                }
            }

        }

        if (hit3.collider != null && hit3.collider.gameObject.tag == "Enemy")
        {
            if (hit3.collider.gameObject.GetComponent<CardAttributes>().isOpen)
            {
                if (hit3.collider.gameObject.GetComponent<Enemy>().health > 0)
                {
                    i++;
                }
            }

        }

        if (hit4.collider != null && hit4.collider.gameObject.tag == "Enemy")
        {
            if (hit4.collider.gameObject.GetComponent<CardAttributes>().isOpen)
            {
                if (hit4.collider.gameObject.GetComponent<Enemy>().health > 0)
                {
                    i++;
                }
            }

        }

        if (i > 0)
        {
            return false;
        }
        else
        {
            return true;
        }



    }
}
