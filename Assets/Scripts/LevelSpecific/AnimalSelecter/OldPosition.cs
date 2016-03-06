using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class OldPosition : MonoBehaviour
    {
        public Vector2 oldPosition;
        public bool unlocked = false;
        // Use this for initialization

        void Awake()
        {
            oldPosition = this.transform.position;
        }

        void Start()
        {


            if (PlayerPrefs.GetString(this.gameObject.name + "Unlocked") == "true")
            {
                this.unlocked = true;
            }

            if (!unlocked)
            {
                this.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 1f);
            }
        }

        void Update()
        {

        }
    }
}