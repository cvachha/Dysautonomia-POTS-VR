using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaBlockerManagerScript : MonoBehaviour {
    public GameObject epiParticles;
    public GameObject bbParticles;
    public GameObject heart;
    public GameObject startButton;
    public GameObject mouth;
    public GameObject haloPillBottle;

    public GameObject epiParticleOne;
    public GameObject epiParticleTwo;
    public GameObject epiParticleThree;
    public GameObject epiParticleFour;
    public GameObject epiParticleFive;

    public GameObject bbParticleOne;
    public GameObject bbParticleTwo;
    public GameObject bbParticleThree;
    public GameObject bbParticleFour;
    public GameObject bbParticleFive;

    bool hasTakenBB;

    // Use this for initialization
    void Start () {
        hasTakenBB = false;
        haloPillBottle.SetActive(false);
        heart.GetComponent<Animator>().speed = 0.0f;

    }

    // Update is called once per frame
    void Update () {
		
	}

    void StartBB()
    {
        Debug.Log("start bb");
        heart.GetComponent<Animator>().speed = 1.0f;

        epiParticles.GetComponent<ParticleSystem>().Play();
        heart.GetComponent<Animator>().SetBool("hasEpi", true);
        StartCoroutine("waitShowEpiReceptors", 6);

    }

    IEnumerator waitShowEpiReceptors(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        //show pill bottle glow
        haloPillBottle.SetActive(true);

        epiParticleOne.GetComponent<Animator>().SetBool("showEpi",true);
        epiParticleTwo.GetComponent<Animator>().SetBool("showEpi", true);
        epiParticleThree.GetComponent<Animator>().SetBool("showEpi", true);
        epiParticleFour.GetComponent<Animator>().SetBool("showEpi", true);
        epiParticleFive.GetComponent<Animator>().SetBool("showEpi", true);
        mouth.SendMessage("NowCanGive");
        //play animation of epi particles fading in to the receptors
    }

    IEnumerator waitShowBBReceptors(int waitTime)
    {
        heart.GetComponent<Animator>().SetBool("hasEpi", false);
        heart.GetComponent<Animator>().SetBool("hasBB", true);

        yield return new WaitForSeconds(waitTime);
        bbParticleOne.GetComponent<Animator>().SetBool("showBB", true);
        bbParticleTwo.GetComponent<Animator>().SetBool("showBB", true);
        bbParticleThree.GetComponent<Animator>().SetBool("showBB", true);
        bbParticleFour.GetComponent<Animator>().SetBool("showBB", true);
        bbParticleFive.GetComponent<Animator>().SetBool("showBB", true);
        //play animation of bb particles fading in to the receptors

    }

    void TakenBB()
    {
        //  epiParticles.GetComponent<ParticleSystem>().Stop();
        if (!hasTakenBB)
        {
            haloPillBottle.SetActive(false);
            hasTakenBB = true;

            bbParticles.GetComponent<ParticleSystem>().Play();
            StartCoroutine("waitHideEpiReceptors", 3);
            StartCoroutine("waitShowBBReceptors", 4);
            StartCoroutine("DoneWithBB", 15);

        }

    }

    IEnumerator DoneWithBB(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ResetBB();
    }

    void ResetBB()
    {
        epiParticles.GetComponent<ParticleSystem>().Stop();
        bbParticles.GetComponent<ParticleSystem>().Stop();
        startButton.SendMessage("NowDone");
        heart.GetComponent<Animator>().SetBool("hasEpi", false);
        StartCoroutine("waitHideBBReceptors", 4);
        heart.GetComponent<Animator>().speed = 0.0f;


    }

    IEnumerator waitHideEpiReceptors(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        epiParticleOne.GetComponent<Animator>().SetBool("showEpi", false);
        epiParticleTwo.GetComponent<Animator>().SetBool("showEpi", false);
        epiParticleThree.GetComponent<Animator>().SetBool("showEpi", false);
        epiParticleFour.GetComponent<Animator>().SetBool("showEpi", false);
        epiParticleFive.GetComponent<Animator>().SetBool("showEpi", false);

        epiParticleOne.GetComponent<Animator>().SetBool("hideEpi", true);
        epiParticleTwo.GetComponent<Animator>().SetBool("hideEpi", true);
        epiParticleThree.GetComponent<Animator>().SetBool("hideEpi", true);
        epiParticleFour.GetComponent<Animator>().SetBool("hideEpi", true);
        epiParticleFive.GetComponent<Animator>().SetBool("hideEpi", true);

        //play animation of epi particles fading in to the receptors
    }

    IEnumerator waitHideBBReceptors(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        bbParticleOne.GetComponent<Animator>().SetBool("showBB", false);
        bbParticleTwo.GetComponent<Animator>().SetBool("showBB", false);
        bbParticleThree.GetComponent<Animator>().SetBool("showBB", false);
        bbParticleFour.GetComponent<Animator>().SetBool("showBB", false);
        bbParticleFive.GetComponent<Animator>().SetBool("showBB", false);

        bbParticleOne.GetComponent<Animator>().SetBool("hideBB", true);
        bbParticleTwo.GetComponent<Animator>().SetBool("hideBB", true);
        bbParticleThree.GetComponent<Animator>().SetBool("hideBB", true);
        bbParticleFour.GetComponent<Animator>().SetBool("hideBB", true);
        bbParticleFive.GetComponent<Animator>().SetBool("hideBB", true);

        //play animation of epi particles fading in to the receptors
    }
}
