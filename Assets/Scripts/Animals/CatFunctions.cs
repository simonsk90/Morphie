using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class CatFunctions : MonoBehaviour, IAnimalFunctions
    {

<<<<<<< HEAD
        private PlayerController player;

        void Awake()
        {
            player = HelperFunctions.player;
        }

=======
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        public void ChangeShape()
        {
            //rigidbody2D.mass = 10f;  NOT SURE IF THIS IS NEEDED OR NOT, KEEP IN MIND IF THINGS ACT STRANGE SUDDENLY
            Vector2 newSize = new Vector2(0.8f, 0.8f);
            HelperFunctions.CorrectShapePosition(7, newSize);
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
            if (HelperFunctions.CheckOnGround(player.playerGameObject) || HelperFunctions.CheckOnCeiling())
            {
                player.reverseGravity = !player.reverseGravity;
                player.playerTransform.RotateAround(player.playerTransform.position, Vector3.right, 180f);
                player.playerRigidBody.gravityScale = player.playerRigidBody.gravityScale * (-1f);
=======
            if (HelperFunctions.CheckOnGround(gameObject) || HelperFunctions.CheckOnCeiling())
            {
                PlayerController.reverseGravity = !PlayerController.reverseGravity;
                PlayerController.playerTransform.RotateAround(PlayerController.playerTransform.position, Vector3.right, 180f);
                //player.GetComponent<Rigidbody2D>().gravityScale = player.GetComponent<Rigidbody2D>().gravityScale * (-1f);
                PlayerController.playerGameObject.GetComponent<Rigidbody2D>().gravityScale *= (-1f); //Simplified fra den ovenover, ved ikke om det virker

>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            }
        }
    }
}