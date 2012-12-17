using UnityEngine;
using System.Collections;

public class startScreenGUI : MonoBehaviour {
	
	public string nextLevel;
	public Camera playerCam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			BroadcastMessage("activateGravity");
			Debug.Log("Broadcasting message");
			playerCam.SendMessage("Play");
			gameObject.animation.Play();
		}
	}
	
	void OnGUI(){
		GUI.Box (new Rect ((.75f*Screen.width)/2f,(3f*Screen.height)/4f,200,25), "Press Space to Start");
	}
	
	void loadNextLevel(){
		Application.LoadLevel(nextLevel);
	}
}
