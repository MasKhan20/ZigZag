using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private GameObject diamondParticles;

    [SerializeField]
    private float speed;

    private new Rigidbody rb;
    private bool started;
    private bool gameover;

    // Awake is called when the gameobject is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.Instance.StartGame();
            } 
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1))
        {
            gameover = true;
            rb.velocity = new Vector3(0, -25, 0);

            Camera.main.GetComponent<CameraFollower>().GameOver = true;

            GameManager.Instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameover)
        {
            SwithDirection();
        }
    }

    private void SwithDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            GameObject particle = Instantiate(diamondParticles, other.gameObject.transform.position, diamondParticles.transform.rotation);

            Destroy(other.gameObject);
            Destroy(particle, 1f);
        }
    }
}
