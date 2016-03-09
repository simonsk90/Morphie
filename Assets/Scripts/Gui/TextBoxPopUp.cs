using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class TextBoxPopUp : MonoBehaviour
    {
        private static int lineHeight = 24;
        public Texture2D textBox;
        private static Rect rectangle;
        public static string textMessage;
        public static GameObject textPopUpGameObject;

        void Start()
        {
            float x;

            rectangle = new Rect(Screen.width * 0.5f, Screen.height * 0.5f, Screen.width * 0.8f, Screen.height * 0.2f);
            x = rectangle.position.x - rectangle.size.x * 0.5f;
            rectangle.position = new Vector2(x, rectangle.position.y);

            textPopUpGameObject = gameObject;
            textPopUpGameObject.SetActive(false);
             //UpdateTextBox("123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891");
        }

        void OnGUI()
        {
            GUI.DrawTexture(rectangle, textBox, ScaleMode.StretchToFill, true, 0.0F);
            GUI.Label(rectangle, textMessage);
        }

        public static void UpdateTextBox(string text)
        {
            bool stop = false;
            int maxLineChars = 50;
            int i = maxLineChars;
            textMessage = text;

            while(!stop)
            {
                if (textMessage.Length > i)
                {
                    if (i == maxLineChars)
                    {
                        textMessage = textMessage.Insert(i, "\n");
                    }
                    else
                    {
                        textMessage = textMessage.Insert(i + i/ maxLineChars - 1, "\n");
                    }
                    i += maxLineChars;
                }
                else
                {
                    stop = true;
                }    
            }
            rectangle.size = new Vector2(Screen.width * 0.8f, lineHeight * (i/maxLineChars));
            textPopUpGameObject.SetActive(true);
        }

    }
}