using UnityEngine;
using System.Collections;

<<<<<<< HEAD
namespace Morphie
{

    public class PigFunctions : MonoBehaviour, IAnimalFunctions
    {

        private PlayerController player;
        public GameObject detector;
=======
namespace Morphie {

    public class PigFunctions : MonoBehaviour, IAnimalFunctions {

        public static GameObject detector;
        private static BoxCollider2D detectorCollider;
        
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        private Vector2 newSize = new Vector2(0.73f, 0.35f);

        void Awake()
        {
<<<<<<< HEAD
            player = HelperFunctions.player;
            detector = Instantiate(Resources.Load("PigDetector")) as GameObject;

            detector.transform.parent = player.transform;
            detector.transform.localPosition = new Vector2(0f, 0f);
            detector.transform.localScale = new Vector2(player.transform.localScale.x, player.transform.localScale.y);

            detector.GetComponent<BoxCollider2D>().size = new Vector2(newSize.x + 0.25f, newSize.y - 0.01f);
            detector.GetComponent<Collider2D>().enabled = false;
        }

        void Start()
        {
=======
            detector = Instantiate(Resources.Load("PigDetector")) as GameObject;
            Transform detectorTransform = detector.transform;
            detectorCollider = detector.GetComponent<BoxCollider2D>();

            detectorTransform.parent = PlayerController.playerTransform;
            detectorTransform.localPosition = new Vector2(0f, 0f);
            detectorTransform.localScale = new Vector2(PlayerController.playerTransform.localScale.x, PlayerController.playerTransform.localScale.y);

            detectorCollider.size = new Vector2(newSize.x + 0.25f, newSize.y - 0.01f);
            detectorCollider.enabled = false;
        }

        void Start() {
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67

        }

        public void ChangeShape()
        {
            HelperFunctions.CorrectShapePosition(4, newSize);

<<<<<<< HEAD
            if (player.GetComponent<MonkeyFunctions>() != null)
            {
                if (!player.GetComponent<MonkeyFunctions>().reversing)
                {
                    detector.GetComponent<Collider2D>().enabled = true;
=======
            if (PlayerController.playerGameObject.GetComponent<MonkeyFunctions>() != null)
            {
                if (!MonkeyFunctions.reversing)
                {
                    detectorCollider.enabled = true;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
                }
            }
            else
            {
<<<<<<< HEAD
                detector.GetComponent<Collider2D>().enabled = true;
=======
                detectorCollider.enabled = true;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            }

        }

        public void LeaveShape()
        {
<<<<<<< HEAD
            detector.GetComponent<Collider2D>().enabled = false;
=======
            detectorCollider.enabled = false;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        }

        public void UpdateFunctions()
        {

        }

        public void Ability()
        {

        }
    }
}