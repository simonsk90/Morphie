using UnityEngine;
using System.Collections;

namespace Morphie
{
    public class DetectorController : MonoBehaviour
    {
        void OnTriggerStay2D(Collider2D coll)
        {
            //HelperFunctions.MakeDisappear(coll.gameObject);
            coll.gameObject.SetActive(false);
        }
    }
}