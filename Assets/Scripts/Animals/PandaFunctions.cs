using UnityEngine;
using System.Collections; 
using System.Collections.Generic;

namespace Morphie
{

    public class PandaFunctions : MonoBehaviour, IAnimalFunctions
    {
        public bool cooldown = false;

        public void ChangeShape()
        {
            Vector2 newSize = new Vector2(0.78f, 0.81f);
            HelperFunctions.CorrectShapePosition(6, newSize);
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
                StartCoroutine(CastAnimation(true));
            }
        }

        IEnumerator Disrupt()
        {
            float timer = 0f;

            while (timer < 1.5f && PlayerController.anim.GetInteger("shape") == 6)
            {
                //player.invulnerable = true;
                timer += Time.deltaTime;
                yield return null;
            }
            StartCoroutine(CastAnimation(false));
        }

        IEnumerator CastAnimation(bool beginCast)
        {
            float timer = 0f;
            PlayerController.playerRenderer.enabled = true;
            if (beginCast)
            {
                StartCoroutine(HelperFunctions.Cooldown(6, x => cooldown = x));
                PlayerController.anim.SetBool("isDisrupting", true);
                PlayerController.invulnerable = true;
                PlayerController.playerRigidBody.isKinematic = true;
                //player.collider2D.enabled = false;
            }

            while (timer < 0.5f && PlayerController.anim.GetInteger("shape") == 6)
            {
                //player.invulnerable = true;
                timer += Time.deltaTime;
                yield return null;
            }

            if (!beginCast)
            {
                Debug.Log("END CAST");

                if (PlayerController.anim.GetInteger("shape") != 9) //DINO
                {
                    PlayerController.invulnerable = false;
                }

                PlayerController.playerBoxCollider.enabled = false;  //This shiet is necessary or play will get stock in environments not dying
                PlayerController.playerBoxCollider.enabled = true;
                PlayerController.playerRigidBody.isKinematic = false;
                PlayerController.anim.SetBool("isDisrupting", false);
            }
            else
            {
                PlayerController.playerRenderer.enabled = false;
                StartCoroutine(Disrupt());
            }


        }

        IEnumerator Cooldown()
        {
            cooldown = true;
            float timer = 0f;
            while (timer < 6f)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            cooldown = false;
        }
    }
}