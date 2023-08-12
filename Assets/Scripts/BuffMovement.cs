using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMovement : MonoBehaviour
{
    public float speed = 5f;
    public float position;
    public float yposition;
    public Vector3 newPosition;
    public bool moved;
    public float lifetime= 15f;
    public bool alive = false;

    void Start()
    {
        
        newPosition = new Vector3(position, yposition, transform.position.z);
        moved = true;
    }
    void Update()
    {
        if (moved == true)
        {
            yposition = Random.Range(-10f, 10f);
            position = Random.Range(-18f, 19f);
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, newPosition) <= 0.01f)
            {
                yposition = Random.Range(-10f, 10f);
                position = Random.Range(-18f, 18f);
                newPosition = new Vector3(position, yposition, transform.position.z);  
            }

        }

        lifetime -= Time.deltaTime;
        if (lifetime < 0.1f)
        {
            Destroy(this.gameObject);
         
        }
       
    }
}
