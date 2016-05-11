using UnityEngine;

namespace Morphie
{

    abstract public class PickupSuperClass : MonoBehaviour
    {

        public bool taken = false;
<<<<<<< HEAD
        public PlayerController player;

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Player" && player.anim.GetInteger("shape") != 9)
            {
                GetComponent<Renderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;

=======
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
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
                Effect();
            }
        }

        public abstract void Effect();

<<<<<<< HEAD
        void Start()
        {
            player = HelperFunctions.player;
=======
        // Use this for initialization

        void Awake()
        {
            pickupGameObject = gameObject;
            pickupBoxCollider = pickupGameObject.GetComponent<BoxCollider2D>();
            pickupRenderer = pickupGameObject.GetComponent<Renderer>();
            pickupRigidBody = pickupGameObject.GetComponent<Rigidbody2D>();
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        }

    }
}