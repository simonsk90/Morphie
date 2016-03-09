using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Morphie
{

    public class DinoFunctions : MonoBehaviour, IAnimalFunctions
    {

        private PlayerController player;
        private BoxCollider2D dTop;
        private BoxCollider2D dBot;
        private BoxCollider2D dMain;
        private GameObject detector;
        private bool activated = false;
        private Vector2 newSize = new Vector2(1.5f, 3f);

        void Awake()
        {
            player = HelperFunctions.player;

            detector = Instantiate(Resources.Load("Detector")) as GameObject;

            detector.transform.parent = player.playerTransform;
            detector.transform.localPosition = new Vector2(0f, 0f);
            detector.transform.localScale = new Vector2(player.transform.localScale.x, player.transform.localScale.y);

            dMain = detector.transform.FindChild("DetectorMain").GetComponent<Collider2D>() as BoxCollider2D;
            dMain.transform.localScale = new Vector2(player.transform.localScale.x, player.transform.localScale.y);
            dMain.size = new Vector2(newSize.x + 0.2f, newSize.y - 0.4f);
            dMain.transform.localPosition = new Vector2(0f, 0f);

            dBot = detector.transform.FindChild("DetectorBottom").GetComponent<Collider2D>() as BoxCollider2D;
            dBot.transform.localScale = new Vector2(player.transform.localScale.x, player.transform.localScale.y);
            dBot.size = new Vector2(newSize.x, Mathf.Abs(newSize.y - dMain.size.y) * 0.5f);
            dBot.transform.position = new Vector2(0f, dMain.bounds.min.y - dBot.size.y * 0.5f);

            dTop = detector.transform.FindChild("DetectorTop").GetComponent<Collider2D>() as BoxCollider2D;
            dTop.transform.localScale = new Vector2(player.transform.localScale.x, player.transform.localScale.y);
            dTop.size = new Vector2(newSize.x, Mathf.Abs(newSize.y - dMain.size.y) * 0.5f);
            dTop.transform.position = new Vector2(0f, dMain.bounds.max.y + dTop.size.y * 0.5f);

            ToggleDetector(false);
        }

        // Use this for initialization
        void Start()
        {

        }

        public void ChangeShape()
        {
            if (!activated)
            {
                float diff = Mathf.Abs(player.playerCollider.bounds.min.y - dBot.bounds.min.y);

                player.invulnerable = true;

                if (!player.reverseGravity)
                {
                    detector.transform.position = new Vector2(detector.transform.position.x, detector.transform.position.y + diff);
                }
                else
                {
                    detector.transform.position = new Vector2(detector.transform.position.x, detector.transform.position.y - diff);
                }

                //if (AnimalContainer.animalsInUse.Contains(5))   //TROR DENNE HER SKAL BRUGES FREMFOR DEN NEDENUNDER
                //{
                //    if (!player.GetComponent<MonkeyFunctions>().reversing)
                //    {
                //        ToggleDetector(true);
                //    }
                //}

                if (player.GetComponent<MonkeyFunctions>() != null)
                {
                    if (!player.GetComponent<MonkeyFunctions>().reversing)
                    {
                        ToggleDetector(true);
                    }
                }
                else
                {
                    ToggleDetector(true);
                }

                StartCoroutine(ChangeCollider());
                StartCoroutine(Duration());
            }
            else
            {
                player.SwitchShape(player.previousShape);
            }
        }

        public void LeaveShape()
        {
            if (!activated)
            {
                ToggleDetector(false);
                StopCoroutine(Duration());
                activated = true;
                player.invulnerable = false;
            }
        }

        public void UpdateFunctions()
        {
        }

        public void Ability()
        {

        }

        IEnumerator ChangeCollider()
        {
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();

            HelperFunctions.CorrectShapePosition(9, newSize);
            detector.transform.position = player.playerTransform.position;
        }

        IEnumerator Duration()
        {
            float timer = 0f;

            while (timer < 10f)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            if (!activated)
            {
                player.SwitchShape(player.previousShape);
            }
        }

        public void ToggleDetector(bool activate)
        {
            dMain.enabled = activate;
            dBot.enabled = activate;
            dTop.enabled = activate;
        }
    }
}