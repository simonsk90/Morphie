using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class TurtleFunctions : MonoBehaviour, IAnimalFunctions
    {

        private PlayerController player;
        private GameObject[] enemies;
        private bool cooldown = false;

        void Awake()
        {
            player = HelperFunctions.player;
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
    }
}