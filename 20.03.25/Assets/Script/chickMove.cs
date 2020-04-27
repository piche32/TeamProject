using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickMove : MonoBehaviour
{
    private bool isFollowing = false;
    private GameObject player;
    [SerializeField] float dampSpeed = 3;
    public float DampSpeed { get { return dampSpeed; } set { dampSpeed = value; } }
    private GameObject chicksCtrl;
    private Vector3 pos;

    private GameObject whiteTree;
    private float lightValue;
    private const float MaxLight = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        lightValue = 5.0f;
        player = GameObject.FindWithTag("Player");
        chicksCtrl = gameObject.transform.parent.gameObject;
        pos = transform.position;
        whiteTree = GameObject.FindWithTag("WhiteTree");
    }

    // Update is called once per frame
    void Update()
    {
        setUpPos();
        pos = transform.position;
        if (isFollowing)
        {
            FollowTarget();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            isFollowing = false;
        }
        Vector3 treePos = whiteTree.transform.position;
        pos = transform.position;
        Vector3 distance = new Vector3 (treePos.x, 0, treePos.z) - new Vector3(pos.x, 0, pos.z);
        Debug.Log(distance.sqrMagnitude);
        if(isFollowing == false && distance.sqrMagnitude < 1000)
        {
          //  Debug.Log("Near the white tree");
            chicksCtrl.GetComponent<ChicksCtrl>().ChicksCount--;
            if (lightValue < MaxLight)
            {
                whiteTree.gameObject.GetComponentInChildren<Light>().intensity += lightValue;
                Debug.Log("Brighting");
            }
            Destroy(gameObject);
        }
      
    }

    void FollowTarget()
    {
        var heading = player.transform.position - pos;
        if(heading.sqrMagnitude>500)
         {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * dampSpeed);
         }
        transform.LookAt(player.transform);
    }

    void setUpPos()
    {
        if(pos.y < -200.0f)
        {
            float randomX = Random.Range(1.0f, 996.0f);
            float randomZ = Random.Range(1.0f, 996.0f);
            this.transform.position = new Vector3(randomX, 100.0f, randomZ);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        MeshRenderer[] mrCubeList = this.gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mr in mrCubeList)
        {
            mr.enabled = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            isFollowing = true;
        }
        
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    isFollowing = true;
        //}
        
    }
}
