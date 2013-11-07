using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(400,300,100,60),"Restart"))
		{
			Application.LoadLevel("PlatformGame");
		}
		
		GUI.Label(new Rect(400,150,100,60),"GameOver!");
		
	}
}
