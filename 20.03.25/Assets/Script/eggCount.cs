using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eggCount : MonoBehaviour
{
    private Text eggCountText;
    private GameObject activity;

    // Start is called before the first frame update
    void Start()
    {
        eggCountText = GetComponent<Text>();
        activity = GameObject.FindWithTag("Activity");
    }

    // Update is called once per frame
    void Update()
    {
        eggCountText.text = "Available Egg: " + activity.GetComponent<makeEgg>().AvailableEgg;
    }
}
