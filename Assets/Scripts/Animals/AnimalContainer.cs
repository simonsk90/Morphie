using UnityEngine;
using System.Collections;

public class AnimalContainer : MonoBehaviour {
	

	private IAnimalFunctions a1;
	private IAnimalFunctions a2;
	private IAnimalFunctions a3;
	private IAnimalFunctions a4;
	private IAnimalFunctions currentAnimal;


    void Awake()
    {
        a1 = gameObject.AddComponent(System.Type.GetType(PlayerPrefs.GetString("animal1") + "Functions")) as IAnimalFunctions;
        a2 = gameObject.AddComponent(System.Type.GetType(PlayerPrefs.GetString("animal2") + "Functions")) as IAnimalFunctions;
        a3 = gameObject.AddComponent(System.Type.GetType(PlayerPrefs.GetString("animal3") + "Functions")) as IAnimalFunctions;
        a4 = gameObject.AddComponent(System.Type.GetType(PlayerPrefs.GetString("animal4") + "Functions")) as IAnimalFunctions;

        currentAnimal = a1;
    }

    void Start () {

		Animal1Shape();
	}

	//ANIMAL 1

	public void Animal1Shape()
	{
		currentAnimal.LeaveShape();
		a1.ChangeShape();
		currentAnimal = a1;
	}

	public void Animal1Update()
	{
		a1.UpdateFunctions();
	}

	public void Animal1Ability()
	{
		a1.Ability();
	}

	//ANIMAL 2

	public void Animal2Shape()
	{
		currentAnimal.LeaveShape();
		a2.ChangeShape();
		currentAnimal = a2;
	}

	public void Animal2Update()
	{
		a2.UpdateFunctions();
	}

	public void Animal2Ability()
	{
		a2.Ability();
	}

	//ANIMAL 3

	public void Animal3Shape()
	{
		currentAnimal.LeaveShape();
		a3.ChangeShape();
		currentAnimal = a3;
	}
	
	public void Animal3Update()
	{
		a3.UpdateFunctions();
	}
	
	public void Animal3Ability()
	{
		a3.Ability();
	}

	//ANIMAL 4

	public void Animal4Shape()
	{
		currentAnimal.LeaveShape();
		a4.ChangeShape();
		currentAnimal = a4;
	}
	
	public void Animal4Update()
	{
		a4.UpdateFunctions();
	}
	
	public void Animal4Ability()
	{
		a4.Ability();
	}

}
