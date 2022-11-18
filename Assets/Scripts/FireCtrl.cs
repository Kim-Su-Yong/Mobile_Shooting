using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    [SerializeField]
    private Transform firePos;
    private bool isFire;
    void Start()
    {
        firePos = gameObject.transform.GetChild(1).transform;
        isFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public void Fire()
    {
        GameObject _bullet = GameManager.gameManager.GetBullet();
        if (_bullet != null)
        {
            _bullet.transform.position = firePos.position;
            //_bullet.transform.rotation = firePos.rotation; 2D에서는 필요없음
            _bullet.SetActive(true);
        }
    }
    
}
