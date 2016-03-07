using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class SheepFunctions : MonoBehaviour, IAnimalFunctions
    {

        private PlayerController player;

        void Awake()
        {
            player = GameObject.Find("Stickman").GetComponent<PlayerController>();
        }

        void Start()
        {

        }

        public void ChangeShape()
        {
            Vector2 newSize = new Vector2(0.41f, 0.5f);
            player.helperFunctions.CorrectShapePosition(1, newSize);
        }

        public void LeaveShape()
        {

        }

        public void UpdateFunctions()
        {

        }

        public void Ability()
        {
            if (player.helperFunctions.CheckOnGround(player.gameObject as GameObject))
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 240f); //Rewrite to not use force
            }

            else if (player.helperFunctions.CheckOnCeiling())
            {
                GetComponent<Rigidbody2D>().AddForce(-Vector2.up * 240f); //Rewrite to not use force
            }

        }

    }
}