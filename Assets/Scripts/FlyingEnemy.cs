using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float lifetime = 10f;
    private Transform targetplayer;
    public bool spawned = true;
    public bool buff = false;
    [SerializeField] Animator animator;

    void Start()

    {
         targetplayer = GameObject.FindWithTag("Player").transform;
          
        }
    void Update()
    {
        if (targetplayer.position.x > transform.position.x)
        {
           
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (targetplayer.position.x < transform.position.x)
        {
            
            transform.localScale = new Vector3(1, 1, 1);
        }
        lifetime -= Time.deltaTime;
        if (lifetime < 0.8f)
        {
            spawned = false;

        }
        if (lifetime < 0.1f)
        {
            Destroy(this.gameObject);

        }

        animator.SetBool("spawn", spawned);

    }
}
