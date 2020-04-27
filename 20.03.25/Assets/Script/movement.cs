using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] float speed = 50;
    public float Speed { get { return speed; } set { speed = value; } }
    [SerializeField] float power = 10;
    public float Power { get { return power; } set { power = value; } }
    [SerializeField] float rSpeed = 5;
    public float RSpeed { get { return rSpeed; } set { rSpeed = value; }  }

    private bool isJumping = false;
    // Start is called before the first frame update
    AudioSource audioSource;
   [SerializeField] AudioClip jumpingSound = null;
    public AudioClip JumpingSound { get { return jumpingSound; } set { jumpingSound = value; } }
    [SerializeField] AudioClip landingSound = null;
    public AudioClip LandingSound { get { return landingSound; } set { landingSound = value; } }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        move();
        jump();
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
         //   Debug.Log("space");
            if (isJumping == false)
            {
                if (jumpingSound == null) return;
                audioSource.clip = jumpingSound;
                audioSource.Play();
                isJumping = true;
                GetComponent<Rigidbody>().velocity = new Vector3(0, power, 0);
            }//transform.GetComponent<Rigidbody>().AddForce(Vector3.up * power * Time.deltaTime, ForceMode.Impulse);
            //왜 저 줄이 작동을 안하는지 진짜 1도 모르겠다...

            /*if (isJumping == false)
            {
                Debug.Log("jump");
                isJumping = true;
                transform.GetComponent<Rigidbody>().AddForce(Vector3.up * power * Time.deltaTime, ForceMode.Impulse);
            }*/
        }
    }
    void move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate((new Vector3(0, 0, v) * speed) * Time.deltaTime);
        transform.Rotate(Vector3.up * rSpeed * h);

        
    }
 

    private void OnCollisionEnter(Collision collision)
    {
            if (isJumping == true)
            {
                if (landingSound == null) return;
                audioSource.clip = landingSound;
                audioSource.Play();
                isJumping = false;
            }
    
    }
}
