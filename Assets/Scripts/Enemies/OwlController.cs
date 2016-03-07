using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class OwlController : EnemySuperclass
    {

        private CowFunctions cf;

        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "Player")
            {
                if (player.GetComponent<Rigidbody2D>().isKinematic == true)
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

        // Use this for initialization
        void Start()
        {
            cf = GameObject.Find("Stickman").GetComponent<CowFunctions>();
            speed = 2f;
        }

        // Update is called once per frame
        void Update()
        {
            MoveLeftIfActive();
        }
    }
}