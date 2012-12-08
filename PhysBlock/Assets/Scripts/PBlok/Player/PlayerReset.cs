/**** @author: Don England
	* @since: 20-Nov-2012
	*/

using UnityEngine;
using System.Collections;

public class PlayerReset : MonoBehaviour {
	
	public Transform background;
	
	public LangmanController playerScript;
	
	// Use this for initialization
	void Start () {
		playerScript = GameObject.Find ("Player_bot").GetComponent<LangmanController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){
		Debug.Log("In Collider Enter, presumably respawning player");
		Debug.Log(col.gameObject.name);
		if(col.gameObject.transform.parent.gameObject.name == "Player")
			playerScript.Spawn();
		//Reset background so it doesn't disappear
		background.SendMessage("Reset");
	}
}
