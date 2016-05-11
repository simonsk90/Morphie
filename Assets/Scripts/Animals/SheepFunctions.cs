using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class SheepFunctions : MonoBehaviour, IAnimalFunctions
    {
<<<<<<< HEAD

        private PlayerController player;

        void Awake()
        {
            player = HelperFunctions.player;
        }

        void Start()
        {

        }

=======
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
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
<<<<<<< HEAD
            if (HelperFunctions.CheckOnGround(player.gameObject as GameObject))
            {
                player.playerRigidBody.AddForce(Vector2.up * 240f); //Rewrite to not use force
=======
            if (HelperFunctions.CheckOnGround(PlayerController.playerGameObject))
            {
                PlayerController.playerRigidBody.AddForce(Vector2.up * 240f); //Rewrite to not use force
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            }

            else if (HelperFunctions.CheckOnCeiling())
            {
<<<<<<< HEAD
                player.playerRigidBody.AddForce(-Vector2.up * 240f); //Rewrite to not use force
            }

        }

=======
                PlayerController.playerRigidBody.AddForce(-Vector2.up * 240f); //Rewrite to not use force
            }
        }
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
    }
}