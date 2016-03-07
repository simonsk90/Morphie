using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class CameraController : MonoBehaviour
    {

        private PlayerController player;
        public float speed;
        public bool reverse = false;
        public Camera cam;

        void Awake()
        {
            cam = GetComponent<Camera>();
            player = GameObject.Find("Stickman").GetComponent<PlayerController>();
            speed = player.speed;
            //PositionCamera(); //SKAL REWORKES
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        public void PositionCamera()
        {
            Vector3 newPosition = this.transform.position;
            float insertion = 4f; //4f
            float newX = player.transform.position.x + insertion;
            newX = player.GetComponent<Collider2D>().bounds.max.x + insertion;
            newPosition.x = newX;
            transform.position = newPosition;
        }

        private void Move()
        {
            if (!reverse)
            {
                transform.Translate(Vector2.right * player.speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.right * player.speed * Time.deltaTime);
            }
        }

    }
}