using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class BotTopController : MonoBehaviour
    {

        private PlayerController player;

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.tag != "Ground" && coll.tag != "Rock")
            {
                player.helperFunctions.MakeDisappear(coll.gameObject);
            }
        }

        void Awake()
        {
            player = GameObject.Find("Stickman").GetComponent<PlayerController>();
        }
    }
}