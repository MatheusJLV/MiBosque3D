using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFX : MonoBehaviour
{
    
    private ParticleSystem FXParticle;

    private void OnTriggerEnter(Collider other)
    {
        FXParticle = GetComponent<ParticleSystem>();

        if (other.CompareTag("Player"))
        {
            FXParticle.Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FXParticle = GetComponent<ParticleSystem>();

        if (other.CompareTag("Player"))
        {
            FXParticle.Play();

        }
    }
}
