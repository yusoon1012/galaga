using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody bullet = default;
    PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {

        bullet = GetComponent<Rigidbody>();
        bullet.velocity = transform.forward*speed;
        controller = GameObject.FindAnyObjectByType<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            PlayerController playerControler = other.GetComponent<PlayerController>();
            if(playerControler!=null)
            {
                if(controller.isGodMode==false)
                {
                playerControler.Damaged();

                }

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
