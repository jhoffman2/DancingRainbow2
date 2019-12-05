using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSounds : MonoBehaviour
{


    public AudioSource impactSound;
    public float impactSoundThreshold = 2.1f;  // tweak this value



    private void OnCollisionEnter(Collision collision)
    {
        PlayCollisionSound(collision);
    }

    private void PlayCollisionSound(Collision collision)
    {

        // check if the collision was hard enough to generate a sound
        if (collision.relativeVelocity.magnitude > impactSoundThreshold)
        {

            // select the correct sound effect based on the object's tag
            //switch (collision.gameObject.tag)
            //{
            //    case "Concrete": audio.clip = FloorSound; break;
            //    case "Locker": audio.clip = LockerSound; break;
            //}

            // calculate the volume (anything above 4*Threshold = full volume)
            var volume = Mathf.InverseLerp(impactSoundThreshold, impactSoundThreshold * 4, collision.relativeVelocity.magnitude);

            // play the audio
            impactSound.volume = volume;
            impactSound.Play();
        }

    }

}
