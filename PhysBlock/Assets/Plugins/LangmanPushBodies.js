// This is a modified version of the PlatformerPushBodies from 
// the 2D Lerpz tutorial (http://unity3d.com/support/resources/tutorials/2d-gameplay-tutorial.html).
// 
// The primary changes I made were to comment out the layer stuff since I wasn't using it
// and to only change the velocity of the rigidbody being pushed if the rigidbody's velocity
// is less than the character's. Without the latter change, rollable spheres would "stick" to the
// character when the character stopped moving.
//
// Changes by Ehren von Lehe. Feel free to use this code in your own projects.
// http://vonlehecreative.com
#pragma strict
// Script added to a player for it to be able to push rigidbodies around.

// How hard the player can push
var pushPower = 0.5;

// Which layers the player can push
// This is useful to make unpushable rigidbodies
//var pushLayers : LayerMask = -1;

// pointer to the player so we can get values from it quickly
private var controller : LangmanController;

function Awake () {
	controller = GetComponent (LangmanController) as LangmanController;
}

function OnControllerColliderHit (hit : ControllerColliderHit) {
	var hitRb : Rigidbody = hit.collider.attachedRigidbody;
	// no rigidbody
	if (hitRb == null || hitRb.isKinematic)
		return;

	// Only push rigidbodies in the right layers
	//var hitRbLayerMask = 1 << hitRb.gameObject.layer;
	//if ((hitRbLayerMask & pushLayers.value) == 0)
	//	return;
		
	// We dont want to push objects below us
	if (hit.moveDirection.y < -0.3) 
		return;
	
	// Calculate push direction from move direction, we only push objects to the sides
	// never up and down
	var pushDir = Vector3 (hit.moveDirection.x, 0.0, 0.0);
	
	var targetSpeed = pushDir * pushPower * Mathf.Min (controller.GetSpeed(), controller.movement.runSpeed);
	// Push with move speed but only if the rigidbody's speed is lower.
	// This keeps bodies like rollable spheres from "sticking" to the character
	// when the character stops moving.
	if(hitRb.velocity.sqrMagnitude <= (targetSpeed.sqrMagnitude * 1.25)){
		hitRb.velocity = targetSpeed;
	}
}
