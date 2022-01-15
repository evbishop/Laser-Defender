using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.02f;
    [SerializeField] Renderer renderer;
    Material material;
    Vector2 offSet;

    void Start()
    {
        material = renderer.material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    void Update()
    {
        material.mainTextureOffset += offSet * Time.deltaTime;
    }
}
