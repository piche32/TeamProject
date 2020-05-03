using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float LightValue { get { return lightValue; } set { lightValue = value; } }
    private const float maxLight = 50.0f;
    public float MaxLight {get{return maxLight;}}
    // Start is called before the first frame update
    void Start()
    {
        lightValue = 50.0f;
        player = GameObject.FindWithTag("Player");
        chicksCtrl = gameObject.transform.parent.gameObject;
        pos = transform.position;
        whiteTree = GameObject.FindWithTag("WhiteTree");
    }

    // Update is called once per frame
    void Update()
    {
        if(pos.y < -160.0f) setUpPos();
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
     //   Debug.Log(distance.sqrMagnitude);
        if(isFollowing == false && distance.sqrMagnitude < 5000)
        {
          //  Debug.Log("Near the white tree");
            chicksCtrl.GetComponent<ChicksCtrl>().ChicksCount--;
            if (whiteTree.gameObject.GetComponentInChildren<Light>().intensity < maxLight)
            {
                whiteTree.gameObject.GetComponentInChildren<Light>().intensity += lightValue;
             //   Debug.Log("Brighting");
             if (whiteTree.gameObject.GetComponentInChildren<Light>().intensity >= maxLight)
                {
                    SceneManager.LoadScene("Success");
                }
            }
            else if (whiteTree.gameObject.GetComponentInChildren<Light>().intensity >= maxLight)
            {
                SceneManager.LoadScene("Success");
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
        float randomX = Random.Range(1.0f, 996.0f);
        float randomZ = Random.Range(1.0f, 996.0f);
        this.transform.position = new Vector3(randomX, 100.0f, randomZ);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isFollowing == true) return;
        if(collision.gameObject.tag != "Ground" && collision.gameObject.tag != "Player" 
            && collision.gameObject.tag != "Chick") { setUpPos(); return; }
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
