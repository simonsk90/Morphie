using UnityEngine;
using System.Collections;

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
