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
            
            //PositionCamera(); //SKAL REWORKES
        }

        public void InitializeCameraController()
        {
            player = HelperFunctions.player;
            cam = GetComponent<Camera>();
            speed = player.speed;
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        public void PositionCamera()
        {
            Vector3 newPosition = transform.position;
            float insertion = 4f; //4f
            float newX = player.playerTransform.position.x + insertion;
            newX = player.playerCollider.bounds.max.x + insertion;
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