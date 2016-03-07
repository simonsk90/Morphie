using UnityEngine;

namespace Morphie
{

    public class EnemySuperclass : MonoBehaviour
    {

        public PlayerController player;
        public CowFunctions cf;
        public float speed;
        private Vector2 screenPos;
        private bool activated = false;

        //void Awake()
        //{
        //    player = HelperFunctions.player;
        //    cf = player.GetComponent<CowFunctions>();
        //}

        //void Awake()
        //{
        //    Debug.Log("Hello");
        //}

        void Start()
        {
            player = HelperFunctions.player;
            cf = player.GetComponent<CowFunctions>();
        }

        public void MoveLeftIfActive()
        {
            if (!activated)
            {
                screenPos = Camera.main.WorldToScreenPoint(transform.position);
                if (HelperFunctions.UnitWithinScreenSpace(screenPos))
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
}