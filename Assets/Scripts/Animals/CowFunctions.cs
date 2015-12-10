using UnityEngine;
using System.Collections;

public class CowFunctions : MonoBehaviour, IAnimalFunctions {

	private PlayerController player;
	public bool hitting = false;
	private BoxCollider2D pb; //playerBox
	public bool cooldown = false;

	void Awake()
	{
		player = GameObject.Find("Stickman").GetComponent<PlayerController>();
	}

	void Start () {

	}
	
	public void ChangeShape()
	{
		Vector2 newSize = new Vector2(1.08f, 0.65f);
		player.helperFunctions.CorrectShapePosition(3, newSize);
	}

	public void LeaveShape()
	{
		
	}
	
	public void UpdateFunctions()
	{
		
	}
	
	public void Ability()
	{
		if (!cooldown)
		{
			StartCoroutine( Hit() );
		}
	}

	IEnumerator Hit()
	{
		float timer = 0f;
		player.anim.SetBool("isHitting", true);
		StartCoroutine(player.helperFunctions.Cooldown(3f, x => this.cooldown = x));

		while (timer < 1f && player.anim.GetInteger("shape") == 3) //Look if we're in cow shape
		{
			this.hitting = true;
			timer += Time.deltaTime;
			yield return null;
		}
		this.hitting = false;
		player.anim.SetBool("isHitting", false);
		//ADD Cooldown maybe?
	}

}
