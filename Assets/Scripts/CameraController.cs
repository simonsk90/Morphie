using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class CameraController : MonoBehaviour
    {

<<<<<<< HEAD
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
=======
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

>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

<<<<<<< HEAD
        public void PositionCamera()
        {
            Vector3 newPosition = transform.position;
            float insertion = 4f; //4f
            float newX = player.playerTransform.position.x + insertion;
            newX = player.playerCollider.bounds.max.x + insertion;
            newPosition.x = newX;
            transform.position = newPosition;
=======
        public static void PositionCamera()
        {
            Vector3 newPosition = cameraTransform.position;
            float insertion = 4f; //4f
            float newX = PlayerController.playerTransform.position.x + insertion;
            newX = PlayerController.playerBoxCollider.bounds.max.x + insertion;
            newPosition.x = newX;
            cameraTransform.position = newPosition;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        }

        private void Move()
        {
            if (!reverse)
            {
<<<<<<< HEAD
                transform.Translate(Vector2.right * player.speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.right * player.speed * Time.deltaTime);
=======
                cameraTransform.Translate(Vector2.right * PlayerController.speed * Time.deltaTime);
            }
            else
            {
                cameraTransform.Translate(-Vector2.right * PlayerController.speed * Time.deltaTime);
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            }
        }

    }
}