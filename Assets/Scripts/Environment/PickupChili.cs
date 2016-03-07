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
            player.speed += 2f;

            while (timer < 3f)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            if (player.speed > 2f)
            {
                player.speed -= 2f;
            }
        }

    }
}