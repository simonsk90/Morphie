using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class RockController : MonoBehaviour
    {

<<<<<<< HEAD
        private PlayerController player;
=======
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        public bool dropped = false;
        private float originalY;
        public Vector2 newPos;
        public float speed;
        public bool moving = false;
<<<<<<< HEAD
=======
        Transform rockTransform;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67


        void OnTriggerStay2D(Collider2D coll)
        {
<<<<<<< HEAD
            if (coll.gameObject.tag == "Player" && !player.invulnerable && !moving)
            {
                player.StartCoroutine(player.Die2());
=======
            if (coll.gameObject.tag == "Player" && !PlayerController.invulnerable && !moving)
            {
                StartCoroutine(PlayerController.Die2());
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            }
        }

        void Awake()
        {
<<<<<<< HEAD
            originalY = transform.parent.position.y;
            newPos = transform.parent.position;
            newPos.x++;
            
=======
<<<<<<< HEAD
            rockTransform = transform;
=======
            player.Die();
>>>>>>> parent of 91ce9bc... Added new Die() function
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        }

        // Use this for initialization
        void Start()
        {
<<<<<<< HEAD
            player = HelperFunctions.player;
            //this.originalY = this.transform.parent.position.y;
            //this.newPos = this.transform.parent.position;
            //this.newPos.x++;
            //player = GameObject.Find("Stickman").GetComponent<PlayerController>();
=======
            originalY = this.transform.parent.position.y;
            newPos = this.transform.parent.position;
            newPos.x++;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        }

        void Update()
        {

        }

        public IEnumerator MoveRock()
        {
<<<<<<< HEAD
            speed = player.speed * 3f;
            moving = true;

            while (transform.parent.position.x < newPos.x) //0.5
            {
                if (dropped == false)
                {
                    transform.parent.position = Vector2.MoveTowards(transform.parent.position, newPos, speed * Time.deltaTime);
                }

                if (transform.parent.position.y < originalY - 0.1f)
=======
            speed = PlayerController.speed * 3f;
            moving = true;

            while (rockTransform.parent.position.x < newPos.x) //0.5
            {
                if (dropped == false)
                {
                    rockTransform.parent.position = Vector2.MoveTowards(rockTransform.parent.position, newPos, speed * Time.deltaTime);
                }

                if (rockTransform.parent.position.y < originalY - 0.1f)
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
                {
                    dropped = true;
                }
                yield return null;
            }

<<<<<<< HEAD
            if (!HelperFunctions.CheckOnGround(gameObject.transform.parent.gameObject))
=======
            if (!HelperFunctions.CheckOnGround(rockTransform.parent.gameObject))
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
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
<<<<<<< HEAD
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
=======
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
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
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
<<<<<<< HEAD
}
=======
}
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
