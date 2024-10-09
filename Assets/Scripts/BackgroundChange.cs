using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public GameObject blue, b1, b2, b3, b4;
    public bool a1, a2, a1to2;
    // Start is called before the first frame update
    void Start()
    {
        a1 = a2 = false;
        a1to2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(blue.GetComponent<BossLogic>().trans1 == false && a1 == false)
        {
            Colours11();
        }
        else if(blue.GetComponent<BossLogic>().trans1 == false && a1)
        {
            Colours12();
        }

        if (blue.GetComponent<BossLogic>().trans1 && a1to2 == false)
        {
            Colours1to2();
        }

        if (blue.GetComponent<BossLogic>().trans1 && a1to2 && a2 == false)
        {
            Colours21();
        }
        else if (blue.GetComponent<BossLogic>().trans1 && a1to2 && a2)
        {
            Colours22();
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

    void Colours1to2()
    {
        Color bb1 = b1.GetComponent<SpriteRenderer>().color;
        Color bb2 = b2.GetComponent<SpriteRenderer>().color;
        if (bb2.a >= 0.001f && a1to2 == false)
        {
            bb1.a -= 0.5f * Time.deltaTime;
            b1.GetComponent<SpriteRenderer>().color = bb1;
            bb2.a -= 0.5f * Time.deltaTime;
            b2.GetComponent<SpriteRenderer>().color = bb2;
        }
        else
        {
            bb1.a = 0f;
            b1.GetComponent<SpriteRenderer>().color = bb1;
            bb2.a = 0f;
            b2.GetComponent<SpriteRenderer>().color = bb2;
            a1to2 = true;
        }
    }

    void Colours21()
    {
        Color bb3 = b3.GetComponent<SpriteRenderer>().color;
        if (bb3.a >= 0.001f && a2 == false)
        {
            bb3.a -= 0.5f * Time.deltaTime;
            b3.GetComponent<SpriteRenderer>().color = bb3;
        }
        else
        {
            Invoke("TrueA2", 2f);
        }
    }

    void TrueA2()
    {
        a2 = true;
    }

    void Colours22()
    {
        Color bb3 = b3.GetComponent<SpriteRenderer>().color;
        if (bb3.a <= 0.999f && a2)
        {
            bb3.a += 0.5f * Time.deltaTime;
            b3.GetComponent<SpriteRenderer>().color = bb3;
        }
        else
        {
            Invoke("FalseA2", 2f);
        }
    }

    void FalseA2()
    {
        a2 = false;
    }
}
