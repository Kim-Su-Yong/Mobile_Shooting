using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool isShake; //ī�޶� ������ ������ �Ǵ�
    private Vector3 PosCamera = Vector3.zero; //���� ī�޶���ġ�� ���� �� ������ ���ڸ��� ���ƿ������� ����
    private float isShakeTime = 0f; //ī�޶� ���� �������� �ð��� ����
    private float Timer = 0f; //�ð� Ÿ�̸�
    public AudioClip backGroundSound;
    void Start()
    {
        isShake = false;
        SoundManager.soundManager.PlaySoundMethod(this.transform.position, backGroundSound, true);
    }

    
    void Update()
    {
        if (isShake)
        {
            float x = Random.Range(-0.1f, 0.1f);
            float y = Random.Range(-0.1f, 0.1f);
            Camera.main.transform.position += new Vector3(x, y, 0f);
            Timer += Time.deltaTime;
            if (Timer > 0.3f)
            {
                isShake = false;
                Camera.main.transform.position = PosCamera;
                Timer = Time.deltaTime;
            }
        }
    }
    public void TurnOn()
    {
        if (isShake == false)
            isShake = true;
        PosCamera = Camera.main.transform.position;
        Timer = Time.deltaTime; //Time.time���� �ص� �����ϴ�. ������ �� �ٸ���..
    }
}
