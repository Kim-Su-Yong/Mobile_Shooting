using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer renderer;
    public float Speed = 0.3f; //움직이는 속도
    private float x = 0f, y = 0f; //어디축으로 움직일지
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        x = x + Time.deltaTime * Speed;
        renderer.material.mainTextureOffset = new Vector2(x, y);
        // MeshRenderer안에 Material 안에 Texture에 접근해서 이미지를 이동시킴
    }   
}
