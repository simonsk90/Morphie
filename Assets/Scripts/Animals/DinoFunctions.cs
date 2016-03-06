using UnityEngine;
using System.Collections; 
using System.Collections.Generic;

namespace Morphie
{

    public class DinoFunctions : MonoBehaviour, IAnimalFunctions
    {
        private static BoxCollider2D dTop;
        private static BoxCollider2D dBot;
        private static BoxCollider2D dMain;
        private GameObject detector;
        private bool activated = false;
        private Vector2 newSize = new Vector2(1.5f, 3f);
        private Transform detectorTransform;

        void Awake()
        {
            detector = Instantiate(Resources.Load("Detector")) as GameObject;

            detectorTransform = detector.transform;

            detectorTransform.parent = PlayerController.playerTransform;
            detectorTransform.localPosition = new Vector2(0f, 0f);
            detectorTransform.localScale = new Vector2(PlayerController.playerTransform.localScale.x, PlayerController.playerTransform.localScale.y);

            dMain = detectorTransform.FindChild("DetectorMain").GetComponent<Collider2D>() as BoxCollider2D;
            dMain.transform.localScale = new Vector2(PlayerController.playerTransform.localScale.x, PlayerController.playerTransform.localScale.y);
            dMain.size = new Vector2(newSize.x + 0.2f, newSize.y - 0.4f);
            dMain.transform.localPosition = new Vector2(0f, 0f);

            dBot = detectorTransform.FindChild("DetectorBottom").GetComponent<Collider2D>() as BoxCollider2D;
            dBot.transform.localScale = new Vector2(PlayerController.playerTransform.localScale.x, PlayerController.playerTransform.localScale.y);
            dBot.size = new Vector2(newSize.x, Mathf.Abs(newSize.y - dMain.size.y) * 0.5f);
            dBot.transform.position = new Vector2(0f, dMain.bounds.min.y - dBot.size.y * 0.5f);

            dTop = detectorTransform.FindChild("DetectorTop").GetComponent<Collider2D>() as BoxCollider2D;
            dTop.transform.localScale = new Vector2(PlayerController.playerTransform.localScale.x, PlayerController.playerTransform.localScale.y);
            dTop.size = new Vector2(newSize.x, Mathf.Abs(newSize.y - dMain.size.y) * 0.5f);
            dTop.transform.position = new Vector2(0f, dMain.bounds.max.y + dTop.size.y * 0.5f);

            ToggleDetector(false);
        }

        public void ChangeShape()
        {
            if (!activated)
            {
                float diff = Mathf.Abs(PlayerController.playerBoxCollider.bounds.min.y - dBot.bounds.min.y);

                PlayerController.invulnerable = true;

                if (!PlayerController.reverseGravity)
                {
                    detectorTransform.position = new Vector2(detectorTransform.position.x, detectorTransform.position.y + diff);
                }
                else
                {
                    detectorTransform.position = new Vector2(detectorTransform.position.x, detectorTransform.position.y - diff);
                }

                if (PlayerController.playerGameObject.GetComponent<MonkeyFunctions>() != null)
                {
                    if (!MonkeyFunctions.reversing)
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
                PlayerController.SwitchShape(PlayerController.previousShape);
            }
        }

        public void LeaveShape()
        {
            if (!activated)
            {
                ToggleDetector(false);
                StopCoroutine(Duration());
                activated = true;
                PlayerController.invulnerable = false;
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
            detectorTransform.position = PlayerController.playerTransform.position;
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
                PlayerController.SwitchShape(PlayerController.previousShape);
            }
        }

        public static void ToggleDetector(bool activate)
        {
            dMain.enabled = activate;
            dBot.enabled = activate;
            dTop.enabled = activate;
        }
    }
}