using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x > 0.001f)
        {
            Invoke("SelfDie", 1f);
        }
        
    }

    private void SelfDie()
    {
        Destroy(gameObject);
    }
}
