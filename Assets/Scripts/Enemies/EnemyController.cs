﻿using UnityEngine;

<<<<<<< HEAD
namespace Morphie
{
=======
<<<<<<< HEAD
namespace Morphie
{

    public class EnemyController : EnemySuperclass
    {

        private CowFunctions cf;

        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "Player")
            {
                if (PlayerController.playerRigidBody.isKinematic == true)
                {
                    enemyRigidBody.isKinematic = true;
                }

                if (PlayerController.anim.GetInteger("shape") == 9)
                {
                    enemyGameObject.SetActive(false);
                }
                else if (cf != null && cf.hitting)
                {
                    enemyGameObject.SetActive(false);
                }
                else
                {
                    StartCoroutine(PlayerController.Die2());
                    speed = 0f;
                }
            }
        }


        // Use this for initialization
        void Start()
        {
            if (PlayerController.playerGameObject.GetComponent<CowFunctions>() != null)
            {
                cf = PlayerController.playerGameObject.GetComponent<CowFunctions>();
            }

            speed = 2f;
        }

        // Update is called once per frame
        void Update()
        {
            MoveLeftIfActive();
        }
=======
public class EnemyController : EnemySuperclass {
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67

    public class EnemyController : EnemySuperclass
    {
        
        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "Player")
            {

                if (player.playerRigidBody.isKinematic == true)
                {
                    GetComponent<Rigidbody2D>().isKinematic = true;
                }

<<<<<<< HEAD
                if (cf != null && cf.hitting)
                {
                    gameObject.SetActive(false);
                }

                else if(!player.invulnerable) //DIE
                {
                    player.StartCoroutine(player.Die2());
                    speed = 0f;
                }
            }
        }

        void OnEnable()
        {
            speed = 2f;
        }

        // Update is called once per frame
        void Update()
        {
            MoveLeftIfActive();
        }
    }
}
=======
			if (player.anim.GetInteger("shape") == 9)
			{
                gameObject.SetActive(false);
			}
			else if (cf != null && cf.hitting)
			{
                gameObject.SetActive(false);
			}
			else
			{
				player.Die();
                speed = 0f;
			}
		}		
	}
	

	// Use this for initialization
	void Start () {
		cf = GameObject.Find("Stickman").GetComponent<CowFunctions>();
        speed = 2f;
>>>>>>> parent of 91ce9bc... Added new Die() function
    }
}
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
