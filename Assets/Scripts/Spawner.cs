using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject buff;
    public float spawntime = 10f;
    public float flyspawn = 5f;
    private GameObject cloneBuff;
    [SerializeField] PlayerMovement playerisbuffed;
    [SerializeField] BuffMovement buffstatus;
    public GameObject flyingenemy;
   
    void Update()

    {
        if (playerisbuffed.buffedstate == false)
        {
 
            spawntime -= Time.deltaTime;
            if (spawntime < 0f)
            {
                spawntime = 35f;
                Vector3 randomSpawn = new Vector3(Random.Range(-18, 18f), Random.Range(-10, 10f));
                Instantiate(buff, randomSpawn, Quaternion.identity);
            }
        }
         if (playerisbuffed.buffedstate == true)
        {
            spawntime = 20f;
           
        }

        flyspawn -= Time.deltaTime;
        if (flyspawn < 0f)
        {
            flyspawn = 10f;
            Vector3 randomSpawn1 = new Vector3(Random.Range(-19, 19f), Random.Range(-10, 10f));
            Vector3 randomSpawn2 = new Vector3(Random.Range(-19, 19f), Random.Range(-10, 10f));
            Instantiate(flyingenemy, randomSpawn1, Quaternion.identity);
            Instantiate(flyingenemy, randomSpawn2, Quaternion.identity);
        }
    }
}
