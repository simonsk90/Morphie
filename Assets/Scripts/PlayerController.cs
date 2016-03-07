using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Morphie
{

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
        //public AnimalContainer ac;
        public bool invulnerable = false;
        public bool reverseGravity = false;
        public bool abilitiesLocked = false;
        public HelperFunctions helperFunctions;
        public ObjectsController objectsController;
        private Action updateFunction;
        private Action abilityFunction;
        public GameObject playerGameObject;
        public BoxCollider2D playerCollider;
        public Rigidbody2D playerRigidBody;
        public Renderer playerRenderer;

        void Awake()
        {
            
            playerGameObject = gameObject;
            playerCollider = playerGameObject.GetComponent<BoxCollider2D>();
            playerRigidBody = playerGameObject.GetComponent<Rigidbody2D>();
            playerRenderer = playerGameObject.GetComponent<Renderer>();

            
            anim = GetComponent<Animator>();
            cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
            helperFunctions = GameObject.Find("Factory").GetComponent<HelperFunctions>();
            objectsController = GameObject.Find("Factory").GetComponent<ObjectsController>();
            AnimalContainer.InitializeAnimals();
            updateFunction = () => AnimalContainer.Animal1Update();
            abilityFunction = () => AnimalContainer.Animal1Ability();

            //ac = gameObject.AddComponent<AnimalContainer>();
        }

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

            transform.position = checkpoint;
            cam.PositionCamera();
        }

        void Update()
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

            transform.Translate(Vector2.right * speed * Time.deltaTime); //Moving to the right
            StaminaDecrement();

        }

        public void UseAbility()
        {
            if (!this.isDead && !abilitiesLocked)
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



