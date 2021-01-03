using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField] float BGSpeed = 0.05f;

    Material Road;

    Vector2 offset;
    void Start()
    {
        Road = GetComponent<Renderer>().material;

        offset = new Vector2(0f, BGSpeed);
    }

    void Update()
    {
        Road.mainTextureOffset += offset * Time.deltaTime;
    }
}
