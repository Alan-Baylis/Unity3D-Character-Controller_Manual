/*
 * Deals with moving the character.
 * 
 * This script should be attatched to a rigidbody object parented to a camera that has the
 * characterLookController.cs script attatched to it.
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
	public float walkSpeed;
	public float sprintMultiplier;
	float speed;
	//initializing the cursor lockstate
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	void Update() {
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift)){
			speed = walkSpeed * sprintMultiplier;
		} else {speed = walkSpeed;}
		//getting the direction 
		float forewardBack = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		float leftRight = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		transform.Translate (leftRight, 0, forewardBack);
		//changing the cursor lockstate upon 
		if(Input.GetKeyDown("escape")) Cursor.lockState = CursorLockMode.None;
	}
}
