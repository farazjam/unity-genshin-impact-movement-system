using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GenshinImpactMovementSystem;

public class RegionCollider : MonoBehaviour
{
    public event Action PlayerEntersRegion;
    public event Action PlayerExitsRegion;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player _))
        {
            PlayerEntersRegion?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player _))
        {
            PlayerExitsRegion?.Invoke();
        }
    }
}
