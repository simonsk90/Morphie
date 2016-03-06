using UnityEngine;
using System;
using System.Collections; 
using System.Collections.Generic;

namespace Morphie
{

    public static class HelperFunctions
    {
        private static BoxCollider2D playerBoxCollider = PlayerController.playerGameObject.GetComponent<BoxCollider2D>();
        //private PlayerController player;
        private static LayerMask mask = 1 << 4;
        public delegate void CallBack();

        public static bool CheckOnGround(GameObject obj)
        {
            BoxCollider2D objBoxCollider = obj.GetComponent<BoxCollider2D>();
            bool onGround = false;
            Vector2 startPoint = obj.transform.position;
            startPoint.x = objBoxCollider.bounds.min.x + 0.1f; // + 0.1f
            startPoint.y = objBoxCollider.bounds.min.y;
            RaycastHit2D hit = Physics2D.Raycast(startPoint, -Vector2.up, 0.020f, mask); //Maybe change distance if model is changed

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Ground")
                {
                    onGround = true;
                }
            }

            if (!onGround)
            {
                startPoint.x = objBoxCollider.bounds.max.x - 0.1f;
                hit = Physics2D.Raycast(startPoint, -Vector2.up, 0.020f, mask); //Maybe change distance if model is changed

                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Ground")
                    {
                        onGround = true;
                    }
                }
            }
            Debug.Log("ONG" + onGround);
            return onGround;
        }

        public static bool CheckOnCeiling()
        {
            bool onGround = false;
            Vector2 startPoint = PlayerController.playerTransform.position;
            startPoint.x = playerBoxCollider.bounds.min.x + 0.1f;
            startPoint.y = playerBoxCollider.bounds.max.y;
            RaycastHit2D hit = Physics2D.Raycast(startPoint, Vector2.up, 0.020f, mask); //Maybe change distance if model is changed

            if (hit.collider != null)
            {
                onGround = true;
            }

            else
            {
                startPoint.x = playerBoxCollider.bounds.max.x - 0.1f;
                hit = Physics2D.Raycast(startPoint, Vector2.up, 0.020f, mask); //Maybe change distance if model is changed

                if (hit.collider != null)
                {
                    onGround = true;
                }
            }
            Debug.Log("ONC" + onGround);
            return onGround;
        }

        public static void CorrectShapePosition(int shape, Vector2 newSize)
        {
            Vector2 newPosition = new Vector2();
            Bounds oldBounds = playerBoxCollider.bounds;
            PlayerController.anim.SetInteger("shape", shape);
            playerBoxCollider.size = newSize;

            //Correct Y-axis
            /*
            if (Mathf.Abs (player.collider2D.bounds.max.y - player.collider2D.bounds.min.y) < Mathf.Abs (oldBounds.max.y - oldBounds.min.y))
            {
                if (!player.reverseGravity)
                {
                    //player.transform.position = new Vector2(player.transform.position.x, 
                    //                                        player.transform.position.y - (player.collider2D.bounds.min.y - oldBounds.min.y));
                    newPosition.y = player.transform.position.y - (player.collider2D.bounds.min.y - oldBounds.min.y);
                }
                else
                {
                    //player.transform.position = new Vector2(player.transform.position.x, 
                    //                                        player.transform.position.y + (oldBounds.max.y - player.collider2D.bounds.max.y));
                    newPosition.y = player.transform.position.y + (oldBounds.max.y - player.collider2D.bounds.max.y);
                }

            }
            else
            {
                if (!player.reverseGravity)
                {
                    //player.transform.position = new Vector2(player.transform.position.x, 
                    //                                        player.transform.position.y + (oldBounds.min.y - player.collider2D.bounds.min.y));
                    newPosition.y = player.transform.position.y + (oldBounds.min.y - player.collider2D.bounds.min.y);
                }
                else
                {
                    //player.transform.position = new Vector2(player.transform.position.x, 
                    //                                        player.transform.position.y - (player.collider2D.bounds.max.y - oldBounds.max.y));
                    newPosition.y = player.transform.position.y + (player.collider2D.bounds.max.y - oldBounds.max.y); // -
                }
            }

            //Correct X-axis

                //player.transform.position = new Vector2(player.transform.position.x - (player.collider2D.bounds.max.x - oldBounds.max.x),
                //										player.transform.position.y);

            */

            if (PlayerController.reverseGravity)
            {
                newPosition.y = PlayerController.playerTransform.position.y - (playerBoxCollider.bounds.max.y - oldBounds.max.y);
            }
            else
            {
                newPosition.y = PlayerController.playerTransform.position.y + (playerBoxCollider.bounds.max.y - oldBounds.max.y);
            }

            newPosition.x = PlayerController.playerTransform.position.x - (playerBoxCollider.bounds.max.x - oldBounds.max.x);

            PlayerController.playerTransform.position = newPosition;

        }

        public static IEnumerator AddDelay(int seconds, CallBack cb)
        {
            //Debug.Log ("Delay");
            yield return new WaitForSeconds(seconds);

            cb();
        }

        public static void MakeDisappear(GameObject go) //Skal måske også fjerne go's children
                                                 // Skal måske bare bruge go.setActive = false ????
        {
            if (go.GetComponent<Renderer>() != null)
            {
                go.GetComponent<Renderer>().enabled = false;
            }
            /*if (go.collider2D != null)
            {
                go.collider2D.enabled = false;
            }*/

            foreach (Collider2D c in go.GetComponents<Collider2D>())
            {
                c.enabled = false;
            }
        }

        public static IEnumerator Cooldown(float duration, Action<bool> setCooldown)
        {
            setCooldown(true);

            float timer = 0f;
            while (timer < duration)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            setCooldown(false);
        }

        public static bool UnitWithinScreenSpace(Vector2 unitScreenPos)
        {
            if (
               (unitScreenPos.x < Screen.width && unitScreenPos.y < Screen.height) &&
               (unitScreenPos.x > 0f && unitScreenPos.y > 0f))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}