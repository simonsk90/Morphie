using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class CowFunctions : MonoBehaviour, IAnimalFunctions
    {
<<<<<<< HEAD

        private PlayerController player;
        public bool hitting = false;
        private BoxCollider2D pb; //playerBox
        public bool cooldown = false;

        void Awake()
        {
            player = HelperFunctions.player;
        }
=======
        public bool hitting = false;
        private bool cooldown = false;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67

        public void ChangeShape()
        {
            Vector2 newSize = new Vector2(1.08f, 0.65f);
<<<<<<< HEAD
            HelperFunctions.CorrectShapePosition(3, newSize);
=======
            //PlayerController.anim.CorrectShapePosition(3, newSize);
            Morphie.HelperFunctions.CorrectShapePosition(3, newSize);
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
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
<<<<<<< HEAD
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
=======
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

>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
}