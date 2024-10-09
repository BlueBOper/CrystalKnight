using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AskForHelp : MonoBehaviour
{
    public GameObject son;
    public Camera main;
    public AudioSource selected, chosen;
    public bool playOnce;
    // Start is called before the first frame update
    void Start()
    {
        playOnce = false;
        Color s = son.GetComponent<SpriteRenderer>().color;
        s.a = 0f;
        son.GetComponent<SpriteRenderer>().color = s;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if(playOnce == false)
        {
            selected.Play();
            playOnce = true;
        }
        
        Color s = son.GetComponent<SpriteRenderer>().color;
        s.a = 1f;
        son.GetComponent<SpriteRenderer>().color = s;

        Color f = gameObject.GetComponent<SpriteRenderer>().color;
        f.a = 0f;
        gameObject.GetComponent<SpriteRenderer>().color = f;
    }

    private void OnMouseExit()
    {
        if(playOnce)
        {
            playOnce = false;
        }
        Color s = son.GetComponent<SpriteRenderer>().color;
        s.a = 0f;
        son.GetComponent<SpriteRenderer>().color = s;

        Color f = gameObject.GetComponent<SpriteRenderer>().color;
        f.a = 1f;
        gameObject.GetComponent<SpriteRenderer>().color = f;
    }

    private void OnMouseDown()
    {
        chosen.Play();
        main.transform.position = new Vector3(-50f, 0f, -10f);
    }
}
