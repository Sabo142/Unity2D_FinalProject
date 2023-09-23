using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private int fallSpeed;
    private void Update()
    {
        this.transform.position = this.transform.position + new Vector3(0, fallSpeed, 0) * Time.deltaTime;
        if (this.transform.position.y < -11)
        {
            Destroy(gameObject);
        }
    }
}
