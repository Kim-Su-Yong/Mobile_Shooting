using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float bulletSpeed = 500f;
    [SerializeField]
    private Rigidbody2D rbody;
    [SerializeField]
    private Transform tr;
    [SerializeField]
    private TrailRenderer trail;
    void Awake()
    {
        tr = GetComponent<Transform>();
        rbody = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
     
    }
    private void OnEnable()
    {
        Invoke("BulletDeActive", 0.5f);
        //tr.Translate(Vector3.up * Time.deltaTime * bulletSpeed);
    }
    void BulletDeActive()
    {
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        //rbody.AddForce(tr.forward * bulletSpeed); //Vector3.forward�� �ϸ� �ȵ�, ������ǥ ���X
        tr.Translate(Vector3.up * Time.deltaTime * bulletSpeed);
    }
    private void OnDisable() //������Ʈ�� ��Ȱ��ȭ �� �� ȣ��
    {
        trail.Clear();
        tr.position = Vector3.zero;
        // tr.rotation = Quaternion.identity; 2D������ �ʿ� ����
        //rbody.Sleep(); //������ٵ� ����
    }
}
