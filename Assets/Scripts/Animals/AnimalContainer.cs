using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Morphie
{

    public class AnimalContainer : MonoBehaviour
    {
<<<<<<< HEAD
        private static IAnimalFunctions a1, a2, a3, a4;
        private static IAnimalFunctions currentAnimal;
        public static List<int> animalsInUse = new List<int>();

        public static void InitializeAnimals()
        {
            a1 = HelperFunctions.player.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal1") + "Functions")) as IAnimalFunctions;
            a2 = HelperFunctions.player.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal2") + "Functions")) as IAnimalFunctions;
            a3 = HelperFunctions.player.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal3") + "Functions")) as IAnimalFunctions;
            a4 = HelperFunctions.player.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal4") + "Functions")) as IAnimalFunctions;
            currentAnimal = a1;

            animalsInUse.Clear();

            for (int i = 1; i < 5; i++)
            {
                switch (PlayerPrefs.GetString("animal" + i))
                {

                    case "Sheep":
                        animalsInUse.Add(1);
                        break;
                    case "Bird":
                        animalsInUse.Add(2);
                        break;
                    case "Cow":
                        animalsInUse.Add(3);
                        break;
                    case "Pig":
                        animalsInUse.Add(4);
                        break;
                    case "Monkey":
                        animalsInUse.Add(5);
                        break;
                    case "Panda":
                        animalsInUse.Add(6);
                        break;
                    case "Cat":
                        animalsInUse.Add(7);
                        break;
                    case "Turtle":
                        animalsInUse.Add(8);
                        break;
                    case "Dino":
                        animalsInUse.Add(9);
                        break;
                }
            }

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

=======


        private static IAnimalFunctions a1;
        private static IAnimalFunctions a2;
        private static IAnimalFunctions a3;
        private static IAnimalFunctions a4;
        private static IAnimalFunctions currentAnimal;


        //void Awake()
        //{
        //    a1 = PlayerController.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal1") + "Functions")) as IAnimalFunctions;

        //    a2 = PlayerController.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal2") + "Functions")) as IAnimalFunctions;
        //    a3 = PlayerController.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal3") + "Functions")) as IAnimalFunctions;
        //    a4 = PlayerController.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal4") + "Functions")) as IAnimalFunctions;

        //    currentAnimal = a1;
        //}

        public static void InitializeAnimals()
        {
            a1 = PlayerController.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal1") + "Functions")) as IAnimalFunctions;

            a2 = PlayerController.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal2") + "Functions")) as IAnimalFunctions;
            a3 = PlayerController.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal3") + "Functions")) as IAnimalFunctions;
            a4 = PlayerController.playerGameObject.AddComponent(System.Type.GetType("Morphie." + PlayerPrefs.GetString("animal4") + "Functions")) as IAnimalFunctions;

            currentAnimal = a1;
        }

        //void Start()
        //{

        //    Animal1Shape();
        //}

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

>>>>>>> cbc097dea2e2517c93ae48d526725ced03c64d67
    }
}