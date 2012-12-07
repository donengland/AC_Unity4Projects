using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	public bool isMoving;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
		
	
	
	IEnumerator moveTo(Vector3 Target)
	{
		Vector3 Direction = findDirection(Target);
		isMoving = true;
		
		//Debug.Log (Vector3.Distance (transform.position, Target.transform.position));
		//int loopLength = Mathf.Abs (transform.position.x - Target.transform.position);
		//Debug.Log (loopLength);
		
		int loopLength = (int)Vector3.Distance (transform.position, Target);
		Debug.Log (loopLength);
		
		for(int i = 0; i < loopLength; i++)
		{
			if(!isFreetoMove (Direction))
			{
				isMoving = false;
				yield break;
			}
			else
			{
				Debug.Log("Testing");
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
			//Vector3 Position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
			//transform.parent.rigidbody.useGravity = false;
			for(int i = 0; i < 10; i++)
			{
				yield return new WaitForSeconds(.01f);
				//transform.parent.position = new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z);
				transform.parent.position = Vector3.MoveTowards (transform.parent.position, new Vector3(
					transform.parent.position.x + .1f,
					transform.parent.position.y,
					transform.parent.position.z), 1f);
			}
			//transform.parent.rigidbody.useGravity = true;
		}
		if(Direction == Vector3.left)
		{
			for(int i = 0; i < 10; i++)
			{
				yield return new WaitForSeconds(.01f);
				//transform.parent.position = new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z);
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
				//transform.parent.position = new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z);
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
			Debug.Log ("Not Free to Move");
        	return false;
    	}
		
		return true;
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
