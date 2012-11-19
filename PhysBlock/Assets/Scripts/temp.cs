using UnityEngine;
using System.Collections;

public class temp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshCollider>();
		gameObject.AddComponent<MeshRenderer>();
		gameObject.renderer.material = (Resources.Load("EmptyNMPBlok", typeof(Material))) as Material;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
		gameObject.renderer.material = (Resources.Load("DeathNMPBlok", typeof(Material))) as Material;
		}
	}
}
