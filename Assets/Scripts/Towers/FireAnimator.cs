using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FireAnimator : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    float maxHealth;

    public float SetMaxHealth
    {
        set
        {
            maxHealth = value;
        }
    }

    public void HealthChanged(float currenthealth)
    {
        float percent = currenthealth / maxHealth;

        if(!audioSource.isPlaying && percent <= .8f)
        {
            audioSource.Play();
        }
        else if(audioSource.isPlaying && percent <= 0 || percent > 0.8f)
        {
            audioSource.Stop();
        }

        GetComponent<Animator>().SetInteger(ConstStrings.TOWER_FIRE_ANIMATOR_HEALTH_PERCENT, (int)(percent * 100));
    }

    public void SetOnFireFalse()
    {
        GetComponent<Animator>().SetBool(ConstStrings.TOWER_FIRE_ANIMATOR_ON_FIRE, false);
    }

    public void SetOnFireTrue()
    {
        GetComponent<Animator>().SetBool(ConstStrings.TOWER_FIRE_ANIMATOR_ON_FIRE, true);
    }

}
