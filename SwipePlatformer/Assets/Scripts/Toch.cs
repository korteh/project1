using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toch : MonoBehaviour {

    public float speed = 5f;
    public float SpdMlt = 3;
    public float XSpeed;
    public float ZSpeed;
    public float gravity = 20f;
    public float jumpSpeed = 10f;

    private CharacterController controller;
    public Vector3 MoveDir;
    private bool GrPnd = false; 
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        // speed multipliers
		if (Input.GetButtonDown("Horizontal"))
        {
            ZSpeed =0;
            XSpeed += 1 * Input.GetAxisRaw("Horizontal");
            XSpeed = Mathf.Clamp(XSpeed, -SpdMlt, SpdMlt);
        }
        if (Input.GetButtonDown("Vertical")) {
            XSpeed = 0;
            ZSpeed += 1 * Input.GetAxisRaw("Vertical");
            ZSpeed = Mathf.Clamp(ZSpeed, -SpdMlt, SpdMlt);
        }
        // movement
        MoveDir.x = XSpeed * speed;
        MoveDir.z = ZSpeed * speed;

        if (controller.isGrounded)
        {
            //MoveDir = new Vector3(XSpeed, 0, ZSpeed) * speed;
            MoveDir.y = 0;
            if (Input.GetButtonDown("Jump")) // jump
            {
                MoveDir.y = jumpSpeed;
            }
            if (GrPnd == true) GrPnd = false;
        }else
        {
            //Ground pound
            if (Input.GetButtonDown("Jump") && GrPnd == false)  
            {
                ZSpeed = 0;
                XSpeed = 0;
                MoveDir.y -= gravity/2.2f;
                GrPnd = true;
            }
        }
        // apply movement
        MoveDir.y -= gravity * Time.deltaTime;
        controller.Move(MoveDir * Time.deltaTime);

        
    }
    //collisions
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        // collissions with walls
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }
        else
        {
            ZSpeed = 0;
            XSpeed = 0;
        }


    }
}
