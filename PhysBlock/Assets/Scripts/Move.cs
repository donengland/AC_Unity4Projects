using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	private bool isMoving;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
		
	
	
	IEnumerator moveTo(GameObject Target)
	{
		Vector3 Direction = findDirection(Target);
		
		//Debug.Log (Vector3.Distance (transform.position, Target.transform.position));
		//int loopLength = Mathf.Abs (transform.position.x - Target.transform.position);
		//Debug.Log (loopLength);
		
		int loopLength = (int)Vector3.Distance (transform.position, Target.transform.position);
		//Debug.Log (loopLength);
		
		for(int i = 0; i < loopLength - 1; i++)
		{
			if(isFreetoMove (Direction))
			{
				Debug.Log("Testing");
				yield return StartCoroutine(moveOne(Direction));
			}	
		}
		Debug.Log ("MoveToComplete");
	}
	
	IEnumerator moveOne(Vector3 Direction)
	{
		//Already know we're free to move in Direction, just going to move 1 space over
		if(Direction == Vector3.right)
		{
			Vector3 Position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
			
			for(int i = 0; i < 10; i++)
			{
				yield return new WaitForSeconds(.01f);
				transform.parent.position = new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z);
			}
		}
		if(Direction == Vector3.left)
		{
			transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
		}
		if(Direction == Vector3.up)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
		}
		if(Direction == Vector3.down)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
		}
	
	}
	
	bool isFreetoMove(Vector3 Direction)
	{
		RaycastHit hit;
		
		if (Physics.Raycast (transform.position, Direction, out hit, 1)) 
		{
        	return false;
    	}
		
		return true;
	}
	
	Vector3 findDirection(GameObject Target)
	{
		
		if(transform.position.x > Target.transform.position.x)
		{
			return Vector3.left;
		}
		if(transform.position.x < Target.transform.position.x)
		{
			return Vector3.right;
		}
		if(transform.position.y > Target.transform.position.y)
		{
			return Vector3.down;
		}
		if(transform.position.y < Target.transform.position.y)
		{
			return Vector3.up;
		}
		
		Debug.Log ("Error in findDirection");
		return Vector3.zero;
	}
	
	
}
