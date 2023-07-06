using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab = default;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;
    public EnemySpawner enemySpawner;


    private Transform target = default;
    private float spawnRate = default;
    private float timeAfterSpawn = default;
   
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    private void OnTriggerStay(Collider other)
    {
    }

    public void Die()
    {
        Destroy(gameObject, 0f);
        
    }



    // Update is called once per frame
    void Update()
    {
        
           
           
            timeAfterSpawn += Time.deltaTime;
            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0;
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.transform.LookAt(target);
                spawnRate = Random.Range(spawnRateMin,spawnRateMax);

            }
        

    }
}
