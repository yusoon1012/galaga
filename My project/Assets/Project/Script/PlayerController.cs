using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigid = default;
    public float speed = default;
    public int playerHp = 3;
    public GameObject bulletPrefab = default;
    public bool isGodMode = default;
    private Player rewiredPlayer;
    Renderer playerColor;
    private float godModeTimer = default;
    private float godModeRate = default;
    private Vector3 initialPosition;
  
    private void Awake()
    {
        rewiredPlayer = ReInput.players.GetPlayer(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        initialPosition = transform.position;
        playerRigid = GetComponent<Rigidbody>();
        isGodMode = false;


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
        if(playerHp==0)
        {
            Die();
        }
        if(Input.GetButtonDown("Jump"))
        {
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        //Debug.Log(playerHp);
        if(isGodMode==true)
        {
            Debug.Log("¹«Àû");
            godModeRate += Time.deltaTime;
            if(godModeRate>=godModeTimer)
            {
                godModeRate = 0f;
                isGodMode = false;
                godModeTimer = 3f;
            }
        }
        
    }
    public void Damaged()
    {


        //if(isGodMode==false)
        //{
        //transform.position = initialPosition;

        //}
        isGodMode = true;
        playerHp -= 1;
        godModeRate = 0f;
        godModeTimer = 3f;
    }
    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
