using UnityEngine;
using System.Collections;

public class StartLevel : MonoBehaviour {


	void OnMouseDown() {
		Application.LoadLevel(PlayerPrefs.GetString("animalSelecterLevel"));
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
