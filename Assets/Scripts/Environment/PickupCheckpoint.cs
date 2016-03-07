using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class PickupCheckpoint : PickupSuperClass
    { //Might have to reapply script to object, after renaming class/file.

        public override void Effect()
        {
            PlayerPrefs.SetFloat("checkpointX", transform.position.x);
            PlayerPrefs.SetFloat("checkpointY", transform.position.y);
            player.stamina = 0;
            Destroy(gameObject);
        }

        void onEnable()
        {
            GetComponent<MeshRenderer>().enabled = false; //Make invisible
        }
    }
}