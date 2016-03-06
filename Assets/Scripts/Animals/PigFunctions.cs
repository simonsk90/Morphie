using UnityEngine;
using System.Collections;

namespace Morphie {

    public class PigFunctions : MonoBehaviour, IAnimalFunctions {

        public static GameObject detector;
        private static BoxCollider2D detectorCollider;
        
        private Vector2 newSize = new Vector2(0.73f, 0.35f);

        void Awake()
        {
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

        }

        public void ChangeShape()
        {
            HelperFunctions.CorrectShapePosition(4, newSize);

            if (PlayerController.playerGameObject.GetComponent<MonkeyFunctions>() != null)
            {
                if (!MonkeyFunctions.reversing)
                {
                    detectorCollider.enabled = true;
                }
            }
            else
            {
                detectorCollider.enabled = true;
            }

        }

        public void LeaveShape()
        {
            detectorCollider.enabled = false;
        }

        public void UpdateFunctions()
        {

        }

        public void Ability()
        {

        }
    }
}