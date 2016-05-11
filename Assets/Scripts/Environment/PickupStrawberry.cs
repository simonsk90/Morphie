using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class PickupStrawberry : PickupSuperClass
    {

        public override void Effect()
        {
<<<<<<< HEAD
            player.stamina -= 30;
            if (player.stamina < 0)
                player.stamina = 0;
=======
            PlayerController.stamina -= 30;
            if (PlayerController.stamina < 0)
            {
                PlayerController.stamina = 0;
            }
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        }

    }
}