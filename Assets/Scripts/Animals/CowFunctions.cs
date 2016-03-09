using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class CowFunctions : MonoBehaviour, IAnimalFunctions
    {

        private PlayerController player;
        public bool hitting = false;
        private BoxCollider2D pb; //playerBox
        public bool cooldown = false;

        void Awake()
        {
            player = HelperFunctions.player;
        }

        public void ChangeShape()
        {
            Vector2 newSize = new Vector2(1.08f, 0.65f);
            HelperFunctions.CorrectShapePosition(3, newSize);
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
                StartCoroutine(Hit());
            }
        }

        IEnumerator Hit()
        {
            float timer = 0f;
            hitting = true;
            player.anim.SetBool("isHitting", true);
            StartCoroutine(HelperFunctions.Cooldown(3f, x => cooldown = x));
            
            while (timer < 1f && player.anim.GetInteger("shape") == 3) //Look if we're in cow shape
            {
                timer += Time.deltaTime;
                yield return null;
            }

            hitting = false;
            player.anim.SetBool("isHitting", false);
        }

    }
}