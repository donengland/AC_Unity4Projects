using UnityEngine;
using System.Collections;

public class fallingController : MonoBehaviour {
	
	public GameObject player;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Animator>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.localPosition.y < -68f){
			Debug.Log("Hit");
			gameObject.animation.Stop();
			gameObject.animation.enabled = false;
			Animator anims = gameObject.GetComponent<Animator>();
			anims.enabled = true;
			anims.SetBool("Squat",true);
			player.transform.position = new Vector3(0,1,0);
			gameObject.SendMessage("Spawn");
			Destroy (gameObject.animation);
			Destroy(this);
		}
	}
	

}
