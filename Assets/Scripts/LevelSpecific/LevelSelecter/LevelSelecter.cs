using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Morphie
{
<<<<<<< HEAD

=======
>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
    public class LevelSelecter : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

            if (PlayerPrefs.GetString(this.gameObject.name + "Unlocked") != "true" && this.gameObject.name != "LevelOne")
            {
                GetComponent<Renderer>().enabled = false;
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnMouseDown()
        {
            SceneManager.LoadScene("AnimalSelecter");
            PlayerPrefs.SetString("animalSelecterLevel", this.gameObject.name);
        }
    }
}