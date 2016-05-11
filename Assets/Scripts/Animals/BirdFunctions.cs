using UnityEngine;
using System.Collections;

namespace Morphie
{
<<<<<<< HEAD

    public class BirdFunctions : MonoBehaviour, IAnimalFunctions
    {

        private PlayerController player;
        public bool slowfallBlocked = false;

        void Awake()
        {
            player = HelperFunctions.player;
=======
    public class BirdFunctions : MonoBehaviour, IAnimalFunctions
    {

        //private PlayerController player;
        public static bool slowfallBlocked = false;

        void Awake()
        {
            //player = GameObject.Find("Stickman").GetComponent<PlayerController>();
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        }

        void Start()
        {
<<<<<<< HEAD
            if (!HelperFunctions.CheckOnGround(player.playerGameObject))
            {
                player.playerTransform.position -= player.playerTransform.up * Time.deltaTime * 0.5f;
=======
            if (!HelperFunctions.CheckOnGround(gameObject))
            {
                PlayerController.playerTransform.position -= PlayerController.playerTransform.up * Time.deltaTime * 0.5f;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            }
        }

        public void ChangeShape()
        {
<<<<<<< HEAD
            player.playerRigidBody.isKinematic = true;
            player.playerRigidBody.isKinematic = false;
            player.playerRigidBody.gravityScale = 0f;
=======
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().gravityScale = 0f;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            slowfallBlocked = false;

            Vector2 newSize = new Vector2(0.41f, 0.35f);
            HelperFunctions.CorrectShapePosition(2, newSize);
        }

        public void LeaveShape()
        {

        }

        public void UpdateFunctions()
        {
<<<<<<< HEAD
            if (!HelperFunctions.CheckOnGround(player.playerGameObject))
            {
                if (!slowfallBlocked)
                {
                    player.playerTransform.position -= player.playerTransform.up * Time.deltaTime * 0.5f;
=======
            if (!HelperFunctions.CheckOnGround(gameObject))
            {
                if (!slowfallBlocked)
                {
                    PlayerController.playerTransform.position -= transform.up * Time.deltaTime * 0.5f;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
                }
            }
            else if (!HelperFunctions.CheckOnCeiling())
            {
                //transform.position += transform.up * Time.deltaTime * 0.5f;
<<<<<<< HEAD
                //SLET??
=======
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            }
        }

        public void Ability()
        {

        }
    }
}