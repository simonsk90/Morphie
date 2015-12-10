using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class HelperFunctions : MonoBehaviour {

	private PlayerController player;
	private LayerMask mask = 1 << 4;
	public delegate void CallBack();
	
	void Awake()
	{
		player = GameObject.Find("Stickman").GetComponent<PlayerController>();
	}
	
	void Update () {
		
	}
	
	public bool CheckOnGround(GameObject obj)
	{
		bool onGround = false;
		Vector2 startPoint = obj.transform.position;
		startPoint.x = obj.GetComponent<Collider2D>().bounds.min.x + 0.1f; // + 0.1f
		startPoint.y = obj.GetComponent<Collider2D>().bounds.min.y;
		RaycastHit2D hit = Physics2D.Raycast(startPoint, -Vector2.up, 0.020f, mask); //Maybe change distance if model is changed
		
		if (hit.collider != null)
		{
			if (hit.collider.tag == "Ground")
			{
				onGround = true;
			}
		}
		
		if (!onGround)
		{
			startPoint.x = obj.GetComponent<Collider2D>().bounds.max.x - 0.1f;
			hit = Physics2D.Raycast(startPoint, -Vector2.up, 0.020f, mask); //Maybe change distance if model is changed
			
			if (hit.collider != null)
			{
				if(hit.collider.tag == "Ground")
				{
					onGround = true;
				}
			}
		}
        Debug.Log("ONG" + onGround);
        return onGround;
	}
	
	public bool CheckOnCeiling()
	{
		bool onGround = false;
		Vector2 startPoint = player.transform.position;
		startPoint.x = player.GetComponent<Collider2D>().bounds.min.x + 0.1f;
		startPoint.y = player.GetComponent<Collider2D>().bounds.max.y;
		RaycastHit2D hit = Physics2D.Raycast(startPoint, Vector2.up, 0.020f, mask); //Maybe change distance if model is changed
		
		if (hit.collider != null)
		{
			onGround = true;
		}
		
		else
		{
			startPoint.x = player.GetComponent<Collider2D>().bounds.max.x-0.1f;
			hit = Physics2D.Raycast(startPoint, Vector2.up, 0.020f, mask); //Maybe change distance if model is changed
			
			if(hit.collider != null)
			{
				onGround = true;
			}
		}
        Debug.Log("ONC" + onGround);
		return onGround;
	}
	
	public void CorrectShapePosition(int shape, Vector2 newSize) 
	{
		Vector2 newPosition = new Vector2();
		Bounds oldBounds = player.GetComponent<BoxCollider2D>().bounds;
		player.anim.SetInteger("shape", shape);
		player.GetComponent<BoxCollider2D>().size = newSize;
		
		//Correct Y-axis
		/*
		if (Mathf.Abs (player.collider2D.bounds.max.y - player.collider2D.bounds.min.y) < Mathf.Abs (oldBounds.max.y - oldBounds.min.y))
		{
			if (!player.reverseGravity)
			{
				//player.transform.position = new Vector2(player.transform.position.x, 
				//                                        player.transform.position.y - (player.collider2D.bounds.min.y - oldBounds.min.y));
				newPosition.y = player.transform.position.y - (player.collider2D.bounds.min.y - oldBounds.min.y);
			}
			else
			{
				//player.transform.position = new Vector2(player.transform.position.x, 
				//                                        player.transform.position.y + (oldBounds.max.y - player.collider2D.bounds.max.y));
				newPosition.y = player.transform.position.y + (oldBounds.max.y - player.collider2D.bounds.max.y);
			}

		}
		else
		{
			if (!player.reverseGravity)
			{
				//player.transform.position = new Vector2(player.transform.position.x, 
				//                                        player.transform.position.y + (oldBounds.min.y - player.collider2D.bounds.min.y));
				newPosition.y = player.transform.position.y + (oldBounds.min.y - player.collider2D.bounds.min.y);
			}
			else
			{
				//player.transform.position = new Vector2(player.transform.position.x, 
				//                                        player.transform.position.y - (player.collider2D.bounds.max.y - oldBounds.max.y));
				newPosition.y = player.transform.position.y + (player.collider2D.bounds.max.y - oldBounds.max.y); // -
			}
		}

		//Correct X-axis

			//player.transform.position = new Vector2(player.transform.position.x - (player.collider2D.bounds.max.x - oldBounds.max.x),
			//										player.transform.position.y);

		*/
		
		if (player.reverseGravity)
		{
			newPosition.y = player.transform.position.y - (player.GetComponent<Collider2D>().bounds.max.y - oldBounds.max.y);
		}
		else
		{
			newPosition.y = player.transform.position.y + (player.GetComponent<Collider2D>().bounds.max.y - oldBounds.max.y);
		}
		
		newPosition.x = player.transform.position.x - (player.GetComponent<Collider2D>().bounds.max.x - oldBounds.max.x);
		
		player.transform.position = newPosition;
		
	}
	
	public IEnumerator AddDelay(int seconds, CallBack cb)
	{
		//Debug.Log ("Delay");
		yield return new WaitForSeconds(seconds);
		
		cb();
	}
	
	public void MakeDisappear(GameObject go) //Skal måske også fjerne go's children
		// Skal måske bare bruge go.setActive = false ????
	{
		if (go.GetComponent<Renderer>() != null)
		{
			go.GetComponent<Renderer>().enabled = false;
		}
		/*if (go.collider2D != null)
		{
			go.collider2D.enabled = false;
		}*/
		
		foreach(Collider2D c in go.GetComponents<Collider2D>()) {
			c.enabled = false;
		}
	}

	public IEnumerator Cooldown(float duration, Action<bool> setCooldown)
	{
		setCooldown(true);
		
		float timer = 0f;
		while (timer < duration)
		{
			timer += Time.deltaTime;
			yield return null;
		}
		
		setCooldown(false);
	}
	
}
