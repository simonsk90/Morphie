using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {
	

	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player")
		{
			if (Application.loadedLevelName == "LevelOne")
			{
				PlayerPrefs.SetString("PandaUnlocked", "true");
				PlayerPrefs.SetString("CatUnlocked", "true");
				PlayerPrefs.SetString("TurtleUnlocked", "true");
				PlayerPrefs.SetString ("LevelTwoUnlocked", "true");
			}
			else if (Application.loadedLevelName == "LevelTwo")
			{
				PlayerPrefs.SetString("MonkeyUnlocked", "true");
				PlayerPrefs.SetString ("LevelThreeUnlocked", "true");
			}

			PlayerPrefs.SetFloat ("checkpointX", 0);
			PlayerPrefs.SetFloat ("checkpointY", 0);
			Application.LoadLevel("LevelSelecter");
		}	
	}

	void Start () {
		
	}

}
