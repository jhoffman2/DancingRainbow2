using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;
using RootMotion.FinalIK;

public class HitCounter : MonoBehaviour
{
    private int hitCount = 0;
    public PuppetMaster puppetMaster;
    public Material material;
    public LookAtController lookAtController;

    private bool beenHit = false;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Color newColor = new Color(1f, 1f, 1f, 1f);
        material.SetColor("_BaseColor", newColor);

        animator.Play("Angry");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseHitCount()
    {
        hitCount++;
        Debug.Log("Hit Count: " + hitCount);
        
        if (hitCount == 1)
        {
            Color newColor = new Color(0.6f, 0.6f, 0.6f, 1f);
            material.SetColor("_BaseColor", newColor);
            material.SetFloat("_Smoothness", 0.6f);
        }

        if (hitCount == 2)
        {
            Color newColor = new Color(0.3f, 0.3f, 0.3f, 1f);
            material.SetColor("_BaseColor", newColor);
            material.SetFloat("_Smoothness", 0.3f);
        }

        if (hitCount == 3)
        {
            Color newColor = new Color(0f, 0f, 0f, 1f);
            material.SetColor("_BaseColor", newColor);
            material.SetFloat("_Smoothness", 0.1f);

            puppetMaster.Kill();
        }

    }

    public void BeenHit()
    {
        beenHit = true;
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dancer" && beenHit == true)
        {
            //animator.Play("Dance");
            lookAtController.weight = 0;
            animator.SetTrigger("Returned");
            beenHit = false;
        }
    }
}
