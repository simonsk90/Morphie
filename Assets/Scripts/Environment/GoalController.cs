using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalController : MonoBehaviour {
	

	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player")
		{
			if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelOne"))
			{
				PlayerPrefs.SetString("PandaUnlocked", "true");
				PlayerPrefs.SetString("CatUnlocked", "true");
				PlayerPrefs.SetString("TurtleUnlocked", "true");
				PlayerPrefs.SetString ("LevelTwoUnlocked", "true");
			}
			else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelTwo"))
			{
				PlayerPrefs.SetString("MonkeyUnlocked", "true");
				PlayerPrefs.SetString ("LevelThreeUnlocked", "true");
			}

			PlayerPrefs.SetFloat ("checkpointX", 0);
			PlayerPrefs.SetFloat ("checkpointY", 0);
            //Application.LoadLevel("LevelSelecter");
            SceneManager.LoadScene("LevelSelecter");
		}	
	}

	void Start () {
		
	}

}
