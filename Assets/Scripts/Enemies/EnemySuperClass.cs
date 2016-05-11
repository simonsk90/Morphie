using UnityEngine;

namespace Morphie
{

    public class EnemySuperclass : MonoBehaviour
    {

        public PlayerController player;
<<<<<<< HEAD
        public CowFunctions cf;
        public float speed;
        private Vector2 screenPos;
        private bool activated = false;

        //void Awake()
        //{
        //    player = HelperFunctions.player;
        //    cf = player.GetComponent<CowFunctions>();
        //}

        //void Awake()
        //{
        //    Debug.Log("Hello");
        //}

        void Start()
        {
            player = HelperFunctions.player;
            cf = player.GetComponent<CowFunctions>();
        }

        public void MoveLeftIfActive()
        {
            if (!activated)
            {
                screenPos = Camera.main.WorldToScreenPoint(transform.position);
                if (HelperFunctions.UnitWithinScreenSpace(screenPos))
                {
                    transform.Translate(Vector2.right * -speed * Time.deltaTime);
                    activated = true;
                }
            }
            else
            {
                transform.Translate(Vector2.right * -speed * Time.deltaTime);
            }
        }
=======
        public float speed;
        private Vector2 screenPos;
        private bool activated = false;
        public static GameObject enemyGameObject;
        public static BoxCollider2D enemyBoxCollider;
        public static Rigidbody2D enemyRigidBody;
        public static Transform enemyTransform;

        void Awake()
        {
            enemyGameObject = gameObject;
            enemyBoxCollider = enemyGameObject.GetComponent<BoxCollider2D>();
            enemyRigidBody = enemyGameObject.GetComponent<Rigidbody2D>();
            enemyTransform = transform;
        }

        public void MoveLeftIfActive()
        {
            if (!activated)
            {
                screenPos = Camera.main.WorldToScreenPoint(enemyTransform.position);
                if (HelperFunctions.UnitWithinScreenSpace(screenPos))
                {
                    enemyTransform.Translate(Vector2.right * -speed * Time.deltaTime);
                    activated = true;
                }
            }
            else
            {
                enemyTransform.Translate(Vector2.right * -speed * Time.deltaTime);
            }
        }
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
    }
}