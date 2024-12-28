using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperiencePanel : MonoBehaviour
{
    [SerializeField] Slider experienceSlider;

    [SerializeField] TextMeshProUGUI levelText;

    public void SetExperienceSlider(int currentExperience, int needExperienceAmountToLevelUp, int currentLevel)
    {
        experienceSlider.maxValue = needExperienceAmountToLevelUp;
        experienceSlider.value = currentExperience;
        levelText.text = "LV " + currentLevel.ToString();
    }

}
