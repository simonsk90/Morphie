using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class BotTopController : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.tag != "Ground" && coll.tag != "Rock")
            {
                //HelperFunctions.MakeDisappear(coll.gameObject);
                coll.gameObject.SetActive(false);
            }
        }
    }
}