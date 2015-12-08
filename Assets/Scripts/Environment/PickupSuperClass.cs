using UnityEngine;
using System.Collections;

abstract public class PickupSuperClass : MonoBehaviour {

	public bool taken = false;
	public PlayerController player;

	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player" && player.anim.GetInteger("shape") != 9)
		{
			this.GetComponent<Renderer>().enabled = false;
			this.GetComponent<Collider2D>().enabled = false;
			
			this.Effect();
			//StartCoroutine(MakeHaste());
		}
	}

	public abstract void Effect();

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Stickman").GetComponent<PlayerController>();
	}
}
