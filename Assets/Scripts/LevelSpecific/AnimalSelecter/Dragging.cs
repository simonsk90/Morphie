using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Dragging : MonoBehaviour {
	private GameObject animal;
	private bool dragging = false;
	private Vector2 newPosition;
	private int mask = 1 << 4;
	private GameObject[] animals;
	//private int i = 0;
	
	//DO SO IT REMEMBERS THE LAST FOUR ANIMALS USED!!

	void Awake()
	{
		PlayerPrefs.SetString("SheepUnlocked", "true");
		PlayerPrefs.SetString("BirdUnlocked", "true");
		PlayerPrefs.SetString("CowUnlocked", "true");
		PlayerPrefs.SetString("PigUnlocked", "true");
		PlayerPrefs.SetString("DinoUnlocked", "true");
		//PlayerPrefs.SetString("TurtleUnlocked", "true");
		animals = GameObject.FindGameObjectsWithTag ("Animal");
	}

	void Start () {
		newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		PlaceLastUsedAnimals();

		//PlayerPrefs.SetString("animal1", null);
		//PlayerPrefs.SetString("animal2", null);
		//PlayerPrefs.SetString("animal3", null);
		//PlayerPrefs.SetString("animal4", null);


	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		newPosition.x = newPos.x;
		newPosition.y = newPos.y;

		if (Input.GetMouseButtonDown (0)) 
		{	
			RaycastHit2D hit = Physics2D.Raycast(newPosition, Vector2.up, 0.0001f);
			if (hit.collider != null)
			{
				if (hit.collider.tag == "Animal" && !dragging)
				{
					if (hit.collider.GetComponent<OldPosition>().unlocked)
					{
						animal = hit.collider.gameObject;
						dragging = true;
					}
				}
			}
		}

		if (dragging) 
		{
			animal.transform.position = newPosition;
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			if (dragging)
			{
				DoneDragging();
				dragging = false;
			}
		}

	}

	public void DoneDragging()
	{
		RaycastHit2D hit = Physics2D.Raycast(animal.transform.position, Vector2.up, 0.0000000001f, mask);
		if (hit.collider != null) 
		{
			if (hit.collider.tag == "GUI Box") 
			{
				switch (hit.collider.name)
				{
					case "GUI Box1":
						SwitchAnimals("animal1");
						break;
						
					case "GUI Box2":	
						SwitchAnimals("animal2");
						break;
						
					case "GUI Box3":
						SwitchAnimals("animal3");
						break;
						
					case "GUI Box4":
						SwitchAnimals("animal4");
						break;
				}	

				newPosition = hit.collider.transform.position;
				animal.transform.position = newPosition;
			}
		} 
		else 
		{
			animal.transform.position = animal.GetComponent<OldPosition>().oldPosition;
		}
	}

	private void SwitchAnimals(string animalNumber)
	{
		if (PlayerPrefs.GetString ("animal1") == this.animal.name)  //MAKE A LOOP FOR THIS SHIET MAYBE
		{
			PlayerPrefs.SetString("animal1", null);
		}
		if (PlayerPrefs.GetString ("animal2") == this.animal.name) 
		{
			PlayerPrefs.SetString("animal2", null);
		}
		if (PlayerPrefs.GetString ("animal3") == this.animal.name) 
		{
			PlayerPrefs.SetString("animal3", null);
		}
		if (PlayerPrefs.GetString ("animal4") == this.animal.name) 
		{
			PlayerPrefs.SetString("animal4", null);
		}
			
		foreach(GameObject ani in animals)
		{
			if (PlayerPrefs.GetString(animalNumber) == ani.name)
			{
				ani.transform.position = ani.GetComponent<OldPosition>().oldPosition;
			}
		}
		PlayerPrefs.SetString(animalNumber, this.animal.name);
	}

	private void PlaceLastUsedAnimals()
	{
		GameObject[] boxes;
		int i = 1;
		//boxes = GameObject.FindGameObjectsWithTag("GUI Box");
		boxes = GameObject.FindGameObjectsWithTag("GUI Box").OrderBy( go => go.name ).ToArray();
		foreach (GameObject box in boxes)
		{
			Debug.Log (box.name);
			this.animal = GameObject.Find(PlayerPrefs.GetString("animal" + i));
			Debug.Log(PlayerPrefs.GetString("animal" + i));
			Vector2 newPos = box.transform.position;
			//Debug.Log (this.animal.GetComponent<OldPosition>().oldPosition);
			if (this.animal != null)
			{
				this.animal.transform.position = newPos;
			}
			i++;
		}
	}

}




















