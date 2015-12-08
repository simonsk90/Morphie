using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
	public bool isDead = false;
	public float speed = 2f; //2
	public float stamina = 0;
	public int lives = 3; //Maybe remove and only use PlayerPrefs(lives)
	public Animator anim;
	public int shape = 1;
	public int previousShape;
	private Vector2 checkpoint;
	public CameraController cam;
	private int level;
	public AnimalContainer ac;
    public bool invulnerable = false;
	public bool reverseGravity = false;
	public bool abilitiesLocked = false;
	public HelperFunctions helperFunctions;
	public ObjectsController objectsController;
	//private float testTimer = 0f;

	void Awake ()
	{
		ac = gameObject.AddComponent<AnimalContainer>();
		anim = GetComponent<Animator>();
		cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
		helperFunctions = GameObject.Find("Factory").GetComponent<HelperFunctions>();
		objectsController = GameObject.Find("Factory").GetComponent<ObjectsController>();
	}

	void Start () 
	{
		lives = PlayerPrefs.GetInt("lives");

		if (lives <= 0)
		{
			PlayerPrefs.SetFloat ("checkpointX", 0);
			PlayerPrefs.SetFloat ("checkpointY", 0);
			lives = 3;
		}

		checkpoint.x = PlayerPrefs.GetFloat("checkpointX");
		checkpoint.y = PlayerPrefs.GetFloat("checkpointY");

		transform.position = checkpoint;
		cam.PositionCamera();



	}

	void Update () 
	{
		//Apply animals UpdateFunctions
		switch (shape)
		{
		case 1:
			ac.Animal1Update();
			break;
			
		case 2:	
			ac.Animal2Update();
			break;
			
		case 3:
			ac.Animal3Update();
			break;
			
		case 4:
			ac.Animal4Update();
			break;
		}

		transform.Translate(Vector2.right * this.speed * Time.deltaTime); //Moving to the right
		StaminaDecrement();

	}

	public void UseAbility()
	{
		if (!this.isDead && !abilitiesLocked)
		{
			switch (shape)
			{
			case 1:
				ac.Animal1Ability();
				break;
				
			case 2:
				ac.Animal2Ability();
				break;
				
			case 3:
				ac.Animal3Ability();
				break;
				
			case 4:
				ac.Animal4Ability();
				break;
			}
		}
	}

	public void SwitchShape(int newShape)
	{
		if (!reverseGravity) 
		{
			this.GetComponent<Rigidbody2D>().gravityScale = 1f;
		} 
		else 
		{
			this.GetComponent<Rigidbody2D>().gravityScale = -1f;
		}

		this.GetComponent<Rigidbody2D>().mass = 1f;


		//this.invulnerable = false;
		this.GetComponent<Rigidbody2D>().isKinematic = false;
		this.GetComponent<Collider2D>().enabled = false;  //This shiet is necessary or play will get stock in environments not dying
		this.GetComponent<Collider2D>().enabled = true;

		if (!isDead)
		{
			previousShape = shape;
			shape = newShape;
			switch (shape)
			{
			case 1:
				ac.Animal1Shape();
				break;
				
			case 2:
				ac.Animal2Shape();
				break;
				
			case 3:
				ac.Animal3Shape();
				break;	
				
			case 4:
				ac.Animal4Shape();
				break;		
			}
		}
	}	

	public void StaminaDecrement()
	{
		stamina = stamina + Time.deltaTime * 5;
		if (stamina >= 100 && isDead == false)
		{
			Die();
		}
	}
	
	public void Die()
	{
		if (!invulnerable && !this.isDead)
		{ 
			this.GetComponent<Rigidbody2D>().isKinematic = true;
			isDead = true;
			speed = 0f;
			anim.SetBool("isDead", true);
			cam.speed = 0f;
			StartCoroutine(PlayDead());
		}
	}

	IEnumerator PlayDead()
	{
		float timer = 0f;
		while (timer < 3f)
		{
			timer += Time.deltaTime;
			yield return null;
		}
		lives--;
		PlayerPrefs.SetInt("lives", lives);
		string lname = Application.loadedLevelName;

		if (lives <= 0)
		{
			Application.LoadLevel("LevelOne");
		}
		else 
		{
			Application.LoadLevel(lname);
		}
	}




}
	



