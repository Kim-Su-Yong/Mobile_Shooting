using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCtrl : MonoBehaviour
{
    public float Speed = 5.0f;
    private Transform tr;
    private float h, v;
    public AudioClip hitSound;
    [SerializeField]
    JoyStick joyStick;
    Vector3 moveVector = Vector3.zero;
    void Start()
    {
        joyStick = GameObject.Find("OuterCircle").GetComponent<JoyStick>();
        tr = GetComponent<Transform>();
    }
    void Update() //나중에는 Update를 StartCoroutine로 다 고쳐야한다.
    {             //윈도우에서 유니티 에디터를 사용하는 경우
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            CameraLimitWindowEdit();
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            HandleInput();
            Move();
        }
        if(Application.platform == RuntimePlatform.Android)
        {
            HandleInput();
            Move();
            tr.localPosition = new Vector3(Mathf.Clamp(tr.localPosition.x, -8.0f, 8.0f),
                Mathf.Clamp(tr.localPosition.y, -3.5f, 3.5f), tr.transform.position.z);
        }
    }

    private void CameraLimitWindowEdit()
    {
        #region 카메라 밖에 나가지 않는 로직
        if (tr.position.x > 8f)
            tr.position = new Vector3(8f, tr.position.y, tr.position.z);
        else if (tr.position.x < -8f)
            tr.position = new Vector3(-8f, tr.position.y, tr.position.z);
        if (tr.position.y > 4.5f)
            tr.position = new Vector3(tr.position.x, 4.5f, tr.position.z);
        else if (tr.position.y < -3.5f)
            tr.position = new Vector3(tr.position.x, -3.5f, tr.position.z);
        #endregion
        tr.Translate(Vector3.right * h * Time.deltaTime * Speed);
        tr.Translate(Vector3.up * v * Time.deltaTime * Speed);
    }
    public void HandleInput()
    {
        moveVector = InputVector();
    }
    public Vector3 InputVector()
    {
        float h = joyStick.GetHorizontalValue();
        float v = joyStick.GetVerticalValue();
        Vector3 moveDir = new Vector3(h, v, 0f).normalized;
        return moveDir.normalized;
    }
    public void Move()
    {
        transform.Translate(moveVector * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ASTEROID")
        {
            SoundManager.soundManager.PlaySoundMethod(other.transform.position, hitSound);
        }
    }
}
