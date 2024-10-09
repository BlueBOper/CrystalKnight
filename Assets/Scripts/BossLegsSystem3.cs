using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLegsSystem3 : MonoBehaviour
{
    public float maxHP, currentHP, damage, damage2;
    public GameObject bullet;
    public Animator animator;
    public SpriteRenderer bloody;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            bloody.sortingOrder = 14;
            bullet = collision.gameObject;
            currentHP = currentHP - damage;
            bullet.GetComponent<Animator>().SetTrigger("hit");
            bullet.GetComponent<ForBullets>().speed = 0f;
            bullet.GetComponent<Collider2D>().enabled = false;
            Invoke("BloodyShow", 0.08f);
            Invoke("DoDestroy2", 0.5f);
        }

        if (collision.gameObject.tag == "Laser")
        {
            bloody.sortingOrder = 14;
            currentHP = currentHP - damage2;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("BloodyShow", 0.08f);
        }
    }

    void BloodyShow()
    {
        bloody.sortingOrder = -1;
    }

    void DoDestroy2()
    {
        Destroy(bullet);
    }
}
