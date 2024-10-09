using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPartQUITGAME : MonoBehaviour
{
    public GameObject son;
    public Camera main;
    public AudioSource chosen, selected;
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
        if (Input.GetKeyDown(KeyCode.Escape) && main.transform.position.x < 30f)
        {
            chosen.Play();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    private void OnMouseOver()
    {
        if (playOnce == false)
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
        if (playOnce)
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
