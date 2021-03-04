using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCtrl : MonoBehaviour
{
    public ParticleSystem par;
    
    void Start()
    {
        par.Play();
    }
}
