using UnityEngine;
using System.Collections; 
using System.Collections.Generic;

namespace Morphie
{

    public class MonkeyFunctions : MonoBehaviour, IAnimalFunctions
    {
        private bool cooldown;
        private List<Vector2> positionList = new List<Vector2>();
        private List<Bounds> boundsList = new List<Bounds>();
        public static bool reversing = false;

        void Start()
        {
            StartCoroutine(Cooldown());
            StartCoroutine(Track());
        }

        public void ChangeShape()
        {
            Vector2 newSize = new Vector2(1.03f, 0.65f);
            HelperFunctions.CorrectShapePosition(5, newSize);
        }

        public void LeaveShape()
        {

        }

        public void UpdateFunctions()
        {

        }

        public void Ability()
        {
            if (!cooldown)
            {
                StartCoroutine(Move(positionList[0], boundsList[0]));
                positionList.Clear();
                boundsList.Clear();
            }
        }

        IEnumerator Move(Vector2 target, Bounds oldBounds)
        {
            Vector2 originalTarget = target;
            int registeredShape = PlayerController.anim.GetInteger("shape");
            bool reached = false;
            float step = 10f; //10
            reversing = true;
            PlayerController.invulnerable = true;
            PlayerController.speed = 0f;
            //StartCoroutine(Cooldown());
            StartCoroutine(HelperFunctions.Cooldown(7f, x => cooldown = x));
            target = CorrectTargetPosition(target, oldBounds);
            ReactivatePassedObjects(target);
            //Debug.Log(target);
            PlayerController.playerBoxCollider.isTrigger = true;

            while (!reached && !PlayerController.isDead)
            {
                if (PlayerController.anim.GetInteger("shape") != registeredShape)
                {
                    target = CorrectTargetPosition(originalTarget, oldBounds);
                    //Debug.Log(target);
                    registeredShape = PlayerController.anim.GetInteger("shape");
                    ToggleAnimalStuff(false, registeredShape);
                }

                PlayerController.playerRigidBody.isKinematic = true;
                PlayerController.invulnerable = true;
                PlayerController.playerTransform.position = Vector2.MoveTowards(PlayerController.playerTransform.position, target, step * Time.deltaTime);
                CameraController.PositionCamera();

                if (PlayerController.playerTransform.position.x < target.x + 0.0001f)
                {
                    reached = true;
                    if (PlayerController.anim.GetBool("isDisrupting"))
                    {
                        PlayerController.playerBoxCollider.isTrigger = false;
                        PlayerController.playerRigidBody.isKinematic = false;
                        PlayerController.invulnerable = false;

                        ToggleAnimalStuff(true, registeredShape);
                    }
                    PlayerController.speed = 2f;
                }
                yield return null;
            }
            reversing = false;
        }

        private void ReactivatePassedObjects(Vector2 target)
        {
            //List<GameObject> oldObjects = new List<GameObject>();

            foreach (GameObject go in ObjectsController.inactiveObjects)
            {
                if (go.transform.position.x > target.x - 5f && go.tag != "Enemy" && go.tag != "Pickup" && go.tag != "Untagged")
                {
                    go.SetActive(true);
                    //oldObjects.Add(go);
                    ObjectsController.activeObjects.Insert(0, go);
                }
            }
        }

        private Vector2 CorrectTargetPosition(Vector2 target, Bounds oldBounds)
        {
            Vector2 newTarget;
            float difY = (oldBounds.max.y - oldBounds.min.y) - (PlayerController.playerBoxCollider.bounds.max.y - PlayerController.playerBoxCollider.bounds.min.y);
            //float difY = Mathf.Abs(Mathf.Abs(oldBounds.max.y - oldBounds.min.y) - Mathf.Abs (player.collider2D.bounds.max.y - player.collider2D.bounds.min.y));
            float difX = Mathf.Abs(Mathf.Abs(oldBounds.max.x - oldBounds.min.x) - Mathf.Abs(PlayerController.playerBoxCollider.bounds.max.x - PlayerController.playerBoxCollider.bounds.min.x));

            if (!PlayerController.reverseGravity)
            {
                //Debug.Log(difY);

                if (difY < 0f)
                {
                    //Debug.Log("Smaller");
                    newTarget.y = target.y - difY * 0.5f;
                }

                else
                {
                    newTarget.y = target.y + difY * 0.5f - difY;

                }

            }
            else
            {
                //newTarget.y = target.y - difY * 0.5f;

                if (difY < 0f)
                {
                    //Debug.Log("Smaller");
                    newTarget.y = target.y + difY * 0.5f;
                }

                else
                {
                    //Debug.Log("Bigger");
                    newTarget.y = target.y + difY * 0.5f;

                }
            }

            newTarget.x = target.x - difX * 0.5f;

            return newTarget;
        }

        IEnumerator Track()
        {
            float timer = 0f;

            positionList.Add(PlayerController.playerTransform.position);
            boundsList.Add(PlayerController.playerBoxCollider.bounds);

            if (positionList.Count > 10)
            {
                positionList.RemoveAt(0);
                boundsList.RemoveAt(0);
            }

            while (timer < 0.5f)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            StartCoroutine(Track());
        }

        IEnumerator Cooldown()
        {
            float timer = 0f;

            cooldown = true;

            while (timer < 7f)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            cooldown = false;
        }

        private void ToggleAnimalStuff(bool activate, int animal)
        {
            //Er måske ikke nødvendigt at spørge efter activate, men sætte alle variabler udfra bool'en.
            if (!activate) //Deactivate stuff
            {
                switch (animal)
                {
                    case 2: //BIRD
                        BirdFunctions.slowfallBlocked = true;
                        break;
                        //DINO CHECKER NU SELV OM REVERSING == TRUE, OG ER DERFOR FJERNET. Same goes for PIG but haven't tested that one yet.
                }
            }
            else //Activate them
            {
                switch (animal)
                {
                    case 2: //BIRD
                        BirdFunctions.slowfallBlocked = false;
                        break;

                    case 4: //PIG
                        PigFunctions.detector.GetComponent<Collider2D>().enabled = true;
                        break;

                    case 9: //DINO
                        DinoFunctions.ToggleDetector(true);
                        break;
                }
            }
        }

        private void DebugPositionList()
        {
            foreach (Vector2 pos in positionList)
            {
                Debug.Log(pos);
            }
            Debug.Log("Target: " + positionList[positionList.Count - 10]);
        }
    }
}
