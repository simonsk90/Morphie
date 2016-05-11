using UnityEngine;
<<<<<<< HEAD
using System.Collections;
=======
using System.Collections; 
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67

namespace Morphie
{
    public class DetectorController : MonoBehaviour
    {
        void OnTriggerStay2D(Collider2D coll)
        {
<<<<<<< HEAD
            //HelperFunctions.MakeDisappear(coll.gameObject);
            coll.gameObject.SetActive(false);
        }
    }
}
=======
            HelperFunctions.MakeDisappear(coll.gameObject);
        }
    }
}
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
