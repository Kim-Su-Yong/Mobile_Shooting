using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCtrl : MonoBehaviour
{
    public float Speed = 8f;
    private Transform tr;
    private readonly string Tag1 = "Player";
    private readonly string Tag2 = "BULLET";
    public GameObject hitEffect;


    void Awake()
    {
        tr = GetComponent<Transform>();
        hitEffect = Resources.Load<GameObject>("Eff_DamagePre");
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        GetComponent<TrailRenderer>().Clear();
        tr.position = new Vector3(0, 0, -2f);
    }
    void Update()
    {
        if (tr.position.x < -13f)
            gameObject.SetActive(false);
        tr.Translate(Vector3.left * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == Tag1)
        {
            gameObject.SetActive(false);
            Debug.Log("Ãæµ¹: " + other.gameObject.name.ToString());
            Camera.main.GetComponent<CameraShake>().TurnOn();
            var eff = Instantiate(hitEffect, other.transform.position, Quaternion.identity);
            Destroy(eff, 0.3f);
        }
        else if (other.gameObject.CompareTag(Tag2))
        {
            gameObject.SetActive(false);
        }
    }
}
