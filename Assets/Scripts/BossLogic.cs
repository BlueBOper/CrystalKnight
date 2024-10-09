using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class BossLogic : MonoBehaviour
{

    public Transform player;
    public bool timeup, time, stop, readyToShoot, finishShooting, shoot, goTo2, start;
    public bool trans1, trans2, trans3, trans4;
    public Animator anime;
    public GameObject bossBody, player1, bulletSmall, bulletBig, bulletSmall1, bulletSmall2, bulletSmall3, bossLeft, bossRight;
    public Collider2D playerBody;
    public GameObject laser1, laser2;
    public bool isAttacking, defeated;
    public float movementSpeed;
    public float attackDistance;
    public float attackCooldown;
    public int counter, upper;
    public Image life;
    public Collider2D bossMainBody, bossBigLeft, bossBigRight, bossSmallLeft, bossSmallRight, bossCornLeft, bossCornRight;
    public Transform firepoint1, firepoint2, firepoint3, firepoint4, firepoint5;
    public Transform laserPlace1, laserPlace2;
    public Transform random1, random2, place3, place4, l1, l2, l3, l4;
    public GameObject hLaser1, hLaser2;
    public float fireTime, nextFire, laserTime;
    public bool moveToLeft, moveToRight, third;
    public Rigidbody2D ball;
    public SpriteRenderer middle, leftCorn, rightCorn, sLeftLeg, sRightLeg, bLeftLeg, bRightLeg, lCorn, rCorn;
    public GameObject blooding;
    public bool shine;
    float randomRecord;
    float randomNumber;
    private int counter2, counter3;
    public AudioSource laserSound1, laserSound2, laserSound3, laserSound4, broken;

    //public float timer;
    // Start is called before the first frame update
    void Start()
    {
        start = false;
        shine = false;
        place3.position = place4.position = new Vector3(0f, -4f, 0f);
        timeup = time = stop = readyToShoot = moveToLeft = moveToRight = third = false;
        defeated = false;
        finishShooting = shoot = true;
        anime = bossBody.GetComponent<Animator>();
        counter = counter2 = counter3 = 0;
        goTo2 = false;
        trans1 = false;
        trans2 = false;
        trans3 = false;
        trans4 = false;
        laserPlace1.transform.position = new Vector2(player1.transform.position.x, 1f);
        laserPlace2.transform.position = new Vector2(player1.transform.position.x, 1f);
        Color rc = rCorn.color;
        Color lc = lCorn.color;
        rc.a = 0f;
        lc.a = 0f;
        rCorn.color = rc;
        lCorn.color = lc;
        //anime.SetBool("StartShooting", false);
        //anime.SetBool("StopShooting", false);
    }

    // Update is called once per frame
    void Update()
    {
        laserPlace1.transform.position = new Vector2(player1.transform.position.x, 1f);
        laserPlace2.transform.position = new Vector2(player1.transform.position.x, 1f);

        if (player1.GetComponent<Move>().dead || bossBody.GetComponent<BossLegsSystem3>().currentHP <= 0)
        {
            stop = true;
        }

        if(bossBody.GetComponent<BossLegsSystem3>().currentHP <= 0)
        {
            if (defeated == false)
            {
                broken.Play();
                ball.constraints = RigidbodyConstraints2D.None;
                ball.freezeRotation = true;
                ball.gravityScale = 5f;
                bossMainBody.enabled = bossCornLeft.enabled = bossCornRight.enabled = false;
                anime.enabled = false;
                if (bossBigLeft != null)
                {
                    bossBigLeft.enabled = false;
                    bLeftLeg.sortingOrder = 21;
                }

                if (bossBigRight != null)
                {
                    bossBigRight.enabled = false;
                    bRightLeg.sortingOrder = 21;
                }

                if (bossSmallLeft != null)
                {
                    bossSmallLeft.enabled = false;
                    sLeftLeg.sortingOrder = 21;
                }

                if (bossSmallRight != null)
                {
                    bossSmallRight.enabled = false;
                    sRightLeg.sortingOrder = 21;
                }
                middle.sortingOrder = 22;
                leftCorn.sortingOrder = rightCorn.sortingOrder = 21;
                ball.AddForce(transform.up * 50f, ForceMode2D.Impulse);

                Color rc = rCorn.color;
                Color lc = lCorn.color;
                rc.a = 0f;
                lc.a = 0f;
                rCorn.color = rc;
                lCorn.color = lc;

                Invoke("SceneChange", 2.5f);
                defeated = true;
            }
        }
        
        Color b = bossBody.GetComponent<SpriteRenderer>().color;
        if(b.a >= 0.999f && transform.position.x > -2f)
        {
            start = true;
        }


        if(stop == false && start)
        {
            if (isAttacking == false && counter < upper && goTo2 == false)
            {
                MoveToPlayer();
            }
            else if(counter >= upper && isAttacking == false && readyToShoot == false && goTo2 == false)
            {
                readyToShoot = true;
                Invoke("StartShooting", 0.3f);
            }
            else if (readyToShoot == true && third == true && goTo2 == false) 
            {
                StartRealShooting();
            }
            else if (goTo2)
            {
                Invoke("Transittion", 1f);
                
            }

            if(l1.position.y > 30f && l2.position.y > 30f
                && l3.position.y > 30f && l4.position.y > 30f)
            {
                goTo2 = true;
            }

            if(trans1 && trans2 && trans3 == false)
            {
                Invoke("LaserTime", 2f);
                trans3 = true;
            }
            else if(trans1 && trans2 && trans3 && trans4)
            {
                LaserTime();
            }
        }

        life.fillAmount = bossBody.GetComponent<BossLegsSystem3>().currentHP / bossBody.GetComponent<BossLegsSystem3>().maxHP;
        //Invoke("CoolDown", 5.0f);
        //if (timeup & time)
        //{
        //    //transform.position = new Vector2(player.transform.position.x, transform.position.y);

        //    anime.SetBool("Attack", true);
        //    timeup = false;
        //}
        //else if(time & timeup == false)
        //{
        //    time = false;
        //}
    }

    void SceneChange()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
    private void LaserTime()
    {
        trans4 = true;

        Color rc = rCorn.color;
        Color lc = lCorn.color;

        if(bossBody.GetComponent<BossLegsSystem3>().currentHP > 0)
        {
            if (lc.a < 0.999f && shine == false)
            {
                rc.a += 1f * Time.deltaTime;
                rCorn.color = rc;

                lc.a += 1f * Time.deltaTime;
                lCorn.color = lc;
            }
            else if (lc.a >= 0.999f && shine == false)
            {
                shine = true;
            }
            else if (lc.a > 0.001f && shine)
            {
                rc.a -= 1f * Time.deltaTime;
                rCorn.color = rc;

                lc.a -= 1f * Time.deltaTime;
                lCorn.color = lc;
            }
            else if (lc.a <= 0.001f && shine)
            {
                shine = false;
            }
        }

        if (Time.time > nextFire && bossBody != null)
        {
            nextFire = Time.time + laserTime;

            if(counter2 == 0)
            {
                Instantiate(laser1, laserPlace1.transform.position, player1.transform.rotation);
                Instantiate(laser2, laserPlace2.transform.position, player1.transform.rotation);
                laserSound1.Play();
                counter2++;
                if (counter3 == 5)
                {
                    Instantiate(hLaser1, place3.transform.position, hLaser1.transform.rotation);
                    Instantiate(hLaser2, place4.transform.position, hLaser2.transform.rotation);
                    laserSound4.Play();
                    counter3 = 0;
                }
                else
                {
                    counter3++;
                }
            }
            else if(counter2 == 1)
            {
                randomNumber = Random.Range(-8.5f, -1.5f);
                random1.transform.position = new Vector2(randomNumber, 1f);
                random2.transform.position = new Vector2(randomNumber, 1f);
                Instantiate(laser1, random1.transform.position, player1.transform.rotation);
                Instantiate(laser2, random2.transform.position, player1.transform.rotation);
                laserSound2.Play();
                counter2++;
                if (counter3 == 5)
                {
                    Instantiate(hLaser1, place3.transform.position, hLaser1.transform.rotation);
                    Instantiate(hLaser2, place4.transform.position, hLaser2.transform.rotation);
                    laserSound4.Play();
                    counter3 = 0;
                }
                else
                {
                    counter3++;
                }
            }
            else if(counter2 == 2)
            {
                randomRecord = Random.Range(1.5f, 8.5f);
                random1.transform.position = new Vector2(randomRecord, 1f);
                random2.transform.position = new Vector2(randomRecord, 1f);
                Instantiate(laser1, random1.transform.position, player1.transform.rotation);
                Instantiate(laser2, random2.transform.position, player1.transform.rotation);
                laserSound3.Play();
                counter2 = 0;
                if (counter3 == 5)
                {
                    Instantiate(hLaser1, place3.transform.position, hLaser1.transform.rotation);
                    Instantiate(hLaser2, place4.transform.position, hLaser2.transform.rotation);
                    laserSound4.Play();
                    counter3 = 0;
                }
                else
                {
                    counter3++;
                }
            }


        }
    }
    private void Transittion()
    {
        Color body = bossBody.GetComponent<SpriteRenderer>().color;
        Color left = bossLeft.GetComponent<SpriteRenderer>().color;
        Color right = bossRight.GetComponent<SpriteRenderer>().color;
        Color blood = blooding.GetComponent<SpriteRenderer>().color;
        Color rc = rCorn.color;
        Color lc = lCorn.color;

        if(body.a > 0.01f && trans1 == false)
        {
            body.a -= 1f * Time.deltaTime;
            bossBody.GetComponent<SpriteRenderer>().color = body;

            left.a -= 1f * Time.deltaTime;
            bossLeft.GetComponent<SpriteRenderer>().color = left;

            right.a -= 1f * Time.deltaTime;
            bossRight.GetComponent<SpriteRenderer>().color = right;

            blood.a -= 1f * Time.deltaTime;
            blooding.GetComponent<SpriteRenderer>().color = blood;

            anime.SetTrigger("StopShooting");
            
        }
        else
        {
            trans1 = true;
            anime.ResetTrigger("StopShooting");
            //transform.position = bossBody.transform.position = new Vector3(0f, 0.5f, 1f);

            if (body.a < 1f && trans2 == false && trans1 == true)
            {
                body.a += 1f * Time.deltaTime;
                bossBody.GetComponent<SpriteRenderer>().color = body;

                left.a += 1f * Time.deltaTime;
                bossLeft.GetComponent<SpriteRenderer>().color = left;

                right.a += 1f * Time.deltaTime;
                bossRight.GetComponent<SpriteRenderer>().color = right;

                blood.a += 1f * Time.deltaTime;
                blooding.GetComponent<SpriteRenderer>().color = blood;

                transform.position = bossBody.transform.position = new Vector3(0f, 0.8f, 0f);
            }
            else if(lc.a < 1f && trans2 == false && trans1 == true)
            {
                rc.a += 1f * Time.deltaTime;
                rCorn.color = rc;

                lc.a += 1f * Time.deltaTime;
                lCorn.color = lc;

                anime.SetTrigger("StartPhase2");
            }
            else
            {
                trans2 = true;
                anime.SetTrigger("StartPhase2");
            }
        }
        
        
        
    }

    private void CoolDown()
    {
        //timeup = time = true;
        if (counter < upper && isAttacking)
        {
            counter++;
            isAttacking = false;
        }
    }

    void StartShooting()
    {
        if(moveToRight == false && moveToLeft == false)
        {
            moveToLeft = false;
            moveToRight = true;
            third = true;
            anime.SetTrigger("StartShooting");
        }
        //Invoke("StartRealShooting", 3f);
    }

    void StartRealShooting()
    {
        if (Time.time > nextFire)
            {
            nextFire = Time.time + fireTime;
            if(bossBigLeft != null)
            {
                Instantiate(bulletSmall, firepoint1.position, firepoint1.rotation);
            }

            if (bossBigRight != null)
            {
                Instantiate(bulletSmall1, firepoint2.position, firepoint2.rotation);
            }

            if (bossSmallLeft != null)
            {
                Instantiate(bulletSmall2, firepoint3.position, firepoint3.rotation);
            }

            if (bossSmallRight != null)
            {
                Instantiate(bulletSmall3, firepoint4.position, firepoint4.rotation);
            }

            Instantiate(bulletBig, firepoint5.position, firepoint5.rotation);
        }

        if (transform.position.x < 8 & moveToRight)
        {
            transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 8 & moveToRight)
        {
            moveToRight = false;
            moveToLeft = true;
        }
        else if (transform.position.x > -8 & moveToLeft)
        {
            transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -8 & moveToLeft)
        {
            moveToLeft = false;
            moveToRight = true;
        }


            finishShooting = true;
            Invoke("StopShooting", 5f);


        
    }


    void StopShooting()
    {
        if (finishShooting)
        {
            Invoke("CompleteStop", 1f);
            anime.SetTrigger("StopShooting");
            moveToLeft = false;
            moveToRight = false;
            third = false;
        }

    }

    void CompleteStop()
    {
        if (finishShooting)
        {
            anime.ResetTrigger("StopShooting");
            counter = 0;
            readyToShoot = false;
            finishShooting = false;
        }
    }

    void MoveToPlayer()
    {
        if(readyToShoot == false)
        {
            if (transform.position.x < player.position.x)
            {
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime * movementSpeed;
            }
            else if (transform.position.x > player.position.x)
            {
                transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * movementSpeed;
            }

            float currentDistance = Vector2.Distance(transform.position, player.position);
            if (currentDistance < attackDistance)
            {
                anime.SetTrigger("Attacking");
                isAttacking = true;
                Invoke("CoolDown", attackCooldown);
            }
        }
        
    }

}
