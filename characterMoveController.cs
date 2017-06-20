/*
 * Deals with moving the character.
 * 
 * This script should be attatched to a rigidbody object parented to a camera that has the
 * characterLookController.cs script attatched to it. The following adjustments are not 
 * necessary, but highly reccomended: 
 * In the Rigidbody component, open the constraints menu and freeze the X and Z rotation.
 * In the Rigidbody component, open the constraints menu and freeze the Y position.
 * In the Rigidbody component, select 'Interpolate' from the Interpolate menu.
 * In the Rigidbody component, select 'Continuous' (or 'Continuous Dynamic') from the Collision Detection menu.
 * 
 * This script is complete and you can copy/ paste it as-is.
 * 
 * Remember: It's unnecessary to change public variables right in this script as they can be 
 * edited from the unity inspector without having to recompile/ reopen every edit.
 * 
 * Available for free from: https://github.com/B-Roux
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class characterMovementController : MonoBehaviour {
	//public variables
	public float walkSpeed; //this variable deals with walking speed, I find using a value of ~3.0 works best
	public float sprintMultiplier; //this variable deals with the sprint (LShift) multiplier to walking speed, I find using a value of ~2.0 works best
	//non-public global variable
	float speed;
	//initializing the cursor lockstate
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	void Update() {
		//makes sure you can only sprint foreward
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift)){
			speed = walkSpeed * sprintMultiplier;
		} else {speed = walkSpeed;}
		//getting the direction 
		float forewardBack = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		float leftRight = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		transform.Translate (leftRight, 0, forewardBack);
		//changing the cursor lockstate upon pressing escape
		if(Input.GetKeyDown("escape")) Cursor.lockState = CursorLockMode.None;
	}
}
