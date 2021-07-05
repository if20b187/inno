using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public GameObject Platform;

    private bool dirRight = true;
    public float speed = 2.0f;

    void Update()
    {
        if (dirRight)
            Platform.transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            Platform.transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (Platform.transform.position.x >= 4.0f)
        {
            dirRight = false;
        }

        if (Platform.transform.position.x <= -4)
        {
            dirRight = true;
        }
    }
}
