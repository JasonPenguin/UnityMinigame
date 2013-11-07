using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gamemanager : MonoBehaviour {

	public GameObject prefabToSpawn;
	public GameObject pointprefab;
	
	public List<GameObject> objects;
	public GameObject obstacle;
	public Vector3 spawnLocation;
	
	public float spawntimer;
	public float pointspawntimer;
	public float timeTillstart;
	
	private bool startGame;
	
	private int MeteorPosition;
	private int PointPosition;
	
	
	// Use this for initialization
	void Start () {
		startGame = false;
		objects = new List<GameObject>();
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		timeTillstart += Time.deltaTime;
		if(timeTillstart >= 2)
		{
			startGame = true;
		}
		
		if(startGame)
		{
			spawntimer += Time.deltaTime;
			pointspawntimer += Time.deltaTime;
			if(spawntimer >= 0.3f)
			{
				MeteorPosition = Random.Range(-25,10);
				obstacle = Instantiate(prefabToSpawn,new Vector3(MeteorPosition,25,0),Quaternion.identity) as GameObject;
				obstacle.renderer.material.color = Color.red;
				objects.Add(obstacle);
				spawntimer = 0;
			}
			
			if(pointspawntimer >= 0.7f)
			{
				PointPosition = Random.Range(-25,10);
				obstacle = Instantiate(pointprefab,new Vector3(PointPosition,25,0),Quaternion.identity)as GameObject;
				obstacle.renderer.material.color = Color.yellow;
				objects.Add(obstacle);
				pointspawntimer = 0;
			}
			
		}
		
		foreach(GameObject obj in objects)
		{
			//obj.transform.Translate(new Vector3(0,-0.3f,0));	
		}	
	}
}
