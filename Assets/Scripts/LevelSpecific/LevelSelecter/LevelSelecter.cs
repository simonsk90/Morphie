using UnityEngine;
using System.Collections;

public class LevelSelecter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		if (PlayerPrefs.GetString(this.gameObject.name + "Unlocked") != "true" && this.gameObject.name != "LevelOne") 
		{
			GetComponent<Renderer>().enabled = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Application.LoadLevel("AnimalSelecter");
		PlayerPrefs.SetString ("animalSelecterLevel", this.gameObject.name);
	}
}
