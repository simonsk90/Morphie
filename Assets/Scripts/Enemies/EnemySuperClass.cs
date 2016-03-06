using UnityEngine;

namespace Morphie
{

    public class EnemySuperclass : MonoBehaviour
    {

        public PlayerController player;
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
    }
}