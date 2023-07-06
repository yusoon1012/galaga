using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigid = default;
    public float speed = default;
    public GameObject bulletPrefab = default;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigid.velocity = newVelocity;

        if(Input.GetButtonDown("Jump"))
        {
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        
    }
    public void Die()
    {
        Debug.Log("¸Â¾Ò´Ù.");
    }
}
