using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BVManagerScript : MonoBehaviour
{
    //particles of human resting
    public GameObject p_sleep_foot_l;
    public GameObject p_sleep_foot_r;
    public GameObject p_sleep_body;

    public GameObject heart_sleeping;
    public GameObject heart_pots_standing;
    public GameObject heart_healthy_standing;

    public GameObject sittingHumanBV;
    public GameObject sleepingHumanBV;
    public GameObject standingHealthyHumanBV;
    public GameObject standingPotsHumanBV;


    public GameObject bloodCellParticles;
    //public GameObject bloodCellParticles2;

    //
    public GameObject bvSoftMuscle;
    public GameObject bvScreen;
    public Material blankScreen;

    public Material bvMat;

    public GameObject CompareGroup;
    // Use this for initialization
    void Start()
    {
        heart_sleeping.GetComponent<Animator>().speed = 0.0f;
        bvScreen.GetComponent<Renderer>().material = blankScreen;


    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartBV()
    {
        Debug.Log("start bv");

        StartParticlesOfSleeping(true);
        heart_sleeping.GetComponent<Animator>().speed = 1.0f;
        bloodCellParticles.GetComponent<ParticleSystem>().Play();
        bvScreen.GetComponent<Renderer>().material = bvMat;
        bloodCellParticles.GetComponent<ParticleSystem>().startSpeed = 0.65f;
        bloodCellParticles.GetComponent<ParticleSystem>().emissionRate = 2.6f;
        // heart_sleeping.GetComponent<Animator>().SetBool("isSleeping", true);
        StartCoroutine("StandUp", 7);
    }

    void StartParticlesOfSleeping(bool shouldPlay)
    {
        if (shouldPlay)
        {
            p_sleep_foot_l.GetComponent<ParticleSystem>().Play();
            p_sleep_foot_r.GetComponent<ParticleSystem>().Play();
            p_sleep_body.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            p_sleep_foot_l.GetComponent<ParticleSystem>().Stop();
            p_sleep_foot_r.GetComponent<ParticleSystem>().Stop();
            p_sleep_body.GetComponent<ParticleSystem>().Stop();
        }
    }

    IEnumerator StandUp(int waitTime)
    {
        Debug.Log("Now stand Up");

        yield return new WaitForSeconds(waitTime);
        AppearStandingHealthyBV(true);
        heart_healthy_standing.GetComponent<Animator>().speed = 1.3f;

        AppearSleepingBV(false);
        StartCoroutine("ContractBV", 3);
        StartCoroutine("ShowPotsResting", 7);


    }

    IEnumerator ContractBV(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("BV Contracted");
        bloodCellParticles.GetComponent<ParticleSystem>().startSpeed = 2.3f;
        bloodCellParticles.GetComponent<ParticleSystem>().emissionRate = 4.5f;

        bvSoftMuscle.GetComponent<Animator>().SetBool("contract", true);

    }

    IEnumerator ExpandBV(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("BV Expanded");
        bloodCellParticles.GetComponent<ParticleSystem>().startSpeed = 0.65f;
        bloodCellParticles.GetComponent<ParticleSystem>().emissionRate = 2.3f;

        bvSoftMuscle.GetComponent<Animator>().SetBool("expand", true);

    }
    void AppearSleepingBV(bool show)
    {
        sleepingHumanBV.SetActive(show);
        sittingHumanBV.SetActive(show);
    }
    void AppearCompareGroup(bool show)
    {
        CompareGroup.SetActive(show);
    }
    void AppearStandingHealthyBV(bool show)
    {
        standingHealthyHumanBV.SetActive(show);
    }

    void AppearStandingPotsBV(bool show)
    {
        standingPotsHumanBV.SetActive(show);
    }

    IEnumerator ShowPotsResting(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        bvSoftMuscle.GetComponent<Animator>().SetBool("contract", false);

        Debug.Log("Show POTS Resting");
        //expand bv
        StartCoroutine("ExpandBV", 0.2f);
        StartParticlesOfSleeping(true);
        heart_sleeping.GetComponent<Animator>().speed = 1.2f;

        //hide standing person
        AppearStandingHealthyBV(false);

        //show bed and chair
        AppearSleepingBV(true);

        //start courtintine for stand pots person
        StartCoroutine("ShowPotsStanding", 5);

    }

    IEnumerator ShowPotsStanding(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //hide bed and chair
        AppearSleepingBV(false);

        //show pots person standing
        AppearStandingPotsBV(true);
        heart_pots_standing.GetComponent<Animator>().speed = 5.0f;

        //change particles speed and emmission rate of blood cells
        bloodCellParticles.GetComponent<ParticleSystem>().startSpeed = 0.3f;
        bloodCellParticles.GetComponent<ParticleSystem>().startLifetime = 4.2f;
        //if possible show red feet animation

        //Now show comparison for next one
        StartCoroutine("ShowComparing", 5);






    }
    IEnumerator ResetBV(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        bvScreen.GetComponent<Renderer>().material = blankScreen;
        bvSoftMuscle.GetComponent<Animator>().SetBool("contract", false);
        bvSoftMuscle.GetComponent<Animator>().SetBool("expand", false);

        AppearSleepingBV(true);
        AppearCompareGroup(false);
        bloodCellParticles.GetComponent<ParticleSystem>().Stop();
        heart_sleeping.GetComponent<Animator>().speed = 0.0f;
    }

    IEnumerator ShowComparing(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        heart_healthy_standing.GetComponent<Animator>().speed = 1.3f;

        AppearCompareGroup(true);

        //hide pots standing
        AppearStandingPotsBV(false);

        //make blood vessels for first display show normal person
        bvSoftMuscle.GetComponent<Animator>().SetBool("expand", false);
        StartCoroutine("ContractBV", 1);



        //now done and then reset 
        StartCoroutine("ResetBV", 15);



    }

}
