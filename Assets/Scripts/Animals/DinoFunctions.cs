using UnityEngine;
using System.Collections; 
using System.Collections.Generic;

namespace Morphie
{

    public class DinoFunctions : MonoBehaviour, IAnimalFunctions
    {
<<<<<<< HEAD

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
            dBot.transform.position = new Vector2(2.37f, dMain.bounds.min.y - dBot.size.y * 0.5f);

            dTop = detector.transform.FindChild("DetectorTop").GetComponent<Collider2D>() as BoxCollider2D;
            dTop.transform.localScale = new Vector2(player.transform.localScale.x, player.transform.localScale.y);
            dTop.size = new Vector2(newSize.x, Mathf.Abs(newSize.y - dMain.size.y) * 0.5f);
            dTop.transform.position = new Vector2(2.37f, dMain.bounds.max.y + dTop.size.y * 0.5f); //Ved ikke lige hvorfor 2.37f give ikke mening. Men så sidder den korrekt
=======
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
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67

            ToggleDetector(false);
        }

<<<<<<< HEAD
        // Use this for initialization
        void Start()
        {

        }

        public void ChangeShape()
        {
            
            if (!activated)
            {
                Debug.Log("After pause");
                //float diff = Mathf.Abs(player.playerCollider.bounds.min.y - dBot.bounds.min.y);
                float diff = Mathf.Abs((player.playerTransform.position.y - player.playerCollider.size.y * 0.5f) - (dBot.transform.position.y - dBot.GetComponent<BoxCollider2D>().size.y * 0.5f));
                //float diffReverse = Mathf.Abs(player.playerCollider.bounds.max.y - dBot.bounds.max.y);
                //float diffReverse = Mathf.Abs((player.playerTransform.position.y + player.playerCollider.size.y * 0.5f) + (dTop.transform.position.y + dTop.GetComponent<BoxCollider2D>().size.y * 0.5f));

                player.invulnerable = true;



                if (!player.reverseGravity)
                {
                    detector.transform.position = new Vector2(detector.transform.position.x, detector.transform.position.y + diff);
                }
                else
                {
                    detector.transform.position = new Vector2(detector.transform.position.x, detector.transform.position.y - diff + player.playerCollider.size.y - dBot.size.y); //Fejl i diff udregning tror jeg, men det bliver en lappeløsning her
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
=======
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
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
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
<<<<<<< HEAD
                player.SwitchShape(player.previousShape);
=======
                PlayerController.SwitchShape(PlayerController.previousShape);
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            }
        }

        public void LeaveShape()
        {
            if (!activated)
            {
                ToggleDetector(false);
                StopCoroutine(Duration());
                activated = true;
<<<<<<< HEAD
                player.invulnerable = false;
=======
                PlayerController.invulnerable = false;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
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
<<<<<<< HEAD
            //UnityEditor.EditorApplication.isPaused = true;
            HelperFunctions.CorrectShapePosition(9, newSize);
            detector.transform.position = player.playerTransform.position;
=======

            HelperFunctions.CorrectShapePosition(9, newSize);
            detectorTransform.position = PlayerController.playerTransform.position;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
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
<<<<<<< HEAD
                player.SwitchShape(player.previousShape);
            }
        }

        public void ToggleDetector(bool activate)
=======
                PlayerController.SwitchShape(PlayerController.previousShape);
            }
        }

        public static void ToggleDetector(bool activate)
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        {
            dMain.enabled = activate;
            dBot.enabled = activate;
            dTop.enabled = activate;
        }
    }
}