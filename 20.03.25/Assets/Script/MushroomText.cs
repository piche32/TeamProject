using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushroomText : MonoBehaviour
{
    private Text mushroomCountText;
    private GameObject mushroomCtrl;
    // Start is called before the first frame update
    void Start()
    {
        mushroomCountText = GetComponent<Text>();
        mushroomCtrl = GameObject.FindWithTag("MushroomCtrl");
    }

    // Update is called once per frame
    void Update()
    {
        mushroomCountText.text = "Mushroom: " + mushroomCtrl.GetComponent<mushroomCtrl>().MushroomCount;
    }
}
