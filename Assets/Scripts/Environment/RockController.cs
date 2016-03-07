using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class RockController : MonoBehaviour
    {

        private PlayerController player;
        public bool dropped = false;
        private float originalY;
        public Vector2 newPos;
        public float speed;
        public bool moving = false;


        void OnTriggerStay2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Player" && !player.invulnerable && !moving)
            {
                player.StartCoroutine(player.Die2());
            }
        }

        void Awake()
        {
            originalY = transform.parent.position.y;
            newPos = transform.parent.position;
            newPos.x++;
            player = HelperFunctions.player;
        }

        // Use this for initialization
        void Start()
        {
            //this.originalY = this.transform.parent.position.y;
            //this.newPos = this.transform.parent.position;
            //this.newPos.x++;
            //player = GameObject.Find("Stickman").GetComponent<PlayerController>();
        }

        void Update()
        {

        }

        public IEnumerator MoveRock()
        {
            speed = player.speed * 3f;
            moving = true;

            while (transform.parent.position.x < newPos.x) //0.5
            {
                if (dropped == false)
                {
                    transform.parent.position = Vector2.MoveTowards(transform.parent.position, newPos, speed * Time.deltaTime);
                }

                if (transform.parent.position.y < originalY - 0.1f)
                {
                    dropped = true;
                }
                yield return null;
            }

            if (!HelperFunctions.CheckOnGround(gameObject.transform.parent.gameObject))
            {
                StartCoroutine(ApplyGravity());
            }
            else
            {
                moving = false;
            }

            newPos.x++;
        }

        IEnumerator ApplyGravity()
        {
            float newY = transform.parent.position.y - 1f;
            Vector2 newPosY = transform.parent.position;
            newPosY.y = newY;
            speed = player.speed * 3f;

            while (!dropped)
            {
                transform.parent.position = Vector2.MoveTowards(transform.parent.position, newPosY, speed * Time.deltaTime);

                if (transform.parent.position.y == newY)
                {
                    if (HelperFunctions.CheckOnGround(transform.parent.gameObject))
                    {
                        dropped = true;
                        GetComponent<Collider2D>().isTrigger = false;
                    }
                    else
                    {
                        newY--;
                        newPosY.y = newY;
                    }
                }
                yield return null;
            }
            moving = false;
        }
    }
}