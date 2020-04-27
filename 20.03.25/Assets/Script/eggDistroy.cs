using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggDistroy : MonoBehaviour
{
    [SerializeField] float liveTime = 10.0f;
    public float LiveTime { get { return liveTime; } set { liveTime = value; } }
    private GameObject activity;
    [SerializeField] float power = 0.1f;
    private float velocity = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        activity = GameObject.FindWithTag("Activity");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, liveTime);
        velocity = velocity + power;
        transform.Translate(Vector3.forward*velocity);
     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        Destroy(gameObject);
    }
}
