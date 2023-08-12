using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
  
    float speed = 5f;
    [SerializeField] bool gliding = false;
    [SerializeField] bool diving = false;
    [SerializeField] bool jumping = true;
    float x;
    [SerializeField] bool faceleft = true;
    public float playerhealth = 4f;
    Vector3 startPos;
    [SerializeField] Rigidbody2D player;
    [SerializeField] Animator animator;
    public int score = 0;
    public bool buffedstate = false;
    public float waitTime = 10f;
    public bool complete = false;
    public float deathtimer = 10f;
  
    //Double Jumping
    int jumpamount = 1;
    bool isgrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatisground;

    
    void Start() 
    {
        startPos = this.transform.position;

        
    }
    void Update()
    {
  
            x = Input.GetAxisRaw("Horizontal");
            // kapag nag right ka +1, kapag left -1

            if (Input.GetKey(KeyCode.LeftShift) && isgrounded == false)
            {
                gliding = true;
            }
            else
            {
                gliding = false;
            }
            if (Input.GetKey(KeyCode.LeftControl) && isgrounded == false)
            {
                diving = true;
            }
            else
            {
                diving = false;
            }
            if (isgrounded == true)
            {
                jumpamount = 2;
            }
            if (Input.GetKeyDown(KeyCode.Space) && jumpamount != 0 && diving == false && gliding == false)
            {
                jumping = true;
                Vector2 jumpingvelocity = new Vector2(player.velocity.x, speed * 1.5f);
                player.velocity = jumpingvelocity;
                jumpamount--;

            }

            else if (player.velocity.y < 0f || diving == true || gliding == true)

            {
                jumping = false;
            }
        
        
 
        //animator values
        animator.SetBool("jumping", jumping);
        animator.SetBool("gliding", gliding);
        animator.SetBool("diving", diving);
        animator.SetFloat("speed", Mathf.Abs(x));

        if (Input.GetKeyDown(KeyCode.R) && playerhealth == 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
        //pang end ng laro
        if (GameObject.FindGameObjectsWithTag("Collectible").Length  < 1)
        {
            complete = true;
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.R) && complete == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
                complete = false;
            }
        }

    }
    private void FixedUpdate() 
    {   
        XMovement(x);
        DiveMovement(diving);
        GlideMovement(gliding);
        isgrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatisground);
    }
   
    private void XMovement(float move)
    {                      
        float xvelocity = move * speed * 50 * Time.deltaTime;
        Vector2 targetvelocity = new Vector2(xvelocity, player.velocity.y);                        
        player.velocity = targetvelocity;
        if (faceleft && move > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            faceleft = false;
        }
        else if (!faceleft && move < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            faceleft = true;
        }
    }
    private void DiveMovement(bool diving)
    {
        if (diving == true)
        {
            float yvelocity = speed * 125 * Time.deltaTime;
            Vector2 divevelocity = new Vector2(player.velocity.x, Mathf.Abs(yvelocity) * -1f);
            player.velocity = divevelocity;
        }
    }
    private void GlideMovement(bool gliding)

    {
        if (gliding == true)
        {
            Vector2 glidevelocity = new Vector2(player.velocity.x, player.velocity.y * 0.95f);
            player.velocity = glidevelocity;
        }
    }

    void OnTriggerEnter2D(Collider2D collisions)
    {
        //dito lahat ng magiging collisions

        if (collisions.gameObject.tag == "Buff")
        {
            Destroy(collisions.gameObject);
            buffedstate = true;
            StartCoroutine(EndBuff(waitTime));
        }
        IEnumerator EndBuff(float time)
        {
            yield return new WaitForSeconds(10f);
            buffedstate = false;
        }

        if (buffedstate == true)

        {
            if (collisions.gameObject.tag == "Enemy")
            {
                collisions.gameObject.SetActive(false);
                score += 100;
                StartCoroutine(RespawnEnemy(0f));
            }
            IEnumerator RespawnEnemy(float respawn)
            {
                yield return new WaitForSeconds(10f);
                collisions.gameObject.SetActive(true);
            }

            if (collisions.gameObject.tag == "FlyingEnemy")
            {
                Destroy(collisions.gameObject);
                score += 100;
            }
        }
        else {
            //kapag di naka buff = true mapapatay ka
            if (collisions.gameObject.tag == "Enemy" || collisions.gameObject.tag == "FlyingEnemy")
            {
                playerhealth = playerhealth - 1f;

                if (playerhealth > 0f)
                {
                  this.transform.position = startPos;
                }
                else
                {
                    Time.timeScale = 0;
                }
            }
        }
        if (collisions.gameObject.tag == "Collectible")
        {
            Destroy(collisions.gameObject);
            score += 50;
            Debug.Log("Current score is: " + score);
        }

    } 
    }

