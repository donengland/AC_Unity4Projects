using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider player){
		Debug.Log("Checkpoint hitting " + player.gameObject.name);
		if(player.gameObject.name == "PlayerSphere"){
			Debug.Log("CHECKPOINT!!!!");
			LangmanController control = player.gameObject.GetComponent<LangmanController>();
			Transform start = GameObject.Find("PlayerStart").transform;
			start.position = gameObject.transform.position;
		}
	}
}
