using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickText : MonoBehaviour
{
    private Text chickCountText;
    private GameObject chickCtrl;
    // Start is called before the first frame update
    void Start()
    {
        chickCountText = GetComponent<Text>();
        chickCtrl = GameObject.FindWithTag("ChickCtrl");
    }

    // Update is called once per frame
    void Update()
    {
        chickCountText.text = "Chick: " + chickCtrl.GetComponent<ChicksCtrl>().ChicksCount;
    }
}
