using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class PickupStrawberry : PickupSuperClass
    {

        public override void Effect()
        {
            PlayerController.stamina -= 30;
            if (PlayerController.stamina < 0)
            {
                PlayerController.stamina = 0;
            }
        }

    }
}