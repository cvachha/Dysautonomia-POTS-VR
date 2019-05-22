using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class handScript : MonoBehaviour {
    Scene m_Scene;
    bool tabletDisplayed;
    public GameObject tablet;

    public GameObject testingRoomTourManager;

    public GameObject tiltTableManager;

    public GameObject hallwayManager;
	// Use this for initialization
	void Start () {
        hallwayManager = GameObject.Find("hallwayManager");
        m_Scene = SceneManager.GetActiveScene();
        tablet = GameObject.Find("tablet");
        if (tablet.active)
        {
            tabletDisplayed = true;
        }
        else
        {
            tabletDisplayed = false;
        }
    }

    // Update is called once per frame
    void Update () {
        Debug.Log(Input.GetJoystickNames() + " is moved");

        if ((Input.GetKeyDown("JoystickButton8")))
        {

            Debug.Log("Left touchpad.");

            if (!tabletDisplayed)
            {
                tabletDisplayed = true;
                tablet.SetActive(true);
            }
            else
            {
                tabletDisplayed = false;

                tablet.SetActive(false);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("inside it");

        if (other.gameObject.tag == "officeDoor")
        {
            Debug.Log("Go to office");

            hallwayManager.SendMessage("GoToOffice");
        }

        if ((other.gameObject.tag == "labDoor"))
        {

            Debug.Log("Go to lab");

            hallwayManager.SendMessage("GoToLab");
        }

        if ((other.gameObject.tag == "infoDoor"))
        {
            Debug.Log("Go to info room");

            hallwayManager.SendMessage("GoToInfoRoom");
        }

        if ((other.gameObject.tag == "treatmentDoor"))
        {
            Debug.Log("Go to treatment room");

            hallwayManager.SendMessage("GoToTreatmentRoom");
        }

        if ((other.gameObject.tag == "hallwayDoor"))
        {
            Debug.Log("Go to hallway");

            UnityEngine.SceneManagement.SceneManager.LoadScene("hallwayScene");
        }

        //Tablet Interaction

        if ((other.gameObject.tag == "startTour") && (m_Scene.name == "testingRoomScene"))
        {
            Debug.Log("Start tour of testing room");
            testingRoomTourManager.SendMessage("StartTour");

            //Start tour of testing room

            /*
             Send a message to the testing room tour manager
             inside the manager, call the tilttable manager
             then call the other test's managers
             Also change the screen on the tablet
             */
        }

        if(other.gameObject.tag == "yesButtonTiltTable")
        {
            //send a message
            //tiltTableManager.SendMessage
        }

    }
}
