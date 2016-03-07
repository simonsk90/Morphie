using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class PigFunctions : MonoBehaviour, IAnimalFunctions
    {

        private PlayerController player;
        public GameObject detector;
        private Vector2 newSize = new Vector2(0.73f, 0.35f);

        void Awake()
        {
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

        }

        public void ChangeShape()
        {
            HelperFunctions.CorrectShapePosition(4, newSize);

            if (player.GetComponent<MonkeyFunctions>() != null)
            {
                if (!player.GetComponent<MonkeyFunctions>().reversing)
                {
                    detector.GetComponent<Collider2D>().enabled = true;
                }
            }
            else
            {
                detector.GetComponent<Collider2D>().enabled = true;
            }

        }

        public void LeaveShape()
        {
            detector.GetComponent<Collider2D>().enabled = false;
        }

        public void UpdateFunctions()
        {

        }

        public void Ability()
        {

        }
    }
}