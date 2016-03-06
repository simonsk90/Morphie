using UnityEngine;
using System.Collections;

namespace Morphie
{
    public class AcidController : MonoBehaviour
    {
        void OnTriggerStay2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Player" && !PlayerController.invulnerable)
            {
                StartCoroutine(PlayerController.Die2());
            }
        }
    }
}