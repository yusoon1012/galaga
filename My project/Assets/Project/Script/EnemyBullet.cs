using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody bullet = default;
    // Start is called before the first frame update
    void Start()
    {

        bullet = GetComponent<Rigidbody>();
        bullet.velocity = transform.forward*speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            PlayerController playerControler = other.GetComponent<PlayerController>();
            if(playerControler!=null)
            {
                playerControler.Die();
            }
        Destroy(gameObject, 0f);
        }
        if (other.tag.Equals("Wall"))
        {
            Destroy(gameObject, 0f);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
