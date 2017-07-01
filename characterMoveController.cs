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
	[SerializeField]
	private float walkSpeed; //this variable deals with walking speed, I find using a value of ~3.0 works best
	[SerializeField]
	private float sprintMultiplier; //this variable deals with the sprint (LShift) multiplier to walking speed, I find using a value of ~2.0 works best
	//the following variables set the keys for certain commands. Next to them are my reccomended settings (case sensitive, without quotes)
	[SerializeField]
	private string forwardMove; //"w"
	[SerializeField]
	private string backwardMove; //"s"
	[SerializeField]
	private string leftMove; //"a"
	[SerializeField]
	private string rightMove; //"d"
	[SerializeField]
	private string sprint; //"left shift"
	[SerializeField]
	private string autoSprintToggle; //"caps lock"
	[SerializeField]
	private string escape; //"escape"
	//locals
	private float speed;
	private bool autoSprint = false;
	private int vertical = 0;
	private int horizontal = 0;
	//initializing the cursor lockstate
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	void Update() {
		//sets the controls
		if (Input.GetKey (forwardMove))
			vertical = 1;
		else if (Input.GetKey (backwardMove))
			vertical = -1;
		else
			vertical = 0;
		if (Input.GetKey (rightMove))
			horizontal = 1;
		else if (Input.GetKey (leftMove))
			horizontal = -1;
		else
			horizontal = 0;
		//toggles capslock (autosprint)
		if (Input.GetKeyDown(autoSprintToggle))
		if (autoSprint) autoSprint = false; else autoSprint = true;
		//makes sure you can only sprint foreward
		if (Input.GetKey (forwardMove) && (Input.GetKey (sprint) || autoSprint)) 
			speed = walkSpeed * sprintMultiplier;
		else speed = walkSpeed;
		//getting the direction 
		float forewardBack = vertical * speed * Time.deltaTime;
		float leftRight = horizontal * speed * Time.deltaTime;
		transform.Translate (leftRight, 0, forewardBack);
		//changing the cursor lockstate upon pressing escape, or update it if it's visible.
		if(Input.anyKeyDown) Cursor.lockState = CursorLockMode.Locked;
		if(Input.GetKeyDown(escape)) Cursor.lockState = CursorLockMode.None;

	}
}
