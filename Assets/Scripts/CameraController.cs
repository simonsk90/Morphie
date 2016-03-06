using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class CameraController : MonoBehaviour
    {

        public static float speed;
        public bool reverse = false;
        public static Camera cam;
        private static Transform cameraTransform;

        void Awake()
        {
            cam = GetComponent<Camera>();
            speed = PlayerController.speed;
            cameraTransform = transform;
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

        public static void PositionCamera()
        {
            Vector3 newPosition = cameraTransform.position;
            float insertion = 4f; //4f
            float newX = PlayerController.playerTransform.position.x + insertion;
            newX = PlayerController.playerBoxCollider.bounds.max.x + insertion;
            newPosition.x = newX;
            cameraTransform.position = newPosition;
        }

        private void Move()
        {
            if (!reverse)
            {
                cameraTransform.Translate(Vector2.right * PlayerController.speed * Time.deltaTime);
            }
            else
            {
                cameraTransform.Translate(-Vector2.right * PlayerController.speed * Time.deltaTime);
            }
        }

    }
}