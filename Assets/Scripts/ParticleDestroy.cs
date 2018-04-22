using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour {

    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public void PlayDestroy(Vector3 _position)
    {
        this.transform.position = _position;
        particle.Play();
    }


}
