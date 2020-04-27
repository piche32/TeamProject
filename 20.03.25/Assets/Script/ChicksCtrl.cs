using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicksCtrl : MonoBehaviour
{
    [SerializeField] GameObject chick0;
    [SerializeField] GameObject chick1;
    [SerializeField] GameObject chick2;
    [SerializeField] GameObject chick3;
    [SerializeField] GameObject chick4;

    private GameObject[] chicks;
    [SerializeField] const int maxChicks = 10;
    private int chicksCount;
    public int ChicksCount { get { return chicksCount; } set { chicksCount = value; } }
    // Start is called before the first frame update
    void Start()
    {
        chicks = new GameObject[] { chick0, chick1, chick2, chick3, chick4 };
        chicksCount = 0;
        InvokeRepeating("SpawnChicks", 1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnChicks()
    {
        if (chicksCount == maxChicks) return;
        float randomX = Random.Range(1.0f, 996.0f);
        float randomZ = Random.Range(1.0f, 999.0f);
        int rand = (int)Random.Range(0.0f, 5.0f);
        if (rand > 4) rand = 4;
        var chick = GameObject.Instantiate(chicks[rand]) as GameObject;
        chick.transform.parent = transform;
        chick.transform.position = new Vector3(randomX, -100.0f, randomZ);
        MeshRenderer[] mrCubeList = chick.gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer mr in mrCubeList)
        {
            mr.enabled = false;
        }
        chicksCount++;

    }
}
