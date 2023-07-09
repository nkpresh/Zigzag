using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamonds;
    public bool gameOver;
    Vector3 lastPos;
    float size;
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }

    }

    public void StartSpawningPlatForms()
    {
        InvokeRepeating(nameof(SpawnPlatforms), 2f, 2f);
    }
    void Update()
    {
        if (GameManager.instance.gameOver)
        {
            CancelInvoke(nameof(SpawnPlatforms));
        }
    }

    void SpawnPlatforms()
    {
        if (gameOver) return;
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

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        Instantiate(platform, pos, Quaternion.identity);
        lastPos = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 2, pos.z), diamonds.transform.rotation);
        }
    }
    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        Instantiate(platform, pos, Quaternion.identity);
        lastPos = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 2, pos.z), diamonds.transform.rotation);
        }
    }
}
