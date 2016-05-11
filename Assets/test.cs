using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class test : MonoBehaviour
    {

        private float speed = -1f;
        private Collider2D collider1;
        RaycastHit2D hit;
        private LayerMask mask = 1 << 4;

        void OnTriggerEnter2D(Collider2D coll)
        {
            collider1 = coll;
            if (coll.gameObject.name == "Ground")
            {
                if (this.GetComponent<Collider2D>().bounds.Intersects(coll.bounds))
                    speed = 0f;
            }
        }

        // Use this for initialization
        void Start()
        {

<<<<<<< HEAD
=======
        }
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67

        void FixedUpdate()
        {


<<<<<<< HEAD


        }

        void FixedUpdate()
        {
=======
        }

        // Update is called once per frame
        void Update()
        {

            if (collider1 != null)
                if (this.GetComponent<Collider2D>().bounds.Intersects(collider1.bounds))
                    speed = 0f;
            transform.Translate(Vector2.up * speed * Time.deltaTime);

>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67


        }

        // Update is called once per frame
        void Update()
        {

            if (collider1 != null)
                if (this.GetComponent<Collider2D>().bounds.Intersects(collider1.bounds))
                    speed = 0f;
            transform.Translate(Vector2.up * speed * Time.deltaTime);


<<<<<<< HEAD





=======
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        }
    }
}