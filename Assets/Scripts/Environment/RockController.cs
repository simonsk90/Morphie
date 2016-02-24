using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour {

	private PlayerController player;
	public bool dropped = false;
	private float originalY;
	public Vector2 newPos;
	public float speed;
	public bool moving = false;


    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && !player.invulnerable && !moving)
        {
            player.StartCoroutine(player.Die2());
        }
    } 

	// Use this for initialization
	void Start () {
		this.originalY = this.transform.parent.position.y;
		this.newPos = this.transform.parent.position;
		this.newPos.x++;
		player = GameObject.Find("Stickman").GetComponent<PlayerController>();
	}

	void Update () {

	}

	public IEnumerator MoveRock()
	{
		this.speed = player.speed * 3f;
		moving = true;

		while (this.transform.parent.position.x < newPos.x) //0.5
		{
			if (this.dropped == false)
			{
                this.transform.parent.position = Vector2.MoveTowards(this.transform.parent.position, newPos, speed * Time.deltaTime);
			}

			if (transform.parent.position.y < originalY - 0.1f)
			{
				this.dropped = true;
			}
			yield return null;
		}

        if (!player.helperFunctions.CheckOnGround(this.gameObject.transform.parent.gameObject))
        {
            StartCoroutine(ApplyGravity());
        }
		else
		{
			moving = false;
		}

		this.newPos.x++;
	}

    IEnumerator ApplyGravity()
    {
        float newY = this.transform.parent.position.y - 1f;
        Vector2 newPosY = this.transform.parent.position;
        newPosY.y = newY;
		this.speed = player.speed * 3f;

        while (!dropped)
        {          
            this.transform.parent.position = Vector2.MoveTowards(this.transform.parent.position, newPosY, speed * Time.deltaTime);

            if (this.transform.parent.position.y == newY)
            {
                if (player.helperFunctions.CheckOnGround(this.transform.parent.gameObject))
                { 
                    dropped = true;
                    this.GetComponent<Collider2D>().isTrigger = false;
                }
                else
                {
                    newY--;
                    newPosY.y = newY;
                }
            }
            yield return null;
        }
		moving = false;
    }


}
