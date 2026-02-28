using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsController : MonoBehaviour
{
    public GameObject[] cave;
    public GameObject[] tree;
    public GameObject[] house;

    public AudioSource stepsSound;
    public AudioClip[] stepsClips;
    public float stepTimeL;
    public float stepTimeR;

    public void CaveSteps()
    {
        StartCoroutine(CaveSteper());
    }
    public void TreeSteps()
    {
        StartCoroutine(TreeSteper());
    }
    public void HuseSteps()
    {
        StartCoroutine(HouseSteper());
    }

    public IEnumerator CaveSteper()
    {
        int i = 0;
        cave[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeR);
        cave[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeL);
        cave[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeR);
        cave[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeL);
        cave[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeR);
        cave[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeL);
        cave[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeR);
        cave[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        i = 0;
    }

    public IEnumerator TreeSteper()
    {
        int i = 0;
        tree[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeR);
        tree[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeL);
        tree[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeR);
        tree[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeL);
        tree[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeR);
        tree[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeL);
        tree[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeR);
        tree[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        i = 0;
    }

    public IEnumerator HouseSteper()
    {
        int i = 0;
        house[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeR);
        house[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeL);
        house[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeR);
        house[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeL);
        house[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeR);
        house[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeL);
        house[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        yield return new WaitForSeconds(stepTimeR);
        house[i].SetActive(true);
        stepsSound.clip = stepsClips[i];
        stepsSound.Play();
        i += 1;
        i = 0;
    }
    
}
