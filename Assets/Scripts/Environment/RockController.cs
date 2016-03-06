using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class RockController : MonoBehaviour
    {

        public bool dropped = false;
        private float originalY;
        public Vector2 newPos;
        public float speed;
        public bool moving = false;
        Transform rockTransform;


        void OnTriggerStay2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Player" && !PlayerController.invulnerable && !moving)
            {
                StartCoroutine(PlayerController.Die2());
            }
        }

        void Awake()
        {
            rockTransform = transform;
        }

        // Use this for initialization
        void Start()
        {
            originalY = this.transform.parent.position.y;
            newPos = this.transform.parent.position;
            newPos.x++;
        }

        void Update()
        {

        }

        public IEnumerator MoveRock()
        {
            speed = PlayerController.speed * 3f;
            moving = true;

            while (rockTransform.parent.position.x < newPos.x) //0.5
            {
                if (dropped == false)
                {
                    rockTransform.parent.position = Vector2.MoveTowards(rockTransform.parent.position, newPos, speed * Time.deltaTime);
                }

                if (rockTransform.parent.position.y < originalY - 0.1f)
                {
                    dropped = true;
                }
                yield return null;
            }

            if (!HelperFunctions.CheckOnGround(rockTransform.parent.gameObject))
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
            float newY = rockTransform.parent.position.y - 1f;
            Vector2 newPosY = rockTransform.parent.position;
            newPosY.y = newY;
            speed = PlayerController.speed * 3f;

            while (!dropped)
            {
                rockTransform.parent.position = Vector2.MoveTowards(rockTransform.parent.position, newPosY, speed * Time.deltaTime);

                if (rockTransform.parent.position.y == newY)
                {
                    if (HelperFunctions.CheckOnGround(rockTransform.parent.gameObject))
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