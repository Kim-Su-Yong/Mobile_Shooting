using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width; //����� ���� ����
    void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }
    void Update()
    {
        if (transform.position.x <= -width)
        {
            Reposition();
        }

    }
    void Reposition()//��ġ�� ���ġ
    {
        Vector2 offset = new Vector2(width * 2f, 0f);
        transform.position = (Vector2)transform.position + offset;
    }
}