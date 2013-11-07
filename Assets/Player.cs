using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	
	public int jumpheight = 20;
	public float walkspeed = 10f;
	public bool isJumping = false;
	
	public CharacterMotor chmotor;
	public Gamemanager manager;
	
	public int maxHealth = 100;
	public int currentHealth = 100;
	public int points;
	
	public float healthBarLength;
	public GameObject MeteorPrefab;
	private bool canMove = true; 
	private Vector3 endposition;
	private Transform beginposition;
	

	void Start () {
		healthBarLength = Screen.width / 2;
		chmotor = GameObject.Find("Player").GetComponent<CharacterMotor>();
		manager = GameObject.Find("Manager").GetComponent<Gamemanager>();
		
		beginposition = transform;
		
		//chmotor.movement.maxForwardSpeed = 5;
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(10,10,healthBarLength,20),currentHealth +"/" + maxHealth);
		GUI.Label(new Rect(10,50,100,50),"Points :" + points);
	}
	
	
	
	public void AdjustCurrentHealth(int adj)
	{
		
		currentHealth += adj;
		
		if(currentHealth < 0)
		{
			currentHealth = 0;
		}
		
		if(currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}
		
		if(maxHealth < 1)
		{
			maxHealth = 1;
		}
		
		if(currentHealth <= 0)
		{
			Application.LoadLevel("GameOver");
		}
		
		healthBarLength = (Screen.width /2) * (currentHealth / (float)maxHealth);
	}
	
	// Update is called once per frame
	void Update () {
		AdjustCurrentHealth(0);
		CheckonStage();
		//CheckMeteorCollision();

	}
	
	private void CheckonStage()
	{
		if(transform.position.y <= -10)
			transform.Translate(new Vector3(0,50,0));			
	}
	
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Meteor")
		{
			Destroy(other.gameObject);
			AdjustCurrentHealth(-10);
		}
		
		if(other.tag == "Point")
		{
			Destroy(other.gameObject);
			points += 10;
		}
	}
	
}
