using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WriteText : MonoBehaviour
{
    public static WriteText Instance;

    public EventHandler OnClickOkey;

    [SerializeField] Image raycastBlocker;

    [SerializeField] Animator mganAnimator;

    [SerializeField] TextMeshProUGUI mGanText;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] MGanTextSO writeMGanTextSO;

	[SerializeField] float delayBeforeStart = .1f;
	[SerializeField] float timeBetweenChars = .1f;
	[SerializeField] string leadingChar = "";
	[SerializeField] bool leadingCharBeforeDelay = false;

    bool willInteract = false;

    public MGanTextSO GetMGanTextSO
    {
        get => writeMGanTextSO;
    }

    void Awake()
	{
        Instance = this;
		mGanText.text = "";
	}

    void Start() 
    {
        GameStateManager.Instance.PauseGame();
        Invoke(nameof(InvokeForStart), 3f);
    }

    void InvokeForStart()
    {
        PlayableDirectorManager.Instance.PlayNextTimeLine();
    }

    public void StartTypewriter()
	{
        SetRaycastBlock(true);
        mganAnimator.SetTrigger(ConstStrings.INFO_PANEL_ANIMATOR_IN);
		mGanText.text = "";
        TypeWriterTMP().Forget();
	}

    async UniTaskVoid TypeWriterTMP()
    {
        buttonText.gameObject.SetActive(false);
        mGanText.text = leadingCharBeforeDelay ? leadingChar : "";
        buttonText.text = writeMGanTextSO.buttonName;

        await UniTask.Delay(TimeSpan.FromSeconds(delayBeforeStart));

		foreach(char c in writeMGanTextSO.text)
		{
			if (mGanText.text.Length > 0)
			{
				mGanText.text = mGanText.text.Substring(0, mGanText.text.Length - leadingChar.Length);
			}

			mGanText.text += c;
			mGanText.text += leadingChar;

            if(mGanText.text.Length %3 == 1)
                SoundManager.Instance.PlaySound2D(ConstStrings.TEXTWRITE);
			await UniTask.Delay(TimeSpan.FromSeconds(timeBetweenChars));
        }

        willInteract = !writeMGanTextSO.canInteract;

        mGanText.text = writeMGanTextSO.text;
        buttonText.gameObject.SetActive(true);

        writeMGanTextSO = writeMGanTextSO.nextText;
	}

    public void OnClick_StartWriter()
    {
        if(GameOverMenu.Instance.IsGameOver) return;
        
        if(writeMGanTextSO.play)
        {
            PlayableDirectorManager.Instance.PlayNextTimeLine();
        }
        else
        {
            mganAnimator.SetTrigger(ConstStrings.INFO_PANEL_ANIMATOR_OUT);
            if(writeMGanTextSO.name != "47" && writeMGanTextSO.name != "60")
                GameStateManager.Instance.ResumeGame();
        }
    }

    public void OnClick_OkeyButton()
    {
        SetRaycastBlock(willInteract);
        OnClickOkey?.Invoke(this, EventArgs.Empty);
    }

    public void SetRaycastBlock(bool value)
    {
        raycastBlocker.raycastTarget = value;
    }

}
