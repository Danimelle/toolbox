using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    [SerializeField] public int speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
