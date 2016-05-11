using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class PickupChili : PickupSuperClass
    {

        public override void Effect()
        {
            StartCoroutine(MakeHaste());
        }

        IEnumerator MakeHaste()
        {
            float timer = 0f;
<<<<<<< HEAD
            player.speed += 2f;
=======
            PlayerController.speed += 2f;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67

            while (timer < 3f)
            {
                timer += Time.deltaTime;
                yield return null;
            }
<<<<<<< HEAD
            if (player.speed > 2f)
            {
                player.speed -= 2f;
=======
            if (PlayerController.speed > 2f)
            {
                PlayerController.speed -= 2f;
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            }
        }

    }
}