using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class AcidController : MonoBehaviour
    {

        private PlayerController player;

        void OnTriggerStay2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Player" && !player.invulnerable)
            {
                player.StartCoroutine(player.Die2());
            }

        }

        void Start()
        {
            player = GameObject.Find("Stickman").GetComponent<PlayerController>();
        }

    }
}