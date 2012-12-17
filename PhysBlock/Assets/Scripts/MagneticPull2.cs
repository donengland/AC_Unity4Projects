using UnityEngine;
using System.Collections;

public class MagneticPull2 : MonoBehaviour {
	
	
	private RaycastHit[] hitsRight;
	private RaycastHit[] hitsLeft;
	private RaycastHit[] hitsUp;
	private RaycastHit[] hitsDown;
	// Use this for initialization
	void Start () {
	
	}
	
	void Awake()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		hitsRight = Physics.RaycastAll (transform.position, Vector3.right, 20f);
		hitsLeft  = Physics.RaycastAll (transform.position, Vector3.left, 20f);
		hitsUp    = Physics.RaycastAll (transform.position, Vector3.up, 20f);
		hitsDown  = Physics.RaycastAll (transform.position, Vector3.down, 20f);
		
		//Debug.DrawLine (transform.position, transform.position + Vector3.right *20, Color.blue, 20f);
		
		foreach(RaycastHit hit in hitsRight)
		{
			if(hit.collider.name == "PBlok(Clone)")
			{
				PBlok pblok = hit.collider.GetComponent<PBlok>();
				
				if(pblok.getAct() == PBlokConstants.blokAct.block_normal ||
					pblok.getAct () == PBlokConstants.blokAct.block_heavy)
				{
					Move move = hit.collider.gameObject.GetComponentInChildren<Move>();
					
					if(move == null)
					{
						Debug.Log ("Move equals null");
					}
					
					if(!move.getisInMagnet())
					{
						Vector3 Target = transform.position + Vector3.right;
						hit.collider.gameObject.BroadcastMessage ("moveTo", Target);
						hit.collider.rigidbody.isKinematic = true;
						hit.collider.rigidbody.useGravity = false;
					}
					
					
					move.setMagnetTrue();
					
					if(!(Mathf.Abs (transform.position.y - hit.collider.transform.position.y) <.01))
					{
						hit.collider.transform.position = Vector3.MoveTowards (hit.collider.transform.position, new Vector3(
							hit.collider.transform.position.x,
							transform.position.y,
							hit.collider.transform.position.z),1f);
					}
				}
			
			}
		}
		foreach(RaycastHit hit in hitsLeft)
		{
			if(hit.collider.name == "PBlok(Clone)")
			{
				PBlok pblok = hit.collider.GetComponent<PBlok>();
				
				if(pblok.getAct() == PBlokConstants.blokAct.block_normal ||
					pblok.getAct () == PBlokConstants.blokAct.block_heavy)
				{
					Move move = hit.collider.gameObject.GetComponentInChildren<Move>();
					
					if(move == null)
					{
						Debug.Log ("Move equals null");
					}
					
					if(!move.getisInMagnet())
					{
						Vector3 Target = transform.position + Vector3.left;
						hit.collider.gameObject.BroadcastMessage ("moveTo", Target);
						hit.collider.rigidbody.isKinematic = true;
						hit.collider.rigidbody.useGravity = false;
					}
					
					
					move.setMagnetTrue();
					
					if(!(Mathf.Abs (transform.position.y - hit.collider.transform.position.y) <.01))
					{
						hit.collider.transform.position = Vector3.MoveTowards (hit.collider.transform.position, new Vector3(
							hit.collider.transform.position.x,
							transform.position.y,
							hit.collider.transform.position.z),1f);
					}
				}
			
			}
		}
		
