using UnityEngine;
using System.Collections;

namespace Morphie
{

<<<<<<< HEAD
    public class GroundController : MonoBehaviour
    {

        PlayerController player;

        void OnTriggerStay2D(Collider2D coll)
        {
            if (coll.tag == "Player" && !player.invulnerable)
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
=======
<<<<<<< HEAD
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
=======
    PlayerController player;

	void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.tag == "Player" && !player.invulnerable)
		{
			player.Die();
		}
	}
	
	void Start () {
	    player = GameObject.Find("Stickman").GetComponent<PlayerController>();
	}
	
}
>>>>>>> parent of 91ce9bc... Added new Die() function
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
