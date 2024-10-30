using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl1 : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;
    public Rigidbody playerRb;
    public float jumpForce = 8;
    public float gravityModifier;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
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
        isOnGround = false;
      }
  
    }

    private void OnCollisionEnter(Collision collision){
        isOnGround = true; }

}
