using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparkle : MonoBehaviour
{
    public ParticleSystem ps1, ps2, ps3, ps4, ps5;
    public Transform spark1, spark2, spark3, spark4, spark5, fp1, fp2, fp3, fp4, fp5;
    public bool sparkling, once;
    // Start is called before the first frame update
    void Start()
    {
        sparkling = false;
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(sparkling == false)
        {
            spark1.position = new Vector3(fp1.position.x, -5f, 0f);
            spark2.position = new Vector3(fp2.position.x, -5f, 0f);
            spark3.position = new Vector3(fp3.position.x, -5f, 0f);
            spark4.position = new Vector3(fp4.position.x, -5f, 0f);
            spark5.position = new Vector3(fp5.position.x, -5f, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(once == false)
        {
            if (collision.gameObject.tag == "BossBody")
            {
                sparkling = true;
                ps1.randomSeed = (uint)Random.Range(0, 9999999);
                ps1.Play();
                ps2.randomSeed = (uint)Random.Range(0, 9999999);
                ps2.Play();
                ps3.randomSeed = (uint)Random.Range(0, 9999999);
                ps3.Play();
                ps4.randomSeed = (uint)Random.Range(0, 9999999);
                ps4.Play();
                ps5.randomSeed = (uint)Random.Range(0, 9999999);
                ps5.Play();
                Invoke("Return", 1.2f);

                once = true;
            }

            if (collision.gameObject.tag == "BossBigLeg")
            {
                sparkling = true;
                ps1.randomSeed = (uint)Random.Range(0, 9999999);
                ps1.Play();
                ps2.randomSeed = (uint)Random.Range(0, 9999999);
                ps2.Play();
                ps3.randomSeed = (uint)Random.Range(0, 9999999);
                ps3.Play();
                ps4.randomSeed = (uint)Random.Range(0, 9999999);
                ps4.Play();
                ps5.randomSeed = (uint)Random.Range(0, 9999999);
                ps5.Play();
                Invoke("Return", 1.2f);

                once = true;
            }

            if (collision.gameObject.tag == "BossSmallLeg")
            {
                sparkling = true;
                ps1.randomSeed = (uint)Random.Range(0, 9999999);
                ps1.Play();
                ps2.randomSeed = (uint)Random.Range(0, 9999999);
                ps2.Play();
                ps3.randomSeed = (uint)Random.Range(0, 9999999);
                ps3.Play();
                ps4.randomSeed = (uint)Random.Range(0, 9999999);
                ps4.Play();
                ps5.randomSeed = (uint)Random.Range(0, 9999999);
                ps5.Play();
                Invoke("Return", 1.2f);

                once = true;
            }
        }
    }

    void Return()
    {
        sparkling = false;
        once = false;
    }
}
