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

    // Start is called before the first frame update
    void Start()
    {
       playerRb = GetComponent<Rigidbody>();
       playerRb.AddForce(Vector3.up * 200); 
    }

    // Update is called once per frame
    void LateUpdate()
    {
      horizontalInput = Input.GetAxis("Horizontal");
      forwardInput = Input.GetAxis("Vertical");
      
      transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
      transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
  
    }
}
