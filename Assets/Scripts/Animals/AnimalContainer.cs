using UnityEngine;
using System.Collections;

namespace Morphie
{

    public class AnimalContainer : MonoBehaviour
    {
        private static IAnimalFunctions a1;
        private static IAnimalFunctions a2;
        private static IAnimalFunctions a3;
        private static IAnimalFunctions a4;
        private static IAnimalFunctions currentAnimal;

        public static void InitializeAnimals()
        {
            a1 = HelperFunctions.player.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal1") + "Functions")) as IAnimalFunctions;
            a2 = HelperFunctions.player.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal2") + "Functions")) as IAnimalFunctions;
            a3 = HelperFunctions.player.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal3") + "Functions")) as IAnimalFunctions;
            a4 = HelperFunctions.player.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal4") + "Functions")) as IAnimalFunctions;
            currentAnimal = a1;
        }

        //ANIMAL 1
        public static void Animal1Shape()
        {
            currentAnimal.LeaveShape();
            a1.ChangeShape();
            currentAnimal = a1;
        }

        public static void Animal1Update()
        {
            a1.UpdateFunctions();
        }

        public static void Animal1Ability()
        {
            a1.Ability();
        }

        //ANIMAL 2

        public static void Animal2Shape()
        {
            currentAnimal.LeaveShape();
            a2.ChangeShape();
            currentAnimal = a2;
        }

        public static void Animal2Update()
        {
            a2.UpdateFunctions();
        }

        public static void Animal2Ability()
        {
            a2.Ability();
        }

        //ANIMAL 3

        public static void Animal3Shape()
        {
            currentAnimal.LeaveShape();
            a3.ChangeShape();
            currentAnimal = a3;
        }

        public static void Animal3Update()
        {
            a3.UpdateFunctions();
        }

        public static void Animal3Ability()
        {
            a3.Ability();
        }

        //ANIMAL 4

        public static void Animal4Shape()
        {
            currentAnimal.LeaveShape();
            a4.ChangeShape();
            currentAnimal = a4;
        }

        public static void Animal4Update()
        {
            a4.UpdateFunctions();
        }

        public static void Animal4Ability()
        {
            a4.Ability();
        }

    }
}