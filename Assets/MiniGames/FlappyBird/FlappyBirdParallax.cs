using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdParallax : MonoBehaviour
{
    private MeshRenderer MeshRenderer;
    public float animationspeed = 1f;
    private void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        MeshRenderer.material.mainTextureOffset += new Vector2(animationspeed * Time.deltaTime,0);
    }
}
