using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBossBullet : MonoBehaviour
{
    private float speed;
    public Animator anime;
    GameObject playerBullet;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestroy", 2f);
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
    }

    void SelfDestroy()
    {
        if(playerBullet != null)
        {
            Destroy(playerBullet);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            speed = 0f;
            anime.SetTrigger("hit");
            Invoke("SelfDestroy", 0.5f);
        }

        if (collision.gameObject.tag == "Player")
        {
            speed = 0f;
            anime.SetTrigger("hit");
            gameObject.GetComponent<Collider2D>().enabled = false;
            Invoke("SelfDestroy", 0.5f);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            speed = 0f;
            anime.SetTrigger("hit");
            gameObject.GetComponent<Collider2D>().enabled = false;
            
            playerBullet = collision.gameObject;
            collision.gameObject.GetComponent<Animator>().SetTrigger("hit");
            collision.gameObject.GetComponent<ForBullets>().speed = 0f;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;

            Invoke("SelfDestroy", 0.5f);
        }
    }
}
