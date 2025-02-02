using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBullets : MonoBehaviour
{
    public float speed;
    public bool goToLeft, goToRight, goUp;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
        player = GameObject.FindGameObjectWithTag("Player");
        if(Input.GetKey(KeyCode.W) ||   Input.GetKey(KeyCode.UpArrow))
        {
            goUp = true;
        }

        if (player.GetComponent<Move>().toLeft)
        {
            goToLeft = true;
            goToRight = false;
        }

        if (player.GetComponent<Move>().toRight)
        {
            goToRight = true;
            goToLeft = false;
        }

        Invoke("DoDestroy", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (goToLeft & goUp == false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        if (goToRight & goUp == false)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }

        if (goUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
    }

    private void DoDestroy()
    {
        Destroy(gameObject);
    }
}
