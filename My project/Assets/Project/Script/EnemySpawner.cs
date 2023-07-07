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
    private float spawnerSpeed = 3f;
    private Rigidbody spawner = default;

    private bool gotoLeft = default;
    private bool gotoRight = default;

    private float respawnTimer = default;
    private float respawnRate = default;
    private float clearDelay = 3f;
    EnemyShooting enemyShooting;
    
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        spawner= GetComponent<Rigidbody>();
        
    }
  
   

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        //Debug.Log(enemylist);
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

            respawnTimer += Time.deltaTime;

            if (respawnTimer>= respawnRate)
            {
                respawnTimer = 0;
                if (!isAllClear)
                {
                    isAllClear = true;

                }
                respawnRate = 3f;
            }
           
        }
        if(transform.position.x<=-4)
        {
            gotoRight = true;
            gotoLeft = false;
        }
        else if(transform.position.x>=4)
        {
            gotoLeft = true;
            gotoRight = false;
        }
        if(gotoRight)
        {
        Vector3 moveSpawner=new Vector3(spawnerSpeed, 0f, 0f);
        spawner.velocity = moveSpawner;
            //Debug.Log("오른쪽으로가는중");

        }
        else if(gotoLeft)
        {
            Vector3 moveSpawner = new Vector3(-spawnerSpeed, 0f, 0f);
            spawner.velocity = moveSpawner;
            //Debug.Log("왼쪽으로가는중");

        }


    }
}
