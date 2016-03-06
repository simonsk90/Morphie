using UnityEngine;
using System.Collections;

<<<<<<< HEAD
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
=======
public class AcidController : MonoBehaviour {

	private PlayerController player;

	void OnTriggerStay2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player" && !player.invulnerable)
		{
			player.Die();
		}
		
	}

	void Start () {
		player = GameObject.Find("Stickman").GetComponent<PlayerController>();
	}

}
>>>>>>> parent of 91ce9bc... Added new Die() function