		foreach(RaycastHit hit in hitsUp)
		{
			if(hit.collider.name == "PBlok(Clone)")
			{
				PBlok pblok = hit.collider.GetComponent<PBlok>();
				
				if(pblok.getAct() == PBlokConstants.blokAct.block_normal)
				{
					Move move = hit.collider.gameObject.GetComponentInChildren<Move>();
					
					if(move == null)
					{
						Debug.Log ("Move equals null");
					}
					
					if(!move.getisInMagnet())
					{
						Vector3 Target = transform.position + Vector3.up;
						hit.collider.gameObject.BroadcastMessage ("moveTo", Target);
						hit.collider.rigidbody.isKinematic = true;
						hit.collider.rigidbody.useGravity = false;
					}
					
					
					move.setMagnetTrue();
					
					if(!(Mathf.Abs (transform.position.x - hit.collider.transform.position.x) <.01))
					{
						hit.collider.transform.position = Vector3.MoveTowards (hit.collider.transform.position, new Vector3(
							transform.position.x,
							hit.collider.transform.position.y,
							hit.collider.transform.position.z),1f);
					}
				}
			
			}
		}
		
		
		foreach(RaycastHit hit in hitsDown)
		{
			if(hit.collider.name == "PBlok(Clone)")
			{
				PBlok pblok = hit.collider.GetComponent<PBlok>();
				
				if(pblok.getAct() == PBlokConstants.blokAct.block_normal)
				{
					Move move = hit.collider.gameObject.GetComponentInChildren<Move>();
					
					if(move == null)
					{
						Debug.Log ("Move equals null");
					}
					
					if(!move.getisInMagnet())
					{
						Vector3 Target = transform.position + Vector3.down;
						Debug.DrawLine (transform.position, Target, Color.green,200f);
						Debug.Log (Target);
						hit.collider.gameObject.BroadcastMessage ("moveTo", Target);
						hit.collider.rigidbody.isKinematic = true;
						hit.collider.rigidbody.useGravity = false;
					}
					
					
					move.setMagnetTrue();
					
					if(!(Mathf.Abs (transform.position.x - hit.collider.transform.position.x) <.01))
					{
						hit.collider.transform.position = Vector3.MoveTowards (hit.collider.transform.position, new Vector3(
							transform.position.x,
							hit.collider.transform.position.y,
							hit.collider.transform.position.z),1f);
					}
				}
			
			}
		}
	
	}
	
	
	void OnDestroy()
	{
		foreach(RaycastHit hit in hitsRight)
		{
			if(hit.collider.name == "PBlok(Clone)")
			{
				PBlok pblok = hit.collider.GetComponent<PBlok>();
				if(pblok.getAct() == PBlokConstants.blokAct.block_normal)
				{
					Move move = hit.collider.GetComponentInChildren<Move>();
					move.setMagnetFalse();
					hit.transform.rigidbody.isKinematic = false;
					hit.collider.rigidbody.useGravity = true;
				}
			}
		}
		foreach(RaycastHit hit in hitsLeft)
		{
			if(hit.collider.name == "PBlok(Clone)")
			{
				PBlok pblok = hit.collider.GetComponent<PBlok>();
				if(pblok.getAct() == PBlokConstants.blokAct.block_normal)
				{
					
					Move move = hit.collider.GetComponentInChildren<Move>();
					move.setMagnetFalse();
					hit.transform.rigidbody.isKinematic = false;
					hit.collider.rigidbody.useGravity = true;
				}
			}
		}
		
		foreach(RaycastHit hit in hitsUp)
		{
			if(hit.collider.name == "PBlok(Clone)")
			{
				PBlok pblok = hit.collider.GetComponent<PBlok>();
				if(pblok.getAct() == PBlokConstants.blokAct.block_normal)
				{
					
					Move move = hit.collider.GetComponentInChildren<Move>();
					move.setMagnetFalse();
					hit.transform.rigidbody.isKinematic = false;
					hit.collider.rigidbody.useGravity = true;
				}
			}
		}
		
		foreach(RaycastHit hit in hitsDown)
		{
			if(hit.collider.name == "PBlok(Clone)")
			{
				
				PBlok pblok = hit.collider.GetComponent<PBlok>();
				if(pblok.getAct() == PBlokConstants.blokAct.block_normal)
				{
					
					Move move = hit.collider.GetComponentInChildren<Move>();
					move.setMagnetFalse();
					hit.transform.rigidbody.isKinematic = false;
					hit.collider.rigidbody.useGravity = true;
				}
			}
		}
	}
}
