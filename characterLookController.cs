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
	public float sensitivity; //this variable deals with mouse sensitivity, I find using a value of ~3.0 works best
	public float smooth; //this variable deals with smoothing the movement, I find using a value of ~2.0 works best
	public float maxY; //this variable deals with setting the maximum angle of elevation in degrees, I find using a value of ~45.0 works best
	public float minY; //this variable deals with setting the minimum angle of depression in degrees, I find using a value of ~-45.0 works best
	//the following variables set optional control inversion. Next to them are my reccomended defaults.
	public bool invertVertical; //false
	public bool invertHorizontal; //false
	//non-public global variables
	Vector2 smoothV;
	Vector2 eulerAnglesVar;
	float invertVerticalFact;
	float invertHorizontalFact;
	//Declarations and initializations
	GameObject character;
	void Start () {
		//these deal with inverting controls
		invertVerticalFact = (invertVertical) ? -1 : 1;
		invertHorizontalFact = (invertHorizontal) ? -1 : 1;
		//this innitializes the character as the parent object
		character = this.transform.parent.gameObject;
	}
	//Rotating the mouse
	private void Update() {
		// Move and smooth
		Vector2 mouseMove = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));
		mouseMove *= sensitivity * smooth;
		smoothV.x = Mathf.Lerp (smoothV.x, mouseMove.x, 1f / smooth);
		smoothV.y = Mathf.Lerp (smoothV.y, mouseMove.y, 1f / smooth);
		// Euler rotation
		eulerAnglesVar.x += smoothV.y * invertVerticalFact;
		eulerAnglesVar.y += smoothV.x * invertHorizontalFact;
		//clamps the up/ down rotation
		eulerAnglesVar.x = Mathf.Clamp(eulerAnglesVar.x, minY, maxY);
		//apply Changes
		transform.localRotation = Quaternion.AngleAxis (-eulerAnglesVar.x, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (eulerAnglesVar.y, character.transform.up);
	}
}
