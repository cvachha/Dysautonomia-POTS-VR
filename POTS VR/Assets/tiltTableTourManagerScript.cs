using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiltTableTourManagerScript : MonoBehaviour {

    public GameObject tablePerson;

    public GameObject tiltingTable;

    public GameObject computerDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartTour() {

        Debug.Log("tilt table tour started");

        //make human visible
        tablePerson.SetActive(true);
        StartCoroutine(moveTilttableUp(2.0f));

        //show on screen video explanation and graphs and play audio





    }

    IEnumerator moveTilttableUp(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        //play animation of tilt table going up
        tiltingTable.GetComponent<Animator>().SetBool("isUp", true);
        StartCoroutine(moveTilttableUp(2.0f));

    }

    IEnumerator askForExperience(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("asking player");
        //ask user if they want to do the expierence on tablet
        //play the notification sound and rumble controllers and play prompt
        //send a messsage to run a function on the tablet to give a prompt of 2 buttons

    }

    void EndTour()
    {
        //end and move tillt table back down and make human disappear
        tiltingTable.GetComponent<Animator>().SetBool("isUp", false);
        tablePerson.SetActive(false);

    }

    void RunTiltTableExpierence()
    {
        //hide human
        tablePerson.SetActive(false);
        //move person down
        tiltingTable.GetComponent<Animator>().SetBool("isUp", false);

        //Teleport player to that configuration

        //show different video with different audio

        
    }

    void DontRunTiltTableExpierence()
    {
        //continue on with experience
        //play a video or end the expierence
        EndTour();
    }

    IEnumerator waitToStopTiltExperience(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        DontRunTiltTableExpierence();

    }
}

