using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour
{
    [SerializeField] GameObject tutorial;
    // Start is called before the first frame update

    AudioSource audioSource;
    [SerializeField] AudioClip openSound = null;
    [SerializeField] AudioClip closeSound = null;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (!tutorial.activeSelf)
            {
                tutorial.SetActive(true);
                audioSource.clip = openSound;
                audioSource.Play();
            }
            else
            {
                tutorial.SetActive(false);
                audioSource.clip = closeSound;
                audioSource.Play();
            }
        }
    }
}
