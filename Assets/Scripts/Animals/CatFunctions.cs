using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class CatFunctions : MonoBehaviour, IAnimalFunctions
    {

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
            if (HelperFunctions.CheckOnGround(gameObject) || HelperFunctions.CheckOnCeiling())
            {
                PlayerController.reverseGravity = !PlayerController.reverseGravity;
                PlayerController.playerTransform.RotateAround(PlayerController.playerTransform.position, Vector3.right, 180f);
                //player.GetComponent<Rigidbody2D>().gravityScale = player.GetComponent<Rigidbody2D>().gravityScale * (-1f);
                PlayerController.playerGameObject.GetComponent<Rigidbody2D>().gravityScale *= (-1f); //Simplified fra den ovenover, ved ikke om det virker

            }
        }
    }
}