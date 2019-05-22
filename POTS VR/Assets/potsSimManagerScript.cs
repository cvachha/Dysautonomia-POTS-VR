using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potsSimManagerScript : MonoBehaviour {
    public GameObject particlePerson;
    public GameObject player;
   // public PostProcessingProfile postProcProf;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartPotsSim()
    {
        //hide person on bed
        particlePerson.SetActive(false);

        //teleport person to bed
        player.transform.position= new Vector3(0.92f,0.11f,1.34f);

        //add photo filters
     //   var dof = postProcProf.depthOfField.settings;

    //change filters based on player height

    //increase heartbeat

    //play sound heartbeat
}
}
