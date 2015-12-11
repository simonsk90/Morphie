using UnityEngine;

public class EnemySuperclass : MonoBehaviour {

    public PlayerController player;
    public float speed;
    private Vector2 screenPos;
    private bool activated = false;

    void Awake()
    {
        player = GameObject.Find("Stickman").GetComponent<PlayerController>();
    }
	
    private bool UnitWithinScreenSpace(Vector2 unitScreenPos)
    {
        if (
           (unitScreenPos.x < Screen.width && unitScreenPos.y < Screen.height) &&
           (unitScreenPos.x > 0f && unitScreenPos.y > 0f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MoveLeftIfActive()
    {
        if (!activated)
        {
            screenPos = Camera.main.WorldToScreenPoint(transform.position);
            if (UnitWithinScreenSpace(screenPos))
            {
                transform.Translate(Vector2.right * -speed * Time.deltaTime);
                activated = true;
            }
        }
        else
        {
            transform.Translate(Vector2.right * -speed * Time.deltaTime);
        }
    }
}
