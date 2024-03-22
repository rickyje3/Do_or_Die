using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;
	public Transform cam;
	public Rigidbody rb;
	
	public float speed = 7f;
	public float turnSmooth = 0.1f;
	float turnVelocity;
	public float jump = 5f;
	public bool grounded;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
       float horizontal = Input.GetAxisRaw("Horizontal"); 
	   float vertical = Input.GetAxisRaw("Vertical"); 
	   Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
	   
	   if(direction.magnitude >= 0.1f)
	   {
		   float orient = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
		   float turn = Mathf.SmoothDampAngle(transform.eulerAngles.y, orient, ref turnVelocity, turnSmooth);
		   transform.rotation = Quaternion.Euler(0f, turn, 0f);
		   
		   Vector3 move = Quaternion.Euler(0f, orient, 0f) * Vector3.forward;
		   controller.Move(move.normalized * speed * Time.deltaTime);
	   }
    }
	
	void FixedUpdate()
	{
		if (Input.GetButtonDown("Jump") && grounded)
	   {
		   rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
		   grounded = false;
	   }
	}
	
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Ground"))
			grounded = true;
	}
}
