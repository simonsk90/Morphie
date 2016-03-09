using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class AcidController : MonoBehaviour
    {
        private PlayerController player;

        void OnTriggerEnter2D(Collider2D coll)
        {
            Debug.Log("Acid");

            if (coll.gameObject.tag == "Player" && !player.invulnerable)
            {
                player.StartCoroutine(player.Die2());
            }

        }

        void Start()
        {
            player = HelperFunctions.player;
        }
    }
}