using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class TurtleFunctions : MonoBehaviour, IAnimalFunctions
    {

<<<<<<< HEAD
        private PlayerController player;
=======
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
        private GameObject[] enemies;
        private bool cooldown = false;

        void Awake()
        {
<<<<<<< HEAD
            player = HelperFunctions.player;
=======
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }

        void Start()
        {

        }

        public void ChangeShape()
        {
            //player.anim.SetInteger("shape", 8);
            Vector2 newSize = new Vector2(0.8f, 0.8f);
            HelperFunctions.CorrectShapePosition(8, newSize);
        }

        public void LeaveShape()
        {

        }

        public void UpdateFunctions()
        {

        }

        public void Ability()
        {
            if (!cooldown)
            {
                StartCoroutine(SlowTime());
            }
        }

        IEnumerator SlowTime()
        {
            float timer = 0f;
            EnemyController ec;

            StartCoroutine(HelperFunctions.Cooldown(10f, x => cooldown = x));
            //StartCoroutine(Cooldown());

            foreach (GameObject enemy in enemies)
            {
                ec = enemy.GetComponent<EnemyController>();
                ec.speed = ec.speed * 0.4f;
            }

            while (timer < 8f)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            foreach (GameObject enemy in enemies)
            {
                ec = enemy.GetComponent<EnemyController>();
                ec.speed = ec.speed * 2.5f;
            }
        }
<<<<<<< HEAD
=======

        IEnumerator Cooldown()
        {
            cooldown = true;
            float timer = 0f;
            while (timer < 10f)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            cooldown = false;
        }
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
    }
}