using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class CatFunctions : MonoBehaviour, IAnimalFunctions
    {

        private PlayerController player;

        void Awake()
        {
            player = HelperFunctions.player;
        }

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
            if (HelperFunctions.CheckOnGround(player.playerGameObject) || HelperFunctions.CheckOnCeiling())
            {
                player.reverseGravity = !player.reverseGravity;
                player.playerTransform.RotateAround(player.playerTransform.position, Vector3.right, 180f);
                player.playerRigidBody.gravityScale = player.playerRigidBody.gravityScale * (-1f);
            }
        }
    }
}