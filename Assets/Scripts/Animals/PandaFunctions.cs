using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Morphie
{

    public class PandaFunctions : MonoBehaviour, IAnimalFunctions
    {
        private PlayerController player;
        public bool cooldown = false;

        void Awake()
        {
            player = HelperFunctions.player;
        }

        void Start()
        {
        }

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

            while (timer < 1.5f && player.anim.GetInteger("shape") == 6)
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
            player.playerRenderer.enabled = true;
            if (beginCast)
            {
                StartCoroutine(HelperFunctions.Cooldown(6, x => cooldown = x));
                player.anim.SetBool("isDisrupting", true);
                player.invulnerable = true;
                player.playerRigidBody.isKinematic = true;
                //player.collider2D.enabled = false;
            }

            while (timer < 0.5f && player.anim.GetInteger("shape") == 6)
            {
                //player.invulnerable = true;
                timer += Time.deltaTime;
                yield return null;
            }

            if (!beginCast)
            {
                Debug.Log("END CAST");

                if (player.anim.GetInteger("shape") != 9) //DINO
                {
                    player.invulnerable = false;
                }

                player.playerCollider.enabled = false;  //This shiet is necessary or play will get stock in environments not dying
                player.playerCollider.enabled = true;
                player.playerRigidBody.isKinematic = false;
                player.anim.SetBool("isDisrupting", false);
            }
            else
            {
                player.playerRenderer.enabled = false;
                StartCoroutine(Disrupt());
            }
        }
    }
}