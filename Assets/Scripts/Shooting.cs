using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float fireTime, nextFire;
    public AudioSource firing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (Time.time > nextFire)
            {
                firing.Play();
                nextFire = Time.time + fireTime;
                Instantiate(bullet, transform.position, transform.rotation);
            }
            //Shoot();
        }
    }

    void Shoot()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireTime;
            Instantiate(bullet, transform.position, transform.rotation);
        }
        
    }
}
