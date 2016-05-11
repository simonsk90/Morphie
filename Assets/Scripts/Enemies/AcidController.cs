using UnityEngine;
using System.Collections;

<<<<<<< HEAD
namespace Morphie
{
=======
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
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67

    public class AcidController : MonoBehaviour
    {
        private PlayerController player;

<<<<<<< HEAD
        void OnTriggerEnter2D(Collider2D coll)
        {
            Debug.Log("Acid");

            if (coll.gameObject.tag == "Player" && !player.invulnerable)
            {
                player.StartCoroutine(player.Die2());
            }
=======
	void OnTriggerStay2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player" && !player.invulnerable)
		{
			player.Die();
		}
		
	}
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67

        }

<<<<<<< HEAD
        void Start()
        {
            player = HelperFunctions.player;
        }
    }
}
=======
}
>>>>>>> parent of 91ce9bc... Added new Die() function
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
