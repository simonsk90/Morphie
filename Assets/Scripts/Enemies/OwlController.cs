using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class OwlController : EnemySuperclass
    {

        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "Player")
            {
                if (player.playerRigidBody.isKinematic == true)
                {
                    GetComponent<Rigidbody2D>().isKinematic = true;
                }

                if (cf != null && cf.hitting)
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

        // Use this for initialization
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