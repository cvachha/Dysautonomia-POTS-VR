using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouthScript : MonoBehaviour {
    public GameObject nadalolParticles;
    public GameObject bbManager;
    public bool canGive;
    // Use this for initialization
    void Start () {
        canGive = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "betaBlocker") && (canGive))
        {
            canGive = false;
            Debug.Log("Beta Blocker Given");

            bbManager.SendMessage("TakenBB");

        }
    }

    void NowCanGive()
    {
        canGive = true;
    }

    void NotGive()
    {
        canGive = false;
    }
}
