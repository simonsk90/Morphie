using UnityEngine;
using System.Collections;

namespace Morphie
{
    public class PigDetectorCollision : MonoBehaviour
    {
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