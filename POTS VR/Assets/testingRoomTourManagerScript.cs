using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingRoomTourManagerScript : MonoBehaviour {

    public GameObject tiltTableTourManager;
    int currentExibhet;

	// Use this for initialization
	void Start () {
        StartRoomTour();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartRoomTour()
    {
        /*
         Start tilttable exibhit 
         Then ask the user if they want to do the tilttable expierence
         if they say yes do it, if not go to the next exibhet 
         then go to the next exibhet 
         repeat until the end of the exibhet

         */

        Debug.Log("Started tour");
        currentExibhet = 0;
        currentExibhet++;

        if (currentExibhet == 1)
        {
            //start tilttable tour

            //teleport player to tilt table area
            tiltTableTourManager.SendMessage("StartTour");
        }
        if (currentExibhet == 2)
        {
            //start next tour
            //teleport player to next area
            //nextObject.SendMessage("StartTour");
        }
 





    }

    void endedExibhet()
    {
        //stop the current exihbit
        currentExibhet++;
    }
}
