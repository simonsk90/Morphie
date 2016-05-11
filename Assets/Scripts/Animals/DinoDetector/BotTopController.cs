using UnityEngine;
using System.Collections;
using Morphie;

<<<<<<< HEAD
namespace Morphie
{

    public class BotTopController : MonoBehaviour
    {
=======
namespace Morphie {

    public class BotTopController : MonoBehaviour {

>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.tag != "Ground" && coll.tag != "Rock")
            {
<<<<<<< HEAD
                //HelperFunctions.MakeDisappear(coll.gameObject);
                coll.gameObject.SetActive(false);
=======
                //player.helperFunctions.MakeDisappear(coll.gameObject);
                HelperFunctions.MakeDisappear(coll.gameObject);
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            }
        }
    }
}