using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBladeDamager : SkillProjectileDamagerBaseClass
{
    TrailRenderer trailRenderer;

    void Start() 
    {
        trailRenderer = GetComponentInChildren<TrailRenderer>();    
    }

    public void AnimEvent_ClearTrailRenderer()
    {
        trailRenderer.Clear();
    }

}
