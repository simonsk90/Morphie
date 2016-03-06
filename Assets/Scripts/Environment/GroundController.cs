using UnityEngine;
using System.Collections;

namespace Morphie
{

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
