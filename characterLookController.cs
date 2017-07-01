/*
 * Deals with rotating the camera.
 * 
 * This script should be attatched to a camera which is a direct child to a rigidbody object
 * that has the characterMoveController.cs script attatched to it.
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
public class characterLookController : MonoBehaviour {
	//public variables
	[SerializeField]
	private float sensitivity; //this variable deals with mouse sensitivity, I find using a value of ~3.0 works best
	[SerializeField]
	private float smooth; //this variable deals with smoothing the movement, I find using a value of ~2.0 works best
	[SerializeField]
	private float maxY; //this variable deals with setting the maximum angle of elevation in degrees, I find using a value of ~45.0 works best
	[SerializeField]
	private float minY; //this variable deals with setting the minimum angle of depression in degrees, I find using a value of ~-45.0 works best
	//the following variables set optional control inversion. Next to them are my reccomended defaults.
	[SerializeField]
	private bool invertVertical; //false
	[SerializeField]
	private bool invertHorizontal; //false
	//locals
	private Vector2 smoothV;
	private Vector2 eulerAnglesVar;
	private float invertVerticalFact;
	private float invertHorizontalFact;
	private GameObject character;
	void Start () {
		//these deal with inverting controls
		invertVerticalFact = (invertVertical) ? -1 : 1;
		invertHorizontalFact = (invertHorizontal) ? -1 : 1;
		//this innitializes the character as the parent object
		character = this.transform.parent.gameObject;
	}
	//Rotating the mouse
	void LateUpdate() {
		// Move and smooth
		Vector2 mouseMove = new Vector2 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"));
		mouseMove *= sensitivity;
		smoothV.x = Mathf.LerpAngle (smoothV.x, mouseMove.x, (Time.smoothDeltaTime * smooth));
		smoothV.y = Mathf.LerpAngle (smoothV.y, mouseMove.y, (Time.smoothDeltaTime * smooth));
		// Euler rotation
		eulerAnglesVar.x = Mathf.Clamp ((eulerAnglesVar.x + smoothV.y * invertVertical), minY, maxY);
		eulerAnglesVar.y += smoothV.x * invertHorizontal;
		//apply Changes
		transform.localRotation = Quaternion.AngleAxis (-eulerAnglesVar.x, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (eulerAnglesVar.y, character.transform.up);
	}
}
