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

    public void MoveLeftIfActive()
    {
        if (!activated)
        {
            screenPos = Camera.main.WorldToScreenPoint(transform.position);
            if (player.helperFunctions.UnitWithinScreenSpace(screenPos))
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
