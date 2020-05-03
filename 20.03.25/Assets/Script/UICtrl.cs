using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICtrl : MonoBehaviour
{
    [SerializeField] GameObject tutorial = null;
    // Start is called before the first frame update

    AudioSource audioSource;
    [SerializeField] AudioClip openSound = null;
    [SerializeField] AudioClip closeSound = null;

    [SerializeField] GameObject option = null;

    [SerializeField] Slider backgroundSoundSlider = null;
    [SerializeField] AudioSource bgm = null;

    [SerializeField] Scrollbar effectSoundScrollbar = null;
    bool effectSound;
    AudioSource playerAudioSource;
    AudioSource eggAudioSource;
    private static bool isPause;
    public static bool IsPause{ get { return isPause; } set { isPause = value; } }

    [SerializeField] Text timeTxt;
    private float time;
    private float currentTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        backgroundSoundSlider.value = bgm.volume;
        playerAudioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
        eggAudioSource = GameObject.FindWithTag("Activity").GetComponent<AudioSource>();
        effectSoundScrollbar.value = 1.0f;
        effectSound = true;
    }

    // Update is called once per frame
    void Update()
    {
        tutorialCtrl();
        optionCtrl();
        if(isPause == true)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

        timer();
        if(currentTime/60 > 2)
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }

    void timer()
    {
        currentTime += Time.deltaTime;
        time = currentTime;
        int min;
        int sec;
        int milsec;
        min = (int)(time / 60.0f);
        time = time % 60.0f;
        sec = (int)time;
        milsec = (int)((time - (float)sec) * 100);

        timeTxt.text = "Time: " + min+":"+sec+":"+milsec;
    }

    void tutorialCtrl()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (option.activeSelf) return;
            if (tutorial == null) return;
            if (!tutorial.activeSelf)
            {
                isPause = true;
                tutorial.SetActive(true);
                audioSource.clip = openSound;
                audioSource.Play();
            }
            else
            {
                isPause = false;
                tutorial.SetActive(false);
                audioSource.clip = closeSound;
                audioSource.Play();
            }
        }
        return;
    }

    void optionCtrl()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (tutorial.activeSelf) return;
            if (option == null) return;
            if (!option.activeSelf)
            {
                isPause = true;
                option.SetActive(true);
                audioSource.clip = openSound;
                audioSource.Play();
            }
            else
            {
                isPause = false;
                option.SetActive(false);
                audioSource.clip = closeSound;
                audioSource.Play();
            }
        }
    }

    public void BGSoundCtr()
    {
        if (bgm == null) return;
        if (backgroundSoundSlider == null) return;
        bgm.volume = backgroundSoundSlider.value;
    }

    public void effectSoundCtl()
    {
        if (effectSoundScrollbar.value > 0.5) effectSound = true;
        else effectSound = false;

        if (effectSound)
        {
            audioSource.mute = false;
            playerAudioSource.mute = false;
            eggAudioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
            playerAudioSource.mute = true;
            eggAudioSource.mute = true;
        }
    }


}
