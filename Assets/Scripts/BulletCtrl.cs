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
        //rbody.AddForce(tr.forward * bulletSpeed); //Vector3.forward로 하면 안됨, 절대좌표 사용X
        tr.Translate(Vector3.up * Time.deltaTime * bulletSpeed);
    }
    private void OnDisable() //오브젝트가 비활성화 될 때 호출
    {
        trail.Clear();
        tr.position = Vector3.zero;
        // tr.rotation = Quaternion.identity; 2D에서는 필요 없음
        //rbody.Sleep(); //리지드바디 정지
    }
}
