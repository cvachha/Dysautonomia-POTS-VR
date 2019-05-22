using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hallwayManagerScript : MonoBehaviour {
    public GameObject officeDoor;
    public GameObject labDoor;
    public GameObject treatmentDoor;
    public GameObject infoDoor;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GoToOffice()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }

    void GoToLab()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("testingRoomScene");
    }

    void GoToInfoRoom()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("informationalRoom");
    }

    void GoToTreatmentRoom()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("treatmentroom");
    }

}
