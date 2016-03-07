using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class BirdFunctions : MonoBehaviour, IAnimalFunctions
    {

        private PlayerController player;
        public bool slowfallBlocked = false;

        void Awake()
        {
            player = HelperFunctions.player;
        }

        void Start()
        {
            if (!HelperFunctions.CheckOnGround(player.playerGameObject))
            {
                player.playerTransform.position -= player.playerTransform.up * Time.deltaTime * 0.5f;
            }
        }

        public void ChangeShape()
        {
            player.playerRigidBody.isKinematic = true;
            player.playerRigidBody.isKinematic = false;
            player.playerRigidBody.gravityScale = 0f;
            slowfallBlocked = false;

            Vector2 newSize = new Vector2(0.41f, 0.35f);
            HelperFunctions.CorrectShapePosition(2, newSize);
        }

        public void LeaveShape()
        {

        }

        public void UpdateFunctions()
        {
            if (!HelperFunctions.CheckOnGround(player.playerGameObject))
            {
                if (!slowfallBlocked)
                {
                    player.playerTransform.position -= player.playerTransform.up * Time.deltaTime * 0.5f;
                }
            }
            else if (!HelperFunctions.CheckOnCeiling())
            {
                //transform.position += transform.up * Time.deltaTime * 0.5f;
                //SLET??
            }
        }

        public void Ability()
        {

        }
    }
}