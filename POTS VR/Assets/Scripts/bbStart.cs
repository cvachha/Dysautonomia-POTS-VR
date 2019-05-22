using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbStart : MonoBehaviour {
    public GameObject bbManager;
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

    void OnCollisionEnter(Collision col)
    {
        /*
        if ((col.gameObject.tag == "Hand")&&(!hasStarted))
        {
            Debug.Log("start bb2");

            bbManager.SendMessage("StartBB");
        }
        */
    }

    void NowDone()
    {
        isDone = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Hand") && (!hasStarted || isDone))
        {
            Debug.Log("start bb2");

            bbManager.SendMessage("StartBB");
        }
    }
}
