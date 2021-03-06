using UnityEngine;
using System.Collections; 
using System.Collections.Generic;

namespace Morphie
{

    public class ObjectsController : MonoBehaviour
    {

        public static List<GameObject> activeObjects = new List<GameObject>();
        public static List<GameObject> inactiveObjects = new List<GameObject>();
        private static List<GameObject> passedObjects = new List<GameObject>();
        private static List<GameObject> incomingObjects = new List<GameObject>();
        private Camera cam;

        void Awake()
        {
            foreach (GameObject obj in FindObjectsOfType(typeof(GameObject)))  //Gør måske alt dette under awake()
            {
                if (obj.tag != "Untagged" && obj.tag != "Player" && obj.tag != "MainCamera")
                {
                    activeObjects.Add(obj);
                }
            }

            activeObjects.Sort(delegate (GameObject g1, GameObject g2)
            {
                return (g1.transform.position.x).CompareTo(g2.transform.position.x);
            });
        }

        // Use this for initialization
        void Start()
        {
            cam = CameraController.cam;

            DeactivatePassedObjects();

            //Debug.Log(player.cam.cam.pixelWidth);
            //Debug.Log(cam.WorldToScreenPoint(player.transform.position));

            foreach (GameObject go in activeObjects) //Deactivate inc objects
            {
                if (cam.WorldToScreenPoint(go.transform.position).x > cam.pixelWidth * 2f)
                {
                    incomingObjects.Add(go);
                    go.SetActive(false);
                }
            }

            ActivateIncomingObjects();

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void ActivateIncomingObjects()
        {
            for (int x = 0; x < incomingObjects.Count; x++)
            {
                GameObject go = incomingObjects[x];

                if (cam.WorldToScreenPoint(go.transform.position).x < cam.pixelWidth * 2f)
                {
                    go.SetActive(true);
                    activeObjects.Add(go);
                    incomingObjects.Remove(go);
                    x--;
                }
                else
                {
                    break;
                }
            }

            StartCoroutine(HelperFunctions.AddDelay(2, ActivateIncomingObjects));
        }

        public void DeactivatePassedObjects() //FIND UD AF OM DET ER MERE EFFEKTIVT AT BRUGE ITERATOR ELLER STANDARD LOOP
        {
            foreach (GameObject go in GetPassedObjects())
            {
                go.SetActive(false);
            }

            StartCoroutine(HelperFunctions.AddDelay(2, DeactivatePassedObjects));
        }

        public IEnumerable<GameObject> GetPassedObjects()
        {
            if (PlayerController.playerGameObject.GetComponent<MonkeyFunctions>() != null)
            {
                if (!MonkeyFunctions.reversing)
                {
                    foreach (GameObject go in activeObjects)
                    {
                        if (cam.WorldToScreenPoint(go.transform.position).x < -20f)
                        {
                            passedObjects.Add(go);
                            yield return go;
                        }

                        else
                        {
                            break;
                        }
                    }

                    foreach (GameObject go in passedObjects)
                    {
                        activeObjects.Remove(go);
                        inactiveObjects.Add(go);
                    }

                    passedObjects.Clear();
                }
            }
            else
            {
                //return null;
            }
        }
    }
}