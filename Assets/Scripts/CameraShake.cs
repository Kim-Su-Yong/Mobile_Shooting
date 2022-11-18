using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool isShake; //카메라를 흔들건지 말건지 판단
    private Vector3 PosCamera = Vector3.zero; //원래 카메라위치를 저장 후 흔들고나서 제자리로 돌아오기위해 저장
    private float isShakeTime = 0f; //카메라를 언제 흔들었는지 시간을 저장
    private float Timer = 0f; //시간 타이머
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
        Timer = Time.deltaTime; //Time.time으로 해도 무방하다. 로직이 좀 다르다..
    }
}
