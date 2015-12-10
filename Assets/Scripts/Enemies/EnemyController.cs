using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {


	private PlayerController player;
	private CowFunctions cf;
	private Vector2 screenPos;
	private bool activated = false;
	private Transform pickupPrefab;
	public float speed = 2f;

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Player")
		{
			if (player.GetComponent<Rigidbody2D>().isKinematic == true)
			{
				this.GetComponent<Rigidbody2D>().isKinematic = true;
			}

			if (player.anim.GetInteger("shape") == 9)
			{
				player.helperFunctions.MakeDisappear(this.gameObject);
			}
			else if (cf != null && cf.hitting)
			{
				player.helperFunctions.MakeDisappear(this.gameObject);
			}
			else
			{
                Debug.Log(cf);
				player.Die();
                Debug.Log("Dead by enemy");
			}
		}		
	}
	

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Stickman").GetComponent<PlayerController>();
		cf = GameObject.Find("Stickman").GetComponent<CowFunctions>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!activated)
		{
			screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
			if (UnitWithinScreenSpace(screenPos))
			{
				transform.Translate(Vector2.right * -speed * Time.deltaTime);
				activated = true;
			}
		}
		else
		{
			transform.Translate(Vector2.right * -speed * Time.deltaTime);
			if (player.isDead == true)
			{
				this.speed = 0f;
			}
		}

	}


	public bool UnitWithinScreenSpace(Vector2 unitScreenPos) {
		if (
			(unitScreenPos.x < Screen.width && unitScreenPos.y < Screen.height)	&&
			(unitScreenPos.x > 0f && unitScreenPos.y > 0f)) {		
			return true;
		}
		else {
			return false;
		}
	}


}
