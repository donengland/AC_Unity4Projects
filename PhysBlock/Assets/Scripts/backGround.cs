using UnityEngine;
using LibNoise;
using System.Collections;

public class backGround : MonoBehaviour {
	
	private Texture2D texture;
	private Checkerboard checkerNoise;
	
	// Use this for initialization
	void Start () {
		//Create the texture
		texture = new Texture2D(512,512);
		texture.wrapMode = TextureWrapMode.Repeat;
		
		//Create Voronoi noise
		checkerNoise = new Checkerboard();
		
		gameObject.renderer.material.mainTexture = texture;
		
		int pixels = texture.width * texture.height;
		int width = texture.width;
		int height = texture.height;
		Color[] colors = new Color[pixels];
		
		for(int i = 0; i < pixels; i++){
			float depth = Time.time/2f;
			float value =(float)checkerNoise.GetValue((float)(i % width) / width * 4f, depth, i / width / (float)width * 4f);
			colors[i] = new Color(value, value, value);
		}
		texture.SetPixels(colors);
		texture.Apply();
		
		//StartCoroutine(UpdateImage());
	}
	
	// Update is called once per frame
	/*
	void FixedUpdate () {
		int pixels = texture.width * texture.height;
		int width = texture.width;
		int height = texture.height;
		Color[] colors = new Color[pixels];
		for(int i = 0; i < pixels; i++){
			float depth = Time.time/2f;
			float value =(float)checkerNoise.GetValue((float)(i % width) / width * 4f, depth, i / width / (float)width * 4f);
			colors[i] = new Color(value, value, value);
		}
		texture.SetPixels(colors);
		texture.Apply();
	}*/
	
	private IEnumerator UpdateImage(){
		int pixels = texture.width * texture.height;
		int width = texture.width;
		int height = texture.height;
		Color[] colors = new Color[pixels];
		
		while(true){
			for(int i = 0; i < pixels; i++){
				float depth = Time.time/2f;
				float value =(float)checkerNoise.GetValue((float)(i % width) / width * 4f, depth, i / width / (float)width * 4f);
				colors[i] = new Color(value, value, value);
			}
			texture.SetPixels(colors);
			texture.Apply();
			yield return null;
		}
	}
	
	
	
}
