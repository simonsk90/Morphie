using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Morphie
{

    public class MonkeyFunctions : MonoBehaviour, IAnimalFunctions
    {
        private PlayerController player;
        private bool cooldown;
        private List<Vector2> positionList = new List<Vector2>();
        private List<Bounds> boundsList = new List<Bounds>();
        public bool reversing = false;


        void Awake()
        {
            player = HelperFunctions.player;
        }

        void Start()
        {
            StartCoroutine(HelperFunctions.Cooldown(7f, x => cooldown = x));
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
            int registeredShape = player.anim.GetInteger("shape");
            bool reached = false;
            float step = 10f; //10
            reversing = true;
            player.invulnerable = true;
            player.speed = 0f;
            //StartCoroutine(Cooldown());
            StartCoroutine(HelperFunctions.Cooldown(7f, x => cooldown = x));
            target = CorrectTargetPosition(target, oldBounds);
            ReactivatePassedObjects(target);
            Debug.Log(target);
            player.playerCollider.isTrigger = true;

            while (!reached && !player.isDead)
            {
                if (player.anim.GetInteger("shape") != registeredShape)
                {
                    target = CorrectTargetPosition(originalTarget, oldBounds);
                    Debug.Log(target);
                    registeredShape = player.anim.GetInteger("shape");

                    ToggleAnimalStuff(false, registeredShape);

                }

                player.playerRigidBody.isKinematic = true;
                player.invulnerable = true;
                player.playerTransform.position = Vector2.MoveTowards(player.playerTransform.position, target, step * Time.deltaTime);
                player.cam.PositionCamera();

                if (player.playerTransform.position.x < target.x + 0.0001f)
                {
                    reached = true;
                    if (!player.anim.GetBool("isDisrupting"))
                    {
                        player.playerCollider.isTrigger = false;
                        player.playerRigidBody.isKinematic = false;
                        player.invulnerable = false;

                        ToggleAnimalStuff(true, registeredShape);
                    }
                    player.speed = 2f;
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
            float difY = (oldBounds.max.y - oldBounds.min.y) - (player.playerCollider.bounds.max.y - player.playerCollider.bounds.min.y);
            //float difY = Mathf.Abs(Mathf.Abs(oldBounds.max.y - oldBounds.min.y) - Mathf.Abs (player.collider2D.bounds.max.y - player.collider2D.bounds.min.y));
            float difX = Mathf.Abs(Mathf.Abs(oldBounds.max.x - oldBounds.min.x) - Mathf.Abs(player.playerCollider.bounds.max.x - player.playerCollider.bounds.min.x));

            if (!player.reverseGravity)
            {
                Debug.Log(difY);

                if (difY < 0f)
                {
                    Debug.Log("Smaller");
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
                    Debug.Log("Smaller");
                    newTarget.y = target.y + difY * 0.5f;
                }

                else
                {
                    Debug.Log("Bigger");
                    newTarget.y = target.y + difY * 0.5f;

                }
            }

            newTarget.x = target.x - difX * 0.5f;

            return newTarget;
        }

        IEnumerator Track()
        {
            float timer = 0f;

            positionList.Add(player.playerTransform.position);
            boundsList.Add(player.playerCollider.bounds);

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

        private void ToggleAnimalStuff(bool activate, int animal)
        {
            //Er måske ikke nødvendigt at spørge efter activate, men sætte alle variabler udfra bool'en.
            if (!activate) //Deactivate stuff
            {
                switch (animal)
                {
                    case 2: //BIRD
                        player.GetComponent<BirdFunctions>().slowfallBlocked = true;
                        break;

                        //DINO CHECKER NU SELV OM REVERSING == TRUE, OG ER DERFOR FJERNET. Same goes for PIG but haven't tested that one yet.
                }
            }
            else //Activate them
            {
                switch (animal)
                {
                    case 2: //BIRD
                        player.GetComponent<BirdFunctions>().slowfallBlocked = false;
                        break;

                    case 4: //PIG
                        player.GetComponent<PigFunctions>().detector.GetComponent<Collider2D>().enabled = true;
                        break;

                    case 9: //DINO
                        player.GetComponent<DinoFunctions>().ToggleDetector(true);
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
