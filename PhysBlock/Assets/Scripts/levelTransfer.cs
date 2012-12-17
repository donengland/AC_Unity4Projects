using UnityEngine;
using System.Collections;

public class levelTransfer : MonoBehaviour {
	
	public string nextLevel;
	private GameObject Player;
	private Click playerC;
	public bool Magnet;
	public bool Frozen;
	public bool Normal;
	// Use this for initialization
	void Start () {
		
		Player = GameObject.Find ("Player");
		playerC = Player.GetComponentInChildren<Click>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collide){
		Debug.Log(collide.name);
		if(collide.name.Equals("PlayerSphere")){
			
			if(Normal)
			{
				playerC.SetNorm (true);
			}
			if(Magnet)
			{
				playerC.SetMagnetic (true);
			}
			if(Frozen)
			{
				playerC.SetFrozen (true);
			}
			Application.LoadLevel(nextLevel);
		}
	}
}
