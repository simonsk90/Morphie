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
            PlayerController.speed += 2f;

            while (timer < 3f)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            if (PlayerController.speed > 2f)
            {
                PlayerController.speed -= 2f;
            }
        }

    }
}