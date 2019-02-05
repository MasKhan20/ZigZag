using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject Target;
    public float Speed = 2;

    [HideInInspector]
    public bool GameOver;

    private Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        offset = Target.transform.position - transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GameOver)
        {
            transform.position = Vector3.Lerp(transform.position, Target.transform.position - offset, Speed * Time.deltaTime); 
        }
    }
}
