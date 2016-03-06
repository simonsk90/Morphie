using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class SheepFunctions : MonoBehaviour, IAnimalFunctions
    {
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
            if (HelperFunctions.CheckOnGround(PlayerController.playerGameObject))
            {
                PlayerController.playerRigidBody.AddForce(Vector2.up * 240f); //Rewrite to not use force
            }

            else if (HelperFunctions.CheckOnCeiling())
            {
                PlayerController.playerRigidBody.AddForce(-Vector2.up * 240f); //Rewrite to not use force
            }
        }
    }
}