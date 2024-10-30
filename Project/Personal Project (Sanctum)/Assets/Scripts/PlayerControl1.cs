using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl1 : MonoBehaviour
{
    public float speed = 10.0f; //player movement
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;

    public Rigidbody playerRb; // player jump with physics
    public float jumpForce = 8;
    public float gravityModifier;
    public bool isOnGround = true;

    public int maxHealth = 100; // player health
    public int currentHealth;
    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
      currentHealth = maxHealth; // game start health is at max
      healthBar.SetMaxHealth(maxHealth);

       playerRb = GetComponent<Rigidbody>(); //reference physics of rigidbody
       Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      horizontalInput = Input.GetAxis("Horizontal"); //left and right or AD keys
      
      forwardInput = Input.GetAxis("Vertical"); // forward and back or WS keys
      
      transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); 
      
      transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

      if (Input.GetKeyDown(KeyCode.Space) && isOnGround) //jump when space key pressed
      {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // jump force and immediate reaction
        isOnGround = false; //only jump if on the ground
      }

      if (Input.GetKeyDown(KeyCode.H))
      {
        TakeDamage(10);
      }

      void TakeDamage(int damage)
      {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
      }

    }

    private void OnCollisionEnter(Collision collision){
        isOnGround = true; }

}
