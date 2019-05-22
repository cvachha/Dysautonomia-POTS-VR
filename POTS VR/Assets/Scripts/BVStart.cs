using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BVStart : MonoBehaviour {
    public GameObject bvManager;
    bool hasStarted;
    bool isDone;
    // Use this for initialization
    void Start()
    {
        hasStarted = false;
        isDone = false;

    }

    // Update is called once per frame
    void Update()
    {

    }



    void NowDone()
    {
        isDone = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Hand") && (!hasStarted || isDone))
        {
            Debug.Log("start bv");

            bvManager.SendMessage("StartBV");
        }
    }
}
