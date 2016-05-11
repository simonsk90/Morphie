using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Morphie
<<<<<<< HEAD
{

    public class PlayerController : MonoBehaviour
    {
        public bool isDead = false;
        public float speed = 3f; //2
        public float stamina = 0;
        public int lives = 3; //Maybe remove and only use PlayerPrefs(lives)
        public Animator anim;
        public int shape = 1;
        public int previousShape;
        private Vector2 checkpoint;
        public CameraController cam;
        public bool invulnerable = false;
        public bool reverseGravity = false;
        public bool abilitiesLocked = false;
        private Action updateFunction;
        private Action abilityFunction;
        public GameObject playerGameObject;
        public BoxCollider2D playerCollider;
        public Rigidbody2D playerRigidBody;
        public Renderer playerRenderer;
        public Transform playerTransform;

        void Awake()
        {
            playerGameObject = gameObject;
            playerCollider = playerGameObject.GetComponent<BoxCollider2D>();
            playerRigidBody = playerGameObject.GetComponent<Rigidbody2D>();
            playerRenderer = playerGameObject.GetComponent<Renderer>();
            playerTransform = playerGameObject.transform;

            HelperFunctions.InitializeHelperFunctions();
            anim = playerGameObject.GetComponent<Animator>();
            cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
            cam.InitializeCameraController();
            ObjectsController.InitializeObjectsController();
            AnimalContainer.InitializeAnimals();
=======
{ 

    public class PlayerController : MonoBehaviour 
    {
	    public static bool isDead = false;
	    public static float speed = 2f; //2
        public static float stamina;
        
        public static int lives = 3; //Maybe remove and only use PlayerPrefs(lives)
	    public static Animator anim;
	    public static int shape = 1;
	    public static int previousShape;
	    private Vector2 checkpoint;
	    //private int level;
	    //public AnimalContainer ac;
        public static bool invulnerable = false;
	    public static bool reverseGravity = false;
	    public static bool abilitiesLocked = false;
	    //public HelperFunctions helperFunctions;
	    //public ObjectsController objectsController;
        private static Action updateFunction;
        private static Action abilityFunction;
        public static Transform playerTransform;
        public static GameObject playerGameObject;
        public static Rigidbody2D playerRigidBody;
        public static BoxCollider2D playerBoxCollider;
        public static Renderer playerRenderer;

        void Awake ()
	    {
            //stamina = 0;
            reverseGravity = false;
            playerTransform = transform;
            playerGameObject = gameObject;
            playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
            playerBoxCollider = gameObject.GetComponent<BoxCollider2D>();
            playerRenderer = gameObject.GetComponent<Renderer>();

            AnimalContainer.InitializeAnimals();
            //ac = gameObject.AddComponent<AnimalContainer>();
		    anim = playerGameObject.GetComponent<Animator>();
		    //helperFunctions = GameObject.Find("Factory").GetComponent<HelperFunctions>();
		    //objectsController = GameObject.Find("Factory").GetComponent<ObjectsController>();
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            updateFunction = () => AnimalContainer.Animal1Update();
            abilityFunction = () => AnimalContainer.Animal1Ability();
        }

<<<<<<< HEAD
        void Start()
        {
            AnimalContainer.Animal1Shape();

            lives = PlayerPrefs.GetInt("lives");

            if (lives <= 0)
            {
                PlayerPrefs.SetFloat("checkpointX", 0);
                PlayerPrefs.SetFloat("checkpointY", 0);
                lives = 3;
            }

            checkpoint.x = PlayerPrefs.GetFloat("checkpointX");
            checkpoint.y = PlayerPrefs.GetFloat("checkpointY");

            playerTransform.position = checkpoint;
            cam.PositionCamera();
        }

        void Update()
        {
            //Apply animals UpdateFunctions
            updateFunction();
            playerTransform.Translate(Vector2.right * speed * Time.deltaTime); //Moving to the right
            StaminaDecrement();
        }

        public void UseAbility()
        {
            if (!isDead && !abilitiesLocked)
            {
                //switch (shape)
                //{
                //case 1:
                //	ac.Animal1Ability();
                //	break;

                //case 2:
                //	ac.Animal2Ability();
                //	break;

                //case 3:
                //	ac.Animal3Ability();
                //	break;

                //case 4:
                //	ac.Animal4Ability();
                //	break;
                //}
                abilityFunction();
            }
        }

        public void SwitchShape(int newShape)
        {
            if (!reverseGravity)
            {
                GetComponent<Rigidbody2D>().gravityScale = 1f;
            }
            else
            {
                GetComponent<Rigidbody2D>().gravityScale = -1f;
            }

            GetComponent<Rigidbody2D>().mass = 1f;


            //this.invulnerable = false;
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Collider2D>().enabled = false;  //This shiet is necessary or player will get stock in environments not dying
            GetComponent<Collider2D>().enabled = true;

            if (!isDead)
            {
                previousShape = shape;
                shape = newShape;
                switch (shape)
                {
                    case 1:
                        AnimalContainer.Animal1Shape();
                        updateFunction = () => AnimalContainer.Animal1Update();
                        abilityFunction = () => AnimalContainer.Animal1Ability();
                        break;

                    case 2:
                        AnimalContainer.Animal2Shape();
                        updateFunction = () => AnimalContainer.Animal2Update();
                        abilityFunction = () => AnimalContainer.Animal2Ability();
                        break;

                    case 3:
                        AnimalContainer.Animal3Shape();
                        updateFunction = () => AnimalContainer.Animal3Update();
                        abilityFunction = () => AnimalContainer.Animal3Ability();
                        break;

                    case 4:
                        AnimalContainer.Animal4Shape();
                        updateFunction = () => AnimalContainer.Animal4Update();
                        abilityFunction = () => AnimalContainer.Animal4Ability();
                        break;
                }
            }
        }

        public void StaminaDecrement()
        {
            stamina += Time.deltaTime * 5;
            if (stamina >= 100 && isDead == false)
            {
                StartCoroutine(Die2());
            }
        }

        //public void Die()
        //{
        //	if (!invulnerable && !this.isDead)
        //	{ 
        //		this.GetComponent<Rigidbody2D>().isKinematic = true;
        //		isDead = true;
        //		speed = 0f;
        //		anim.SetBool("isDead", true);
        //		cam.speed = 0f;
        //		StartCoroutine(PlayDead());
        //       }
        //}

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

            if (lives <= 0)
            {
                SceneManager.LoadScene("LevelOne");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        public IEnumerator Die2()
        {
            if (!invulnerable && !this.isDead)
            {
                float timer = 0f;
                string lname = SceneManager.GetActiveScene().name;

                GetComponent<Rigidbody2D>().isKinematic = true;
                isDead = true;
                speed = 0f;
                anim.SetBool("isDead", true);
                cam.speed = 0f;

                while (timer < 3f)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }
                lives--;
                PlayerPrefs.SetInt("lives", lives);

                if (lives <= 0)
                {
                    SceneManager.LoadScene("LevelOne");
                }
                else
                {
                    SceneManager.LoadScene(lname);
                }
            }
        }
    }
}	

=======
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

            playerTransform.position = checkpoint;
		    CameraController.PositionCamera();
            AnimalContainer.Animal1Shape();
	    }

	    void Update () 
	    {
		    //Apply animals UpdateFunctions
            //UNDGÅ AT GÅ IGENNEM EN SWITCH HER HVIS MULIGT

		    //switch (shape)
		    //{
		    //case 1:
		    //	ac.Animal1Update();
		    //	break;
			
		    //case 2:	
		    //	ac.Animal2Update();
		    //	break;
			
		    //case 3:
		    //	ac.Animal3Update();
		    //	break;
			
		    //case 4:
		    //	ac.Animal4Update();
		    //	break;
		    //}

            updateFunction();

            playerTransform.Translate(Vector2.right * speed * Time.deltaTime); //Moving to the right
            StaminaDecrement();

	    }

	    public static void UseAbility()
	    {
		    if (!isDead && !abilitiesLocked)
		    {
			    //switch (shape)
			    //{
			    //case 1:
			    //	ac.Animal1Ability();
			    //	break;
				
			    //case 2:
			    //	ac.Animal2Ability();
			    //	break;
				
			    //case 3:
			    //	ac.Animal3Ability();
			    //	break;
				
<<<<<<< HEAD
			    //case 4:
			    //	ac.Animal4Ability();
			    //	break;
			    //}
                abilityFunction();
		    }
	    }

	    public static void SwitchShape(int newShape)
	    {
		    if (!reverseGravity) 
		    {
			    playerRigidBody.gravityScale = 1f;
		    } 
		    else 
		    {
                playerRigidBody.gravityScale = -1f;
		    }

            playerRigidBody.mass = 1f;


            //this.invulnerable = false;
            playerRigidBody.isKinematic = false;
		    playerBoxCollider.enabled = false;  //This shiet is necessary or player will get stock in environments not dying
            playerBoxCollider.enabled = true;

		    if (!isDead)
		    {
			    previousShape = shape;
			    shape = newShape;
			    switch (shape)
			    {
			    case 1:
				    AnimalContainer.Animal1Shape();
                    updateFunction = () => AnimalContainer.Animal1Update();
                    abilityFunction = () => AnimalContainer.Animal1Ability();
				    break;
=======
			//case 4:
			//	ac.Animal4Ability();
			//	break;
			//}
            abilityFunction();
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
                updateFunction = () => ac.Animal1Update();
                abilityFunction = () => ac.Animal1Ability();
				break;
>>>>>>> parent of 91ce9bc... Added new Die() function
				
			    case 2:
                    AnimalContainer.Animal2Shape();
                    updateFunction = () => AnimalContainer.Animal2Update();
                    abilityFunction = () => AnimalContainer.Animal2Ability();
                    break;
				
			    case 3:
                    AnimalContainer.Animal3Shape();
                    updateFunction = () => AnimalContainer.Animal3Update();
                    abilityFunction = () => AnimalContainer.Animal3Ability();
                    break;	
				
<<<<<<< HEAD
			    case 4:
                    AnimalContainer.Animal4Shape();
                    updateFunction = () => AnimalContainer.Animal4Update();
                    abilityFunction = () => AnimalContainer.Animal4Ability();
                    break;		
			    }
		    }
	    }	

	    public void StaminaDecrement()
	    {
		    stamina = stamina + Time.deltaTime * 5;
		    if (stamina >= 100 && isDead == false)
		    {
                StartCoroutine(Die2());
            }
	    }
	
	    //public void Die()
	    //{
	    //	if (!invulnerable && !this.isDead)
	    //	{ 
	    //		this.GetComponent<Rigidbody2D>().isKinematic = true;
	    //		isDead = true;
	    //		speed = 0f;
	    //		anim.SetBool("isDead", true);
	    //		cam.speed = 0f;
	    //		StartCoroutine(PlayDead());
     //       }
	    //}

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
            string lname = SceneManager.GetActiveScene().name;

            if (lives <= 0)
            {
                SceneManager.LoadScene("LevelOne");
            }
            else
            {
                SceneManager.LoadScene(lname);
            }
        }
=======
			case 4:
				ac.Animal4Shape();
                updateFunction = () => ac.Animal4Update();
                abilityFunction = () => ac.Animal4Ability();
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
		string lname = SceneManager.GetActiveScene().name;

		if (lives <= 0)
		{
			SceneManager.LoadScene("LevelOne");
		}
		else 
		{
			SceneManager.LoadScene(lname);
		}
	}

>>>>>>> parent of 91ce9bc... Added new Die() function

        public static IEnumerator Die2()
        {
            if (!invulnerable && !isDead)
            {
                float timer = 0f;
                string lname = SceneManager.GetActiveScene().name;

                playerRigidBody.isKinematic = true;
                isDead = true;
                speed = 0f;
                anim.SetBool("isDead", true);
                CameraController.speed = 0f;
            
                while (timer < 3f)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }
                lives--;
                
                PlayerPrefs.SetInt("lives", lives);

                if (lives <= 0)
                {
                    SceneManager.LoadScene("LevelOne");
                }
                else
                {
                    SceneManager.LoadScene(lname);
                }
            }
        }
    }
}
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67


