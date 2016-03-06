using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class CowFunctions : MonoBehaviour, IAnimalFunctions
    {
        public bool hitting = false;
        private bool cooldown = false;

        public void ChangeShape()
        {
            Vector2 newSize = new Vector2(1.08f, 0.65f);
            //PlayerController.anim.CorrectShapePosition(3, newSize);
            Morphie.HelperFunctions.CorrectShapePosition(3, newSize);
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
            PlayerController.anim.SetBool("isHitting", true);
            StartCoroutine(HelperFunctions.Cooldown(3f, x => cooldown = x));

            while (timer < 1f && PlayerController.anim.GetInteger("shape") == 3) //Look if we're in cow shape
            {
                hitting = true;
                timer += Time.deltaTime;
                yield return null;
            }
            hitting = false;
            PlayerController.anim.SetBool("isHitting", false);
        }

    }

}