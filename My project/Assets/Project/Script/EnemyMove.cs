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
    private int randomValue = default;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigid= GetComponent<Rigidbody>();
        randomValue = UnityEngine.Random.Range(1, 3);
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
        // 1이면 왼쪽
        if (randomValue == 1)
        {
            Vector3 newVelocity = new Vector3(-moveSpeed, 0f, 0f);
            enemyRigid.velocity = newVelocity;
        }

        // 2이면 오른쪽
        else if (randomValue == 2)
        {
            Vector3 newVelocity = new Vector3(moveSpeed, 0f, 0f);
            enemyRigid.velocity = newVelocity;
        }
        if (transform.position.z<stopPosition)
        {
            enemyRigid.velocity = Vector3.zero;
            return;
        }
        

        Vector3 enemyVelocity =new Vector3(0f,0f,moveSpeed);

        enemyRigid.velocity = enemyVelocity;
    }
}
