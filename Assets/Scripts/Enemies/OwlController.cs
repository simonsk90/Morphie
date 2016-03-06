using UnityEngine;
using System.Collections;
namespace Morphie
{

    public class OwlController : EnemySuperclass
    {
        private CowFunctions cf;

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

        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "Player")
            {
<<<<<<< HEAD
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
=======
                player.Die();
                speed = 0f;
>>>>>>> parent of 91ce9bc... Added new Die() function
            }
        }


    }
}
