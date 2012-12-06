using UnityEngine;
using LibNoise;
using System.Collections;

public class perlinBG : MonoBehaviour {
	private Texture2D texture;
	//private Texture3D dataHolder;
	private Perlin perlinNoise;
	private Color[] colorHolder;
	
	public float blueTint;
	public float redTint;
	public float greenTint;
	
	// Use this for initialization
	void Start () {
		//Create the texture
		texture = new Texture2D(256,256);
		//dataHolder = new Texture3D(256,256,256,TextureFormat.ATF_RGB_JPG, false);
		texture.wrapMode = TextureWrapMode.Repeat;
		
		//Create Voronoi noise
		perlinNoise = new Perlin();
		
		gameObject.renderer.material.mainTexture = texture;
		
		int pixels = texture.width * texture.width * texture.height;
		int width = texture.width;
		int height = texture.height;
		int depth = texture.width;
		colorHolder = new Color[pixels];
		
		for(int i = 0; i < pixels; i++){
			float value =(float)perlinNoise.GetValue((float)(i % width) / width * 4f, depth, i / width / (float)width * 4f);
			colorHolder[i] = new Color((redTint * value)+.5f, (greenTint * value)+.5f, (blueTint * value)+.3f);
		}
		
		//dataHolder.SetPixels(colorHolder);
		//dataHolder.Apply();
		StartCoroutine(UpdateImage());
	}
	
	private IEnumerator UpdateImage(){
		/*
		int pixels = texture.width * texture.height;
		int width = texture.width;
		int height = texture.height;
		Color[] colors = new Color[pixels];
		
		while(true){
			for(int i = 0; i < pixels; i++){
				float depth = Time.time/2f;
				float value =(float)perlinNoise.GetValue((float)(i % width) / width * 4f, depth, i / width / (float)width * 4f);
				colors[i] = new Color(value, value, value);
			}
			texture.SetPixels(colors);
			texture.Apply();
			yield return null;
		}
		*/
		int pixels = texture.width * texture.height;
		int width = texture.width;
		int height = texture.height;
		
		Color[] colors = new Color[pixels];
		while(true){
			int depth = (int)(Time.time) % width;
			Color[] oldColors = texture.GetPixels();
			for(int i = 0; i < pixels;i++){
				
				colors[i] = Color.Lerp(colorHolder[i + (depth * width * height)], oldColors[i], (float)depth/width);		
			}
			texture.SetPixels(colors);
			texture.Apply();
			yield return null;
		}
	}
	
	
}
