using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class PickupCheckpoint : PickupSuperClass
    { //Might have to reapply script to object, after renaming class/file.

        /**void OnTriggerEnter2D(Collider2D coll) 
        {
            if (coll.gameObject.tag == "Player")
            {
                PlayerPrefs.SetFloat ("checkpointX", transform.position.x);
                PlayerPrefs.SetFloat ("checkpointY", transform.position.y);
                player.stamina = 0;
                Destroy (this.gameObject);
            }
            
        }*/

        public override void Effect()
        {
            PlayerPrefs.SetFloat("checkpointX", transform.position.x);
            PlayerPrefs.SetFloat("checkpointY", transform.position.y);
            player.stamina = 0;
            Destroy(gameObject);
        }


        // Use this for initialization
        void Start()
        {
            //this.GetComponent<MeshRenderer>().enabled = false; //Make invisible

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}