using UnityEngine;
using System.Collections;

namespace Morphie
{
    public class PigDetectorCollision : MonoBehaviour
    {
<<<<<<< HEAD
=======

>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.name == "LeftSide")
            {
                RockController rock = coll.GetComponent<RockController>();
                if (!rock.moving)
                {
                    StartCoroutine(rock.MoveRock());
                }
            }
        }
    }
}