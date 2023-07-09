using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    GameObject particle;
    bool started;
    Rigidbody rb;
    bool gameOver;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    void Start()
    {
        // rb.velocity = new Vector3(speed, 0, 0);
    }

    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.StartGame();
            }
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            FindObjectOfType<PlatformSpawner>().gameOver = true;
            GameManager.instance.GameOver();
        }
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
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
            Destroy(other.gameObject);
            GameObject particleItem = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity);
            Destroy(particleItem, 1f);
        }
    }
}
