using UnityEngine;

namespace Morphie
{

    abstract public class PickupSuperClass : MonoBehaviour
    {

        public bool taken = false;
        public static GameObject pickupGameObject;
        public static BoxCollider2D pickupBoxCollider;
        public static Renderer pickupRenderer;
        public static Rigidbody2D pickupRigidBody;


        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Player" && PlayerController.anim.GetInteger("shape") != 9)
            {
                pickupRenderer.enabled = false;
                pickupBoxCollider.enabled = false;
                Effect();
            }
        }

        public abstract void Effect();

        // Use this for initialization

        void Awake()
        {
            pickupGameObject = gameObject;
            pickupBoxCollider = pickupGameObject.GetComponent<BoxCollider2D>();
            pickupRenderer = pickupGameObject.GetComponent<Renderer>();
            pickupRigidBody = pickupGameObject.GetComponent<Rigidbody2D>();
        }

    }
}