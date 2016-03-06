using UnityEngine;
using System.Collections;
using Morphie;

namespace Morphie {

    public class BotTopController : MonoBehaviour {

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.tag != "Ground" && coll.tag != "Rock")
            {
                //player.helperFunctions.MakeDisappear(coll.gameObject);
                HelperFunctions.MakeDisappear(coll.gameObject);
            }
        }
    }
}