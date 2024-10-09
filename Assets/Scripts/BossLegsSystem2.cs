using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLegsSystem2 : MonoBehaviour
{
    public float maxHP, currentHP, damage;
    public GameObject bullet;
    public Animator animator;
    public GameObject anotherMe;
    public float forX, forY;
    public bool isDestroyed;
    public SpriteRenderer blood;
    public AudioSource broken;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        anotherMe.transform.position = new Vector3(gameObject.transform.position.x + forX,
            gameObject.transform.position.y + forY, gameObject.transform.position.z);
        isDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            DoDestroy();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            blood.sortingOrder = 12;
            bullet = collision.gameObject;
            currentHP = currentHP - damage;
            bullet.GetComponent<Animator>().SetTrigger("hit");
            bullet.GetComponent<ForBullets>().speed = 0f;
            bullet.GetComponent<Collider2D>().enabled = false;
            Invoke("BloodShows", 0.08f);
            Invoke("DoDestroy2", 0.5f);
        }
    }

    void DoDestroy()
    {
        if(isDestroyed == false)
        {
            broken.Play();
            anotherMe.transform.SetParent(null);
            anotherMe.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            anotherMe.GetComponent<Rigidbody2D>().gravityScale = 7f;
            anotherMe.GetComponent<SpriteRenderer>().sortingOrder = 21;
            anotherMe.GetComponent<Rigidbody2D>().AddForce(transform.up * 40f, ForceMode2D.Impulse);
            isDestroyed = true;
        }
        gameObject.transform.position = new Vector3(50f, 50f, 0f);
        gameObject.GetComponent<Collider2D>().enabled = false;
        anotherMe.transform.Rotate(0f, 0f, 300f * Time.deltaTime);

    }

    void BloodShows()
    {
        blood.sortingOrder = -1;
    }

    void DoDestroy2()
    {
        Destroy(bullet);
    }
}
