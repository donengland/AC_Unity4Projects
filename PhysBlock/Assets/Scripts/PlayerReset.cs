using UnityEngine;
using System.Collections;

public class PlayerReset : MonoBehaviour {
	
	public LangmanController playerScript;
	
	// Use this for initialization
	void Start () {
		playerScript = GameObject.Find ("PlayerSphere").GetComponent<LangmanController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(){
		Debug.Log("In Collider Enter, presumably respawning player");
		playerScript.Spawn();
	}
}
