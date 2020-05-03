using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeEgg : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    public GameObject Prefab { get { return prefab; } set { prefab = value; } }
    [SerializeField] int availableEgg = 10;
    public int AvailableEgg { get { return availableEgg; } set { availableEgg = value; } }
    AudioSource audioSource;

    [SerializeField] float height = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UICtrl.IsPause) return;
        if (availableEgg > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                audioSource.Play();
                GameObject Egg = LoadEgg();
                if (Egg = null) { Debug.Log("error: LoadEgg"); return; }
                availableEgg--;
              //  Debug.Log(availableEgg);
            }
        }

    }

    GameObject LoadEgg()
    {
        var egg = GameObject.Instantiate(prefab) as GameObject;
        egg.transform.parent = transform;
        egg.transform.localPosition = GameObject.FindWithTag("Player").transform.position;
        egg.transform.rotation = GameObject.FindWithTag("Player").transform.rotation;
        egg.transform.Translate(0.0f, height, 0.0f);
        egg.transform.Translate(Vector3.forward * 5.0f);
        return egg;
    }
}
