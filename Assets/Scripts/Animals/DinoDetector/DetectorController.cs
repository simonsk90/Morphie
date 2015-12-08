using UnityEngine;
using System.Collections;

public class DetectorController : MonoBehaviour {

	private PlayerController player;

	void OnTriggerStay2D(Collider2D coll)
	{
		player.helperFunctions.MakeDisappear(coll.gameObject);
	}

	void Awake ()
	{
		player = GameObject.Find("Stickman").GetComponent<PlayerController>();
	}
}
