using UnityEngine;
using System.Collections;

namespace Morphie
{
    public class BirdFunctions : MonoBehaviour, IAnimalFunctions
    {

        //private PlayerController player;
        public static bool slowfallBlocked = false;

        void Awake()
        {
            //player = GameObject.Find("Stickman").GetComponent<PlayerController>();
        }

        void Start()
        {
            if (!HelperFunctions.CheckOnGround(gameObject))
            {
                PlayerController.playerTransform.position -= PlayerController.playerTransform.up * Time.deltaTime * 0.5f;
            }
        }

        public void ChangeShape()
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            slowfallBlocked = false;

            Vector2 newSize = new Vector2(0.41f, 0.35f);
            HelperFunctions.CorrectShapePosition(2, newSize);
        }

        public void LeaveShape()
        {

        }

        public void UpdateFunctions()
        {
            if (!HelperFunctions.CheckOnGround(gameObject))
            {
                if (!slowfallBlocked)
                {
                    PlayerController.playerTransform.position -= transform.up * Time.deltaTime * 0.5f;
                }
            }
            else if (!HelperFunctions.CheckOnCeiling())
            {
                //transform.position += transform.up * Time.deltaTime * 0.5f;
            }
        }

        public void Ability()
        {

        }
    }
}