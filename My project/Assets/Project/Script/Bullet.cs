using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody bullet = default;
        EnemySpawner spawner;
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {

        bullet = GetComponent<Rigidbody>();

        bullet.velocity = transform.up * speed;
        spawner = GameObject.FindObjectOfType<EnemySpawner>();
        manager = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Enemy"))
        {
        EnemyShooting enemy = other.GetComponent<EnemyShooting>();
      
            if(enemy!=null)
            {
                enemy.Die();
                Destroy(gameObject, 0f);
                
                spawner.enemylist -= 1;
                manager.score += 500;
            }
        }
        if(other.tag.Equals("Wall"))
        {
            Destroy(gameObject, 0f);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

