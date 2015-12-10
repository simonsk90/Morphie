using UnityEngine;
using System.Collections;

public class TurtleFunctions : MonoBehaviour, IAnimalFunctions {

	private PlayerController player;
	private GameObject[] enemies;
	private bool cooldown = false;
	
	void Awake()
	{
		player = GameObject.Find("Stickman").GetComponent<PlayerController>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
	
	void Start () {	
		
	}
	
	public void ChangeShape()
	{
		//player.anim.SetInteger("shape", 8);
		Vector2 newSize = new Vector2(0.8f, 0.8f);
		player.helperFunctions.CorrectShapePosition(8, newSize);
	}

	public void LeaveShape()
	{
		
	}
	
	public void UpdateFunctions()
	{
		
	}
	
	public void Ability()
	{
		if (!this.cooldown) {
			StartCoroutine(SlowTime());
		}
	}

	IEnumerator SlowTime() 
	{
		float timer = 0f;

		StartCoroutine(player.helperFunctions.Cooldown(10f, x => this.cooldown = x));
		//StartCoroutine(Cooldown());

		foreach (GameObject enemy in enemies) {
			var ec = enemy.GetComponent<EnemyController>();
			if (ec.speed != null)
			{
				ec.speed = ec.speed * 0.4f;
			}
		}

		while (timer < 8f)
		{
			timer += Time.deltaTime;
			yield return null;
		}
		foreach (GameObject enemy in enemies) {
			var ec = enemy.GetComponent<EnemyController>();
			ec.speed = ec.speed * 2.5f;
		}
	}

	IEnumerator Cooldown() 
	{
		this.cooldown = true;
		float timer = 0f;
		while (timer < 10f)
		{
			timer += Time.deltaTime;
			yield return null;
		}
		this.cooldown = false;
	}
}
