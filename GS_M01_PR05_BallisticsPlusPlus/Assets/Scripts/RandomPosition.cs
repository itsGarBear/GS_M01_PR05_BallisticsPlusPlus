using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public void FindNewPosition()
    {
        this.transform.position = new Vector3(Random.Range(3, 100), -.5f, Random.Range(3, 100));
    }
}
