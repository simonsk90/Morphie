using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class GroundController : MonoBehaviour
    {
        void OnTriggerStay2D(Collider2D coll)
        {
            if (coll.tag == "Player" && !PlayerController.invulnerable)
            {
                StartCoroutine(PlayerController.Die2());
            }
        }
    }
}