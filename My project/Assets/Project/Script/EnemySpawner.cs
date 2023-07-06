using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;
    public int enemylist;

    private Transform target = default;
    private float spawnRate = default;
    private float timeAfterSpawn = default;
    private bool isAllClear = true;


    EnemyShooting enemyShooting;
    
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        enemyShooting.enemySpawner = this;
    }
  
   

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
       
        if(isAllClear==true)
        {
            if(enemylist<6)
            {

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0;
            
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            
            spawnRate = spawnRateMin;
                    enemylist += 1;

        }
            }
            else
            {
                isAllClear = false;
            }
        }
        if(enemylist==0)
        {
            isAllClear = true;
        }
        
        

    }
}
