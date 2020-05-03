using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMushroom : MonoBehaviour
{
    private GameObject activity;
    private GameObject player;
    [SerializeField] int eggNumber = 1;
    private Vector3 pos;
    public int EggNumber { get { return eggNumber; } set { eggNumber = value; } }
    // Start is called before the first frame update
    void Start()
    {
        activity = GameObject.FindWithTag("Activity");
        player = GameObject.FindWithTag("Player");
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (UICtrl.IsPause) return;
        if (pos.y < -160.0f) { setUpPos(); }
        Vector3 distance = player.transform.position - this.transform.position;
        if(distance.sqrMagnitude<200)
        {
            //Debug.Log("Mushroom");
            if (Input.GetKeyDown(KeyCode.R))
            {
                activity.GetComponent<makeEgg>().AvailableEgg += eggNumber;
                GameObject.FindWithTag("MushroomCtrl").GetComponent<mushroomCtrl>().MushroomCount--;
                Destroy(gameObject);
            }
        }
    }

    void setUpPos()
    {
        pos = transform.position;
       float randomX = Random.Range(1.0f, 996.0f);
       float randomZ = Random.Range(1.0f, 996.0f);
       this.transform.position = new Vector3(randomX, 100.0f, randomZ);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Ground" && collision.gameObject.tag != "Player"
            && collision.gameObject.tag != "Chick") { setUpPos(); return; }
      //  Debug.Log("Mushroom");
        GetComponent<MeshRenderer>().enabled = true;
        return;
    }
}
