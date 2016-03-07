using UnityEngine;

namespace Morphie
{

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