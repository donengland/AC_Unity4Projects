using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	public bool isMoving;
	
	IEnumerator moveTo(Vector3 Target)
	{
		Debug.Log ("Move to was called");
		Vector3 Direction = findDirection(Target);
		isMoving = true;
		
		
		int loopLength = (int)Mathf.RoundToInt (Vector3.Distance (transform.position, Target));
		
		for(int i = 0; i < loopLength; i++)
		{
			//Move one spot over, until you're either not free to move, or you reach the target
			if(!isFreetoMove (Direction))
			{
				isMoving = false;
				yield break;
			}
			else
			{
				yield return StartCoroutine(moveOne(Direction));
			}	
		}
		isMoving = false;
	}
	
	IEnumerator moveOne(Vector3 Direction)
	{
		//Already know we're free to move in Direction, just going to move 1 space over
		if(Direction == Vector3.right)
		{
			for(int i = 0; i < 10; i++)
			{
				yield return new WaitForSeconds(.01f);
				transform.parent.position = Vector3.MoveTowards (transform.parent.position, new Vector3(
					transform.parent.position.x + .1f,
					transform.parent.position.y,
					transform.parent.position.z), 1f);
			}
		}
		if(Direction == Vector3.left)
		{
			for(int i = 0; i < 10; i++)
			{
				yield return new WaitForSeconds(.01f);
				transform.parent.position = Vector3.MoveTowards (transform.parent.position, new Vector3(
					transform.parent.position.x - .1f,
					transform.parent.position.y,
					transform.parent.position.z), 1f);
			}
		}
		if(Direction == Vector3.up)
		{
			transform.parent.rigidbody.useGravity = false;
			for(int i = 0; i < 10; i++)
			{
				yield return new WaitForSeconds(.01f);
				transform.parent.position = Vector3.MoveTowards (transform.parent.position, new Vector3(
					transform.parent.position.x,
					transform.parent.position.y + .1f,
					transform.parent.position.z), 10f);
			}
			transform.parent.rigidbody.useGravity = true;
		}
		if(Direction == Vector3.down)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
		}
	
	}
	
	bool isFreetoMove(Vector3 Direction)
	{
		RaycastHit hit;
		
		if (Physics.Raycast (transform.position, Direction, out hit, 1f)) 
		{
			//If something is in the way of the movement, don't move
			Debug.Log ("Not Free to Move");
        	return false;
    	}
		
		if (gameObject.name == "HeavyNMPBlok(Clone)")
		{
			//If you're a heavy block, you can only move if you're ontop of frozen or nothing
			if(OntopOf () == PBlokConstants.blokAct.surface_frozen || OntopOf () == PBlokConstants.blokAct.empty)
			{
				return true;
			}
			else
			{
				
				Debug.Log ("HeavyBlok returned false in isFreetoMove");
				return false;
			}
		}
		else if(gameObject.name == "NormalNMPBlok(Clone)")
		{
			
			return true;
		
		}
		else
		{
			
			return false;
			
		}
		
	}
	
	PBlokConstants.blokAct OntopOf()
	{
		RaycastHit hit;
		
		if(Physics.Raycast (transform.position, Vector3.down, out hit, 1f))
		{
			return hit.collider.GetComponent<PBlok>().getAct ();
			
		}
	
		return PBlokConstants.blokAct.empty;
	}
	
	Vector3 findDirection(Vector3 Target)
	{
		
		if(transform.position.x > Target.x)
		{
			return Vector3.left;
		}
		if(transform.position.x < Target.x)
		{
			return Vector3.right;
		}
		if(transform.position.y > Target.y)
		{
			return Vector3.down;
		}
		if(transform.position.y < Target.y)
		{
			return Vector3.up;
		}
		
		
		Debug.Log ("Error in findDirection");
		return Vector3.zero;
	}
	
	
}
