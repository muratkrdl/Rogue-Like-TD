using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] Image skillImage;
    [SerializeField] Image slider;

    public Image GetSlider
    {
        get => slider;
    }

    public void ChangeSkillSprite(Sprite newSprite)
    {
        skillImage.sprite = newSprite;
    }

    public void EvolveSkill(Sprite newSprite, Color newColor)
    {
        ChangeSkillSprite(newSprite);
        GetComponent<Image>().color = newColor;
        GetComponentInChildren<ParticleSystem>().Play();
    }

    public Sprite GetSkillSprite()
    {
        return skillImage.sprite;
    }
}
