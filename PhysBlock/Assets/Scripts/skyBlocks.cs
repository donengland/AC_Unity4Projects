using UnityEngine;
using System.Collections.Generic;

public class skyBlocks : MonoBehaviour {
	
	public Transform player;
	
	public Transform prefab;
	public int numberOfCubes;
	public float recycleOffset;
	public Vector3 minSize, maxSize;
	
	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;
	
	// Use this for initialization
	void Start () {
		objectQueue = new Queue<Transform>(numberOfCubes);
		for(int i = 0; i < numberOfCubes; i++){
			objectQueue.Enqueue((Transform)Instantiate(prefab));
		}
		nextPosition = transform.localPosition;
		for(int i = 0; i < numberOfCubes; i++){
			Recycle();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(objectQueue.Peek().localPosition.x + recycleOffset < Vector3.Distance(player.position, transform.position)){
			Recycle();
		}
	}
	
	private void Recycle(){
		Vector3 scale = new Vector3(
			Random.Range(minSize.x, maxSize.x),
			Random.Range(minSize.y, maxSize.y),
			1f);

		Vector3 position = nextPosition;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;

		Transform o = objectQueue.Dequeue();
		o.localScale = scale;
		o.localPosition = position;
		nextPosition.x += scale.x;
		objectQueue.Enqueue(o);
	}
	
	public void Reset(){
		nextPosition = new Vector3(player.position.x - 25, nextPosition.y, nextPosition.z);	
		for(int i = 0; i < numberOfCubes; i++){
			Recycle();
		}
	}
}
