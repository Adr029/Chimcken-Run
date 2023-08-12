using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyLeft : MonoBehaviour

{

    [SerializeField] PlayerMovement playerbuff;
    [SerializeField] Animator animator;
    [SerializeField] Collider2D wolf;
    [SerializeField] Collider2D worm;
    public bool playerisbuffed = false;
    float speed = 1f;
    bool movingleft = true;
    public Transform groundDetector;
    public float timer = 0.8f;
    public bool spawn = true;
    void Start()
    {
        //startPos = this.transform.position;
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetector.position, Vector2.down, 2f);

        if (groundInfo.collider == false)
        {
            if (movingleft == true)

            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingleft = false;
            }

            else

            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingleft = true;
            }
        }
        
        playerisbuffed = playerbuff.buffedstate;
        animator.SetBool("playerbuffed", playerisbuffed);
        animator.SetBool("spawn", spawn);
        if (playerisbuffed == true)
        {
            timer -= Time.deltaTime;
            if (timer < 0.1f)
            {
                worm.enabled = true;
                wolf.enabled = false;
            }
        }
        else if (playerisbuffed == false)
        {
            worm.enabled = false;
            wolf.enabled = true;
            timer = 0.8f;
            
        }
        if (this.gameObject.activeSelf == true)
        {
            spawn = true;
        }

      

    }

}


