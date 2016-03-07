using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Morphie
{

    public class Progress : MonoBehaviour
    { // Rename properly

        public Vector2 pos = new Vector2(20, 40);
        public Vector2 size = new Vector2(100, 20);
        public Texture2D emptyTex;
        public Texture2D fullTex;
        public Texture2D guiTex;
        private PlayerController player;
        private bool mouseDown = false;


        void Start()
        {
            // find the current instance of the player script:
            player = GameObject.Find("Stickman").GetComponent<PlayerController>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseDown = true;
            }

            if (Input.GetKeyDown("1"))
            {
                if (player.shape == 1)
                {
                    player.UseAbility();
                }
                else
                {
                    player.SwitchShape(1);
                }
            }

            if (Input.GetKeyDown("2"))
            {
                if (player.shape == 2)
                {
                    player.UseAbility();
                }
                else
                {
                    player.SwitchShape(2);
                }
            }

            if (Input.GetKeyDown("3"))
            {
                if (player.shape == 3)
                {
                    player.UseAbility();
                }
                else
                {
                    player.SwitchShape(3);
                }
            }

            if (Input.GetKeyDown("4"))
            {
                if (player.shape == 4)
                {
                    player.UseAbility();
                }
                else
                {
                    player.SwitchShape(4);
                }
            }

            if (Input.GetKeyDown("p"))
            {
                PlayerPrefs.DeleteAll();
            }

            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            if (Input.GetKeyDown(KeyCode.K))
                SceneManager.LoadScene("AnimalSelecter");

            if (Input.GetKeyDown(KeyCode.L))
                SceneManager.LoadScene("LevelSelecter");

            if (Input.GetKeyDown(KeyCode.U))
            {
                PlayerPrefs.SetString("PandaUnlocked", "true");
                PlayerPrefs.SetString("CatUnlocked", "true");
                PlayerPrefs.SetString("TurtleUnlocked", "true");
                PlayerPrefs.SetString("LevelTwoUnlocked", "true");
                PlayerPrefs.SetString("MonkeyUnlocked", "true");
                PlayerPrefs.SetString("LevelThreeUnlocked", "true");
            }
        }

        void OnGUI()
        {
            string lives = player.lives.ToString();

            GUI.TextField(new Rect(0, 0, 20, 20), lives);

            //draw the background STAMINA BEGIN
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);
            //draw the filled-in part:
            GUI.BeginGroup(new Rect(0, 0, size.x - player.stamina, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
            GUI.EndGroup();
            GUI.EndGroup();
            //STAMINA END

            //MAIN GUI BEGIN
            GUI.BeginGroup(new Rect(0, Screen.height - (Screen.height * 0.2f), Screen.width, Screen.height));
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), guiTex);

            Rect r1 = new Rect(0, 0, 100, 100);
            GUI.Button(r1, "1");

            if (mouseDown == true && r1.Contains(Event.current.mousePosition))
            {
                if (player.shape == 1)
                {
                    player.UseAbility();
                }
                else
                {
                    player.SwitchShape(1);
                }
            }

            Rect r2 = new Rect(150, 0, 100, 100);
            GUI.Button(r2, "2");
            if (mouseDown == true && r2.Contains(Event.current.mousePosition))
            {
                if (player.shape == 2)
                {
                    player.UseAbility();
                }
                else
                {
                    player.SwitchShape(2);
                }
            }

            Rect r3 = new Rect(300, 0, 100, 100);
            GUI.Button(r3, "3");
            if (mouseDown == true && r3.Contains(Event.current.mousePosition))
            {
                if (player.shape == 3)
                {
                    player.UseAbility();
                }
                else
                {
                    player.SwitchShape(3);
                }
            }

            Rect r4 = new Rect(450, 0, 100, 100);
            GUI.Button(r4, "4");
            if (mouseDown == true && r4.Contains(Event.current.mousePosition))
            {
                if (player.shape == 4)
                {
                    player.UseAbility();
                }
                else
                {
                    player.SwitchShape(4);
                }
            }

            GUI.EndGroup();
            mouseDown = false;
        }

    }
}