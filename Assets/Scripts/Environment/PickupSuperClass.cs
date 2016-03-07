using UnityEngine;

namespace Morphie
{

    abstract public class PickupSuperClass : MonoBehaviour
    {

        public bool taken = false;
        public PlayerController player;

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Player" && player.anim.GetInteger("shape") != 9)
            {
                GetComponent<Renderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;

                Effect();
            }
        }

        public abstract void Effect();

        // Use this for initialization

        void Awake()
        {
            player = HelperFunctions.player;
        }

    }
}