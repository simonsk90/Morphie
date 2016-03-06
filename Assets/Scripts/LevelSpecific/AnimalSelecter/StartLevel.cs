using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Morphie
{

    public class StartLevel : MonoBehaviour
    {


        void OnMouseDown()
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("animalSelecterLevel"));
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}