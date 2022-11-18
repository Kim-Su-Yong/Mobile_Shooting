using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer renderer;
    public float Speed = 0.3f; //�����̴� �ӵ�
    private float x = 0f, y = 0f; //��������� ��������
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        x = x + Time.deltaTime * Speed;
        renderer.material.mainTextureOffset = new Vector2(x, y);
        // MeshRenderer�ȿ� Material �ȿ� Texture�� �����ؼ� �̹����� �̵���Ŵ
    }   
}
