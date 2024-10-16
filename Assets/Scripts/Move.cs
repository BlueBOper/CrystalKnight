using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public bool onTheGround;
    public float groundDistance;
    public LayerMask groundLayer;
    public AudioSource getReady, battleStarts;
    public bool canDodge = true;
    public bool canJump = true;
    public bool toRight, toLeft;
    public bool dead, stop;
    public bool protect;
    public bool isDodge;
    public float speed = 1.0f;
    public float jumpHeight;
    public GameObject body, ready;
    Animator anime;
    public Rigidbody2D playerBody;
    public Image hp;
    public float currentHP, maxHP, bodyDamage, bigLegDamge, smallLegDamage, bigBulletDamage, smallBulletDamage;
    public Collider2D bossBody, bossBigLeft, bossBigRight, bossSmallLeft, bossSmallRight, player;
    public SpriteRenderer bodySprite, leftSprite, rightSprite;
    public float laserDamage;
    public bool t1, t2, t3, t4, t5, t6, t7, tfinish, canChose, chosen;
    public Transform tt1, tt2, tt3, tt4, tt5, tt6, tt7, getready;
    public GameObject p1, p2, p3, p4, p5, p6, p7, p;
    public bool begin;
    public SpriteRenderer blood1, blood2, blood3;
    public Transform hardness;
    public AudioSource chosenSound, broken, hurt, jump, dodge;
    // Start is called before the first frame update
    void Start()
    {
        getReady.Play();
        hardness.position = new Vector3(-50f, 3f, 0f);
        begin = false;
        canChose = false;
        chosen = false;
        Color pp1 = p1.GetComponent<SpriteRenderer>().color;
        Color pp2 = p2.GetComponent<SpriteRenderer>().color;
        Color pp3 = p3.GetComponent<SpriteRenderer>().color;
        Color pp4 = p4.GetComponent<SpriteRenderer>().color;
        Color pp5 = p5.GetComponent<SpriteRenderer>().color;
        Color pp6 = p6.GetComponent<SpriteRenderer>().color;
        Color pp7 = p7.GetComponent<SpriteRenderer>().color;
        pp1.a = pp2.a = pp3.a = pp4.a = pp5.a = pp6.a = pp7.a = 0f;
        p1.GetComponent<SpriteRenderer>().color = pp1;
        p2.GetComponent<SpriteRenderer>().color = pp2;
        p3.GetComponent<SpriteRenderer>().color = pp3;
        p4.GetComponent<SpriteRenderer>().color = pp4;
        p5.GetComponent<SpriteRenderer>().color = pp5;
        p6.GetComponent<SpriteRenderer>().color = pp6;
        p7.GetComponent<SpriteRenderer>().color = pp7;
        tt1.position = tt2.position = tt3.position = tt4.position = tt5.position = tt6.position = tt7.position = new Vector3(-50f, 2.4f, 0f);
        p.transform.position = ready.transform.position = new Vector3(-50f, 0f, 0f);
        anime = body.GetComponent<Animator>();
        playerBody = gameObject.GetComponent<Rigidbody2D>();
        onTheGround = true;
        toRight = true;
        toLeft = false;
        canDodge = true;
        dead = stop = false;
        protect = false;
        isDodge = false;
        transform.position = body.transform.position = new Vector3(-6.5f, -4f, 1f);
        currentHP = maxHP;
        t1 = t2 = t3 = t4 = t5 = t6 = t7 = tfinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            chosenSound.Play();
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }

        if(t1 == false && tfinish == false)
        {
            tt1.position = new Vector3(0f, 2.4f, 0f);
            if(Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                chosenSound.Play();
                tt1.position = new Vector3(-50f, 2.4f, 0f);
                t1 = true;
            }
        }
        else if (t2 == false && t1 && tfinish == false)
        {
            tt2.position = new Vector3(0f, 2.4f, 0f);
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                chosenSound.Play();
                tt2.position = new Vector3(-50f, 2.4f, 0f);
                t2 = true;
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                chosenSound.Play();
                t1 = false;
                tt2.position = new Vector3(-50f, 2.4f, 0f);
                tt1.position = new Vector3(0f, 2.4f, 0f);
            }
        }
        else if(t3 == false && t2 && tfinish == false)
        {
            tt3.position = new Vector3(0f, 2.4f, 0f);
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                chosenSound.Play();
                tt3.position = new Vector3(-50f, 2.4f, 0f);
                t3 = true;
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                chosenSound.Play();
                t2 = false;
                tt3.position = new Vector3(-50f, 2.4f, 0f);
                tt2.position = new Vector3(0f, 2.4f, 0f);
            }
        }
        else if (t4 == false && t3 && tfinish == false)
        {
            tt4.position = new Vector3(0f, 2.4f, 0f);
            if (Input.GetMouseButton(0))
            {
                chosenSound.Play();
                tt4.position = new Vector3(-50f, 2.4f, 0f);
                t4 = true;
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                chosenSound.Play();
                t3 = false;
                tt4.position = new Vector3(-50f, 2.4f, 0f);
                tt3.position = new Vector3(0f, 2.4f, 0f);
            }
        }
        else if (t5 == false && t4 && tfinish == false)
        {
            tt5.position = new Vector3(0f, 2.4f, 0f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                chosenSound.Play();
                tt5.position = new Vector3(-50f, 2.4f, 0f);
                t5 = true;
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                chosenSound.Play();
                t4 = false;
                tt5.position = new Vector3(-50f, 2.4f, 0f);
                tt4.position = new Vector3(0f, 2.4f, 0f);
            }
        }
        else if (t6 == false && t5 && tfinish == false)
        {
            tt6.position = new Vector3(0f, 2.4f, 0f);
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
            {
                chosenSound.Play();
                tt6.position = new Vector3(-50f, 2.4f, 0f);
                t6 = true;
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                chosenSound.Play();
                t5 = false;
                tt6.position = new Vector3(-50f, 2.4f, 0f);
                tt5.position = new Vector3(0f, 2.4f, 0f);
            }
        }
        else if (t7 == false && t6 && tfinish == false)
        {
            tt7.position = new Vector3(0f, 2.4f, 0f);
            if (Input.GetKeyDown(KeyCode.S) && chosen == false)
            {
                chosenSound.Play();
                tt7.position = new Vector3(-50f, 2.4f, 0f);
                hardness.position = new Vector3(0f, 3f, 0f);
                canChose = true;
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                chosenSound.Play();
                t6 = false;
                tt7.position = new Vector3(-50f, 2.4f, 0f);
                tt6.position = new Vector3(0f, 2.4f, 0f);
            }

            if (Input.GetKeyDown(KeyCode.B) && canChose && chosen == false)
            {
                chosenSound.Play();
                hardness.position = new Vector3(-50f, 3f, 0f);
                getready.position = new Vector3(0f, 0.5f, 0f);
                currentHP = maxHP = 10000f;
                p.GetComponent<BossLogic>().laserTime = 0.6f;
                p1.GetComponent<BossLegsSystem3>().currentHP = 500f;
                p1.GetComponent<BossLegsSystem3>().maxHP = 500f;
                p4.GetComponent<BossLegsSystem2>().currentHP = 10f;
                p5.GetComponent<BossLegsSystem2>().currentHP = 10f;
                p6.GetComponent<BossLegsSystem2>().currentHP = 7f;
                p7.GetComponent<BossLegsSystem2>().currentHP = 7f;
                Invoke("READYFIGHT", 2f);
                canChose = false;
                chosen = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && canChose && chosen == false)
            {
                chosenSound.Play();
                hardness.position = new Vector3(-50f, 3f, 0f);
                getready.position = new Vector3(0f, 0.5f, 0f);
                currentHP = maxHP = 1000f;
                p.GetComponent<BossLogic>().laserTime = 0.5f;
                p1.GetComponent<BossLegsSystem3>().currentHP = 600f;
                p1.GetComponent<BossLegsSystem3>().maxHP = 600f;
                p4.GetComponent<BossLegsSystem2>().currentHP = 12f;
                p5.GetComponent<BossLegsSystem2>().currentHP = 12f;
                p6.GetComponent<BossLegsSystem2>().currentHP = 9f;
                p7.GetComponent<BossLegsSystem2>().currentHP = 9f;
                Invoke("READYFIGHT", 2f);
                canChose = false;
                chosen = true;
            }

            if (Input.GetKeyDown(KeyCode.N) && canChose && chosen == false)
            {
                chosenSound.Play();
                hardness.position = new Vector3(-50f, 3f, 0f);
                getready.position = new Vector3(0f, 0.5f, 0f);
                currentHP = maxHP = 500f;
                p.GetComponent<BossLogic>().laserTime = 0.4f;
                p1.GetComponent<BossLegsSystem3>().currentHP = 700f;
                p1.GetComponent<BossLegsSystem3>().maxHP = 700f;
                p4.GetComponent<BossLegsSystem2>().currentHP = 15f;
                p5.GetComponent<BossLegsSystem2>().currentHP = 15f;
                p6.GetComponent<BossLegsSystem2>().currentHP = 10f;
                p7.GetComponent<BossLegsSystem2>().currentHP = 10f;
                Invoke("READYFIGHT", 2f);
                canChose = false;
                chosen = true;
            }

            if (Input.GetKeyDown(KeyCode.H) && canChose && chosen == false)
            {
                chosenSound.Play();
                hardness.position = new Vector3(-50f, 3f, 0f);
                getready.position = new Vector3(0f, 0.5f, 0f);
                currentHP = maxHP = 100f;
                p.GetComponent<BossLogic>().laserTime = 0.3f;
                p1.GetComponent<BossLegsSystem3>().currentHP = 1000f;
                p1.GetComponent<BossLegsSystem3>().maxHP = 1000f;
                p4.GetComponent<BossLegsSystem2>().currentHP = 20f;
                p5.GetComponent<BossLegsSystem2>().currentHP = 20f;
                p6.GetComponent<BossLegsSystem2>().currentHP = 15f;
                p7.GetComponent<BossLegsSystem2>().currentHP = 15f;
                Invoke("READYFIGHT", 2f);
                canChose = false;
                chosen = true;
            }
        }
        else if (t7 && tfinish)
        {
            READYFIGHT();
        }

        if (Input.GetKeyDown(KeyCode.S) && tfinish == false && chosen == false)
        {
            chosenSound.Play();
            t1 = t2 = t3 = t4 = t5 = t6 = t7 = true;
            tt1.position = tt2.position = tt3.position = tt4.position = tt5.position = tt6.position = tt7.position = new Vector3(-50f, 2.4f, 0f);
            hardness.position = new Vector3(0f, 3f, 0f);
            canChose = true;
        }

        if (Input.GetKeyDown(KeyCode.B) && canChose && chosen == false)
        {
            chosenSound.Play();
            hardness.position = new Vector3(-50f, 3f, 0f);
            getready.position = new Vector3(0f, 0.5f, 0f);
            currentHP = maxHP = 10000f;
            p.GetComponent<BossLogic>().laserTime = 0.6f;
            p1.GetComponent<BossLegsSystem3>().currentHP = 500f;
            p1.GetComponent<BossLegsSystem3>().maxHP = 500f;
            p4.GetComponent<BossLegsSystem2>().currentHP = 10f;
            p5.GetComponent<BossLegsSystem2>().currentHP = 10f;
            p6.GetComponent<BossLegsSystem2>().currentHP = 7f;
            p7.GetComponent<BossLegsSystem2>().currentHP = 7f;
            Invoke("READYFIGHT", 2f);
            canChose = false;
            chosen = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && canChose && chosen == false)
        {
            chosenSound.Play();
            hardness.position = new Vector3(-50f, 3f, 0f);
            getready.position = new Vector3(0f, 0.5f, 0f);
            currentHP = maxHP = 1000f;
            p.GetComponent<BossLogic>().laserTime = 0.5f;
            p1.GetComponent<BossLegsSystem3>().currentHP = 600f;
            p1.GetComponent<BossLegsSystem3>().maxHP = 600f;
            p4.GetComponent<BossLegsSystem2>().currentHP = 12f;
            p5.GetComponent<BossLegsSystem2>().currentHP = 12f;
            p6.GetComponent<BossLegsSystem2>().currentHP = 9f;
            p7.GetComponent<BossLegsSystem2>().currentHP = 9f;
            Invoke("READYFIGHT", 2f);
            canChose = false;
            chosen = true;
        }

        if (Input.GetKeyDown(KeyCode.N) && canChose && chosen == false)
        {
            chosenSound.Play();
            hardness.position = new Vector3(-50f, 3f, 0f);
            getready.position = new Vector3(0f, 0.5f, 0f);
            currentHP = maxHP = 500f;
            p.GetComponent<BossLogic>().laserTime = 0.4f;
            p1.GetComponent<BossLegsSystem3>().currentHP = 700f;
            p1.GetComponent<BossLegsSystem3>().maxHP = 700f;
            p4.GetComponent<BossLegsSystem2>().currentHP = 15f;
            p5.GetComponent<BossLegsSystem2>().currentHP = 15f;
            p6.GetComponent<BossLegsSystem2>().currentHP = 10f;
            p7.GetComponent<BossLegsSystem2>().currentHP = 10f;
            Invoke("READYFIGHT", 2f);
            canChose = false;
            chosen = true;
        }

        if (Input.GetKeyDown(KeyCode.H) && canChose && chosen == false)
        {
            chosenSound.Play();
            hardness.position = new Vector3(-50f, 3f, 0f);
            getready.position = new Vector3(0f, 0.5f, 0f);
            currentHP = maxHP = 100f;
            p.GetComponent<BossLogic>().laserTime = 0.3f;
            p1.GetComponent<BossLegsSystem3>().currentHP = 1000f;
            p1.GetComponent<BossLegsSystem3>().maxHP = 1000f;
            p4.GetComponent<BossLegsSystem2>().currentHP = 20f;
            p5.GetComponent<BossLegsSystem2>().currentHP = 20f;
            p6.GetComponent<BossLegsSystem2>().currentHP = 15f;
            p7.GetComponent<BossLegsSystem2>().currentHP = 15f;
            Invoke("READYFIGHT", 2f);
            canChose = false;
            chosen = true;
        }

        if (!dead)
        {
            GroundCheck();
            if(transform.position.x < -9f)
            {
                transform.position = new Vector2(-9f, transform.position.y);
            }

            if (transform.position.x > 9f)
            {
                transform.position = new Vector2(9f, transform.position.y);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                anime.SetBool("animeD", true);
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime * 5, transform.position.y, transform.position.z);
                toRight = true;
                toLeft = false;
            }
            else
            {
                anime.SetBool("animeD", false);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                anime.SetBool("animeA", true);
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime * 5, transform.position.y, transform.position.z);
                toLeft = true;
                toRight = false;
            }
            else
            {
                anime.SetBool("animeA", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) & onTheGround == true & canJump == true)
            {
                jump.Play();
                anime.SetBool("animeSpace", true);
                playerBody.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                onTheGround = false;
            }
            else
            {
                anime.SetBool("animeSpace", false);
            }

            if (canDodge == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
                {
                    dodge.Play();
                    canDodge = false;
                    canJump = false;
                    player.enabled = false;
                    Invoke("DodgeCooldown", 0.5f);
                    Invoke("DodgeCooldown1", 1f);
                    anime.SetBool("animeRightOrShift", true);
                    playerBody.gravityScale = 0f;
                    playerBody.velocity = Vector3.zero;
                    if (toRight == true)
                    {
                        playerBody.AddForce(transform.right * 20f, ForceMode2D.Impulse);
                    }
                    else if (toLeft == true)
                    {
                        playerBody.AddForce(transform.right * (-20f), ForceMode2D.Impulse);
                    }
                }
            }

            hp.fillAmount = currentHP / maxHP;
        }

        Invoke("DeadOrNot", 0.5f);
        
    }

    void READYFIGHT()
    {
        t7 = true;
        tfinish = true;
        Color r = ready.GetComponent<SpriteRenderer>().color;
        if (r.a > 0.001f && begin == false)
        {
            r.a -= 0.5f * Time.deltaTime;
            ready.GetComponent<SpriteRenderer>().color = r;
            bossBody.enabled = false;
            if (bossBigLeft != null)
            {
                bossBigLeft.enabled = false;
            }

            if (bossBigRight != null)
            {
                bossBigRight.enabled = false;
            }

            if (bossSmallLeft != null)
            {
                bossSmallLeft.enabled = false;
            }

            if (bossSmallRight != null)
            {
                bossSmallRight.enabled = false;
            }
        }
        
        if(r.a < 0.001f && begin == false)
        {
            

            ready.transform.position = new Vector3(-50f, 0f, 0f);
            p.transform.position = new Vector3(0f, 1f, 0f);
            Color pp1 = p1.GetComponent<SpriteRenderer>().color;
            Color pp2 = p2.GetComponent<SpriteRenderer>().color;
            Color pp3 = p3.GetComponent<SpriteRenderer>().color;
            Color pp4 = p4.GetComponent<SpriteRenderer>().color;
            Color pp5 = p5.GetComponent<SpriteRenderer>().color;
            Color pp6 = p6.GetComponent<SpriteRenderer>().color;
            Color pp7 = p7.GetComponent<SpriteRenderer>().color;
            if(pp1.a <= 0.999f)
            {
                pp1.a += 1f * Time.deltaTime;
                pp2.a += 1f * Time.deltaTime;
                pp3.a += 1f * Time.deltaTime;
                pp4.a += 1f * Time.deltaTime;
                pp5.a += 1f * Time.deltaTime;
                pp6.a += 1f * Time.deltaTime;
                pp7.a += 1f * Time.deltaTime;
                p1.GetComponent<SpriteRenderer>().color = pp1;
                p2.GetComponent<SpriteRenderer>().color = pp2;
                p3.GetComponent<SpriteRenderer>().color = pp3;
                p4.GetComponent<SpriteRenderer>().color = pp4;
                p5.GetComponent<SpriteRenderer>().color = pp5;
                p6.GetComponent<SpriteRenderer>().color = pp6;
                p7.GetComponent<SpriteRenderer>().color = pp7;
            }
            else if(pp1.a > 0.999f && bossBody.enabled == false && begin == false)
            {
                getReady.enabled = false;
                battleStarts.Play();
                bossBody.enabled = true;
                if (bossBigLeft != null)
                {
                    bossBigLeft.enabled = true;
                }

                if (bossBigRight != null)
                {
                    bossBigRight.enabled = true;
                }

                if (bossSmallLeft != null)
                {
                    bossSmallLeft.enabled = true;
                }

                if (bossSmallRight != null)
                {
                    bossSmallRight.enabled = true;
                }
            }
            else
            {
                begin = true;
            }
        }
        
    }

    void DeadOrNot()
    {
        if (currentHP > 0)
        {
            dead = false;
        }
        else
        {
            dead = true;
        }

        if (dead & stop == false)
        {
            broken.Play();
            player.enabled = false;
            playerBody.AddForce(transform.up * 30f, ForceMode2D.Impulse);
            bodySprite.sortingOrder = 19;
            leftSprite.sortingOrder = rightSprite.sortingOrder = 18;
            stop = true;
        }
        else if(dead && stop)
        {
            Invoke("SceneChange", 2.5f);
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
    void DodgeCooldown()
    {
        anime.SetBool("animeRightOrShift", false);
        playerBody.gravityScale = 5f;
        canJump = true;
        player.enabled = true;
    }

    void DodgeCooldown1()
    {
        canDodge = true;
    }

    void enableCollider2D()
    {
        if(protect == true)
        {
            bossBody.enabled = true;
            if (bossBigLeft != null)
            {
                bossBigLeft.enabled = true;
            }

            if (bossBigRight != null)
            {
                bossBigRight.enabled = true;
            }

            if (bossSmallLeft != null)
            {
                bossSmallLeft.enabled = true;
            }

            if (bossSmallRight != null)
            {
                bossSmallRight.enabled = true;
            }
            protect = false;
        }
    }

    void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);

        if (hit.collider != null)
        {
            onTheGround = true;
        }
        else
        {
            onTheGround = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "BossBody")
        {
            hurt.Play();
            currentHP = currentHP - bodyDamage;
            protect = true;
            bossBody.enabled = false;
            if(bossBigLeft != null)
            {
                bossBigLeft.enabled = false;
            }

            if (bossBigRight != null)
            {
                bossBigRight.enabled = false;
            }

            if (bossSmallLeft != null)
            {
                bossSmallLeft.enabled = false;
            }

            if (bossSmallRight != null)
            {
                bossSmallRight.enabled = false;
            }
            Invoke("enableCollider2D", 0.5f);
            blood1.sortingOrder = 8;
            blood2.sortingOrder = 6;
            blood3.sortingOrder = 6;
            Invoke("BloodingStops", 0.09f);
        }

        if (collision.gameObject.tag == "BossBigLeg")
        {
            hurt.Play();
            currentHP = currentHP - bigLegDamge;
            protect = true;
            bossBody.enabled = false;
            if (bossBigLeft != null)
            {
                bossBigLeft.enabled = false;
            }

            if (bossBigRight != null)
            {
                bossBigRight.enabled = false;
            }

            if (bossSmallLeft != null)
            {
                bossSmallLeft.enabled = false;
            }

            if (bossSmallRight != null)
            {
                bossSmallRight.enabled = false;
            }
            Invoke("enableCollider2D", 0.5f);
            blood1.sortingOrder = 8;
            blood2.sortingOrder = 6;
            blood3.sortingOrder = 6;
            Invoke("BloodingStops", 0.09f);
        }

        if (collision.gameObject.tag == "BossSmallLeg")
        {
            hurt.Play();
            currentHP = currentHP - smallLegDamage;
            protect = true;
            bossBody.enabled = false;
            if (bossBigLeft != null)
            {
                bossBigLeft.enabled = false;
            }

            if (bossBigRight != null)
            {
                bossBigRight.enabled = false;
            }

            if (bossSmallLeft != null)
            {
                bossSmallLeft.enabled = false;
            }

            if (bossSmallRight != null)
            {
                bossSmallRight.enabled = false;
            }
            Invoke("enableCollider2D", 0.5f);
            blood1.sortingOrder = 8;
            blood2.sortingOrder = 6;
            blood3.sortingOrder = 6;
            Invoke("BloodingStops", 0.09f);
        }

        if (collision.gameObject.tag == "BossBulletBig")
        {
            hurt.Play();
            currentHP = currentHP - bigBulletDamage;
            blood1.sortingOrder = 8;
            blood2.sortingOrder = 6;
            blood3.sortingOrder = 6;
            Invoke("BloodingStops", 0.09f);
        }

        if (collision.gameObject.tag == "BossBulletSmall")
        {
            hurt.Play();
            currentHP = currentHP - smallBulletDamage;
            blood1.sortingOrder = 8;
            blood2.sortingOrder = 6;
            blood3.sortingOrder = 6;
            Invoke("BloodingStops", 0.09f);
        }

        if (collision.gameObject.tag == "Laser")
        {
            hurt.Play();
            currentHP = currentHP - laserDamage;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            blood1.sortingOrder = 8;
            blood2.sortingOrder = 6;
            blood3.sortingOrder = 6;
            Invoke("BloodingStops", 0.09f);
        }
    }

    void BloodingStops()
    {
        blood1.sortingOrder = -1;
        blood2.sortingOrder = -1;
        blood3.sortingOrder = -1;
    }
}
