using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potsSimStartButton : MonoBehaviour {
    public GameObject postSimManager;
    bool hasStarted;
    bool isDone;
	// Use this for initialization
	void Start () {
        hasStarted = false;
        isDone = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Hand") && (!hasStarted || isDone))
        {
            Debug.Log("start pots simualtion");

            postSimManager.SendMessage("StartPotsSim");
        }
    }
}
