using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class SheepFunctions : MonoBehaviour, IAnimalFunctions
    {

        private PlayerController player;

        void Awake()
        {
            player = HelperFunctions.player;
        }

        void Start()
        {

        }

        public void ChangeShape()
        {
            Vector2 newSize = new Vector2(0.41f, 0.5f);
            HelperFunctions.CorrectShapePosition(1, newSize);
        }

        public void LeaveShape()
        {

        }

        public void UpdateFunctions()
        {

        }

        public void Ability()
        {
            if (HelperFunctions.CheckOnGround(player.gameObject as GameObject))
            {
                player.playerRigidBody.AddForce(Vector2.up * 240f); //Rewrite to not use force
            }

            else if (HelperFunctions.CheckOnCeiling())
            {
                player.playerRigidBody.AddForce(-Vector2.up * 240f); //Rewrite to not use force
            }

        }

    }
}