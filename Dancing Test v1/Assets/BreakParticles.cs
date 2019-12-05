using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakParticles : MonoBehaviour
{
    public ParticleSystem particles;

    void OnJointBreak(float breakForce)
    {
        Debug.Log("A joint has just been broken!, force: " + breakForce);
        particles.transform.position = transform.position;
        particles.Emit(5);
    }

}
