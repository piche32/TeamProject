using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomCtrl : MonoBehaviour
{
    [SerializeField] GameObject mushroom1;
    [SerializeField] GameObject mushroom2;
    private const int maxMushroom = 10;
    private int mushroomCount;
    public int MushroomCount { get { return mushroomCount; } set { mushroomCount = value; } }
    // Start is called before the first frame update
    void Start()
    {
        mushroomCount = 0;
        InvokeRepeating("SpawnMushroom", 1, 10);

    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnMushroom()
    {
        if (mushroomCount == maxMushroom) return;
       //     float temp = Time.time;
      //  Random.InitState((int)Time.time);
        float randomX = Random.Range(1.0f, 996.0f);
        float randomZ = Random.Range(1.0f, 999.0f);
        if(Random.Range(0.0f, 1.90f) < 1.0f)
        {
            var mushroom = GameObject.Instantiate(mushroom1) as GameObject;
            mushroom.transform.parent = transform;
            mushroom.transform.position = new Vector3(randomX, -100.0f, randomZ);
            mushroom.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            var mushroom = GameObject.Instantiate(mushroom2) as GameObject;
            mushroom.transform.parent = transform;
            mushroom.transform.position = new Vector3(randomX, -100.0f, randomZ);
            mushroom.GetComponent<MeshRenderer>().enabled = false;
        }
        mushroomCount++;
       // Debug.Log(mushroomCount);
        
    }
}
