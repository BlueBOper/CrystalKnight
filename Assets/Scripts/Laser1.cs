using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x > 0.005f)
        {
            Invoke("SelfDie", 0.5f);
        }
        
    }

    private void SelfDie()
    {
        Destroy(gameObject);
    }
}
