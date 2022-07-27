using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpreader : MonoBehaviour
{
    [SerializeField] Vector3 maxSpreadVariation;
    [SerializeField] ParticleSystem particle;

    private Vector3 originPosition;
    private float lastRange = 0.0f;
    [SerializeField, Range(0.25f, 0.75f)] private float rangeVariation = 0.25f;



    private void Awake()
    {
        originPosition = transform.position;
        particle.Emit(1); 
        MoveParticleSystem();
    }

    private void OnParticleSystemStopped()
    {
        //Debug.Log("OnParticleSystemStopped");
        MoveParticleSystem();
        PlayParticle();
    }


    private void MoveParticleSystem()
    {
        float range;
        do
        {
            range = Random.Range(0.0f, 1.0f);
        } while (Mathf.Abs(lastRange - range) < rangeVariation);
        lastRange = range;

        particle.transform.position = originPosition + ((range - 1.0f) * maxSpreadVariation);
    }

    private void PlayParticle()
    {
        particle.Play();
    }

}
