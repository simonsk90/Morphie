using UnityEngine;
using System.Collections;

public class CatFunctions : MonoBehaviour, IAnimalFunctions {

	private PlayerController player;
	
	void Awake()
	{
		player = GameObject.Find("Stickman").GetComponent<PlayerController>();
	}
	
	void Start () {
		
	}
	
	public void ChangeShape()
	{
		//rigidbody2D.mass = 10f;  NOT SURE IF THIS IS NEEDED OR NOT, KEEP IN MIND IF THINGS ACT STRANGE SUDDENLY
		Vector2 newSize = new Vector2(0.8f, 0.8f);
		player.helperFunctions.CorrectShapePosition(7, newSize);
	}

	public void LeaveShape()
	{
		
	}
	
	public void UpdateFunctions()
	{
		
	}
	
	public void Ability()
	{
		if (player.helperFunctions.CheckOnGround(player.gameObject) || player.helperFunctions.CheckOnCeiling()) 
		{
			player.reverseGravity = !player.reverseGravity;
			player.transform.RotateAround (player.transform.position, Vector3.right, 180f);
			player.GetComponent<Rigidbody2D>().gravityScale = player.GetComponent<Rigidbody2D>().gravityScale * (-1f);
		}
	}
}
