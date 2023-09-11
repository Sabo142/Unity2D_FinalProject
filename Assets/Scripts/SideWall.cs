using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    [SerializeField] int Speed = -3;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(0, Speed, 0) * Time.deltaTime;
        if(this.transform.position.y < -11)
        {
            this.transform.position += new Vector3(0, 22, 0);
        }
    }
}
