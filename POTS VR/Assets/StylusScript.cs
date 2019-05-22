using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StylusScript : MonoBehaviour {
    Scene m_Scene;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "drOfficeButton")
        {
            Debug.Log("go to menu scene");
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }

        if (other.gameObject.tag == "treatmentRoomButton")
        {
            Debug.Log("go to treatment scene");
            UnityEngine.SceneManagement.SceneManager.LoadScene("treatmentroom");
        }

        if (other.gameObject.tag == "testingRoomButton")
        {
            Debug.Log("go to testing scene");
            UnityEngine.SceneManagement.SceneManager.LoadScene("testingRoomScene");
        }

        if (other.gameObject.tag == "InfoRoomButton")
        {
            Debug.Log("go to info room scene");
            UnityEngine.SceneManagement.SceneManager.LoadScene("InfoRoomButton");
        }
    }
}
