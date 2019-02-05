using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private GameObject diamond;
    
    private Vector3 lastPos;
    private float size;

    // Start is called before the first frame update
    private void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatform();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.Instance.IsGameOver)
        {
            CancelInvoke("SpawnPlaform");
        }
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnPlatform", 0.1f, 0.2f);
    }

    private void SpawnPlatform()
    {
        if (GameManager.Instance.IsGameOver)
            return;

        int rand = Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnX();
        }
        else if (rand >= 3)
        {
            SpawnZ();
        }
    }

    private void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;

        GameObject go = Instantiate(platform, pos, Quaternion.identity);
        go.transform.parent = transform;

        SpawnDiamond(pos);
    }
    
    private void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;

        GameObject go = Instantiate(platform, pos, Quaternion.identity);
        go.transform.parent = transform;

        SpawnDiamond(pos);
    }

    private void SpawnDiamond(Vector3 pos)
    {
        int rand = Random.Range(0, 4);
        if (rand == 0)
        {
            GameObject go = Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
            go.transform.parent = transform;
        }
    }
}
