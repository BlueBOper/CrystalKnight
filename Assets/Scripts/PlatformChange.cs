using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChange : MonoBehaviour
{
    public GameObject b1;
    public bool a1;
    // Start is called before the first frame update
    void Start()
    {
        a1 = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(a1 == false)
        {
            Colours11();
        }
        else if(a1)
        {
            Colours12();
        }
    }

    void Colours11()
    {
        Color bb1 = b1.GetComponent<SpriteRenderer>().color;
        if (bb1.a >= 0.001f && a1 == false)
        {
            bb1.a -= 0.5f * Time.deltaTime;
            b1.GetComponent<SpriteRenderer>().color = bb1;
        }
        else
        {
            Invoke("TrueA1", 2f);
        }
    }

    void TrueA1()
    {
        a1 = true;
    }

    void Colours12()
    {
        Color bb1 = b1.GetComponent<SpriteRenderer>().color;
        if (bb1.a <= 0.999f && a1)
        {
            bb1.a += 0.5f * Time.deltaTime;
            b1.GetComponent<SpriteRenderer>().color = bb1;
        }
        else
        {
            Invoke("FalseA1", 2f);
        }
    }

    void FalseA1()
    {
        a1 = false;
    }

    
}
