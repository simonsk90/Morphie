using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {

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
