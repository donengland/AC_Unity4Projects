using UnityEngine;
using LibNoise;
using System.Collections;

public class backGround : MonoBehaviour {
	
	private Texture2D texture;
	private Perlin perlinNoise;
	
	// Use this for initialization
	void Start () {
		//Create the texture
		texture = new Texture2D(512,512);
		texture.wrapMode = TextureWrapMode.Repeat;
		
		//Create Voronoi noise
		perlinNoise = new Perlin();
		
		gameObject.renderer.material.mainTexture = texture;
		
		int pixels = texture.width * texture.height;
		int width = texture.width;
		int height = texture.height;
		Color[] colors = new Color[pixels];
		
		for(int i = 0; i < pixels; i++){
			float depth = Time.time/2f;
			float value =(float)perlinNoise.GetValue((float)(i % width) / width * 4f, depth, i / width / (float)width * 4f);
			colors[i] = new Color(1f-value, 1f-value, 1f-(value * .5f));
		}
		texture.SetPixels(colors);
		texture.Apply();
		
		//StartCoroutine(UpdateImage());
	}
	
	void FixedUpdate(){
		float scaleX = Mathf.Cos (Time.time * .1f) * 0.5f + 1f;
    	float scaleY = Mathf.Sin (Time.time * .1f) * 0.5f + 1f;
    	gameObject.renderer.material.mainTextureScale = new Vector2(scaleX,scaleY);	
	}
	
}
