using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float moveSpeed = -5f;
    private float stopPosition = 2;
    public Rigidbody enemyRigid = default;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigid= GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (enemyRigid!=null)
        {
            enemyRigid.velocity = Vector3.zero;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z<stopPosition)
        {
            enemyRigid.velocity = Vector3.zero;
            return;
        }
        
        Vector3 enemyVelocity=new Vector3(0f,0f,moveSpeed);

        enemyRigid.velocity = enemyVelocity;
    }
}
