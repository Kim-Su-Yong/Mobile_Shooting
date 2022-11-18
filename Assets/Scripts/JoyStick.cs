using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class JoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Image outerImg;
    [SerializeField] Image innerImg;
    private Vector3 inputVector = Vector3.zero;

    //입력 벡터 : 입력 좌표 저장
    void Start()
    {
        outerImg = GetComponent<Image>();
        innerImg = this.transform.GetChild(0).GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        //RectTransform을 사용하기 위한 Helper 메소드가 포함된 유틸리티 클래스
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(outerImg.rectTransform,
            eventData.position, eventData.pressEventCamera, out pos))
        {   //스크린 공간 점을 직사각형 평면에 있는 RectTransform의 로컬 공간에 있는 위치로 변환
            //스크린 좌표 -> 월드(가상세계)에 있는 조이스틱 UI에 맞는 로컬 좌표로 변환
            pos.x = (pos.x / outerImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / outerImg.rectTransform.sizeDelta.y);
            inputVector = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1, 0f);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            innerImg.rectTransform.anchoredPosition = 
                new Vector3(inputVector.x * (outerImg.rectTransform.sizeDelta.x / 3),
                inputVector.y * (outerImg.rectTransform.sizeDelta.y / 3), 0f);
            /*
             터치패드를 누르고 있을 때 실행할 onDrag(PointerEventData ped)함수를 구현합니다.
             bgImg영역에 터치가 발생했을때
             (RectTransformUtility.ScreenPointToLocalPointRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out.pos)가  true일때),
            터치된 로컬 좌표값을 pos에 할당하고 bgImg 직사각형의 sizeDelta값으로 나누어 pos.x는 0-1, pos.y는 0-1사이의 값으로 만듭니다.
            joystickImg를 기준으로 좌우로 움직였을때 pos.x는 -1 -1사이의 값으로, 상하로 움직였을때 pos.y는 -1 -1의 값으로 변환하기
            위해 pos.x *2 +1, pos.y * 2 -1 처리를 합니다.
            이 값을 inputVector에 대입하고 단위벡터로 만듭니다.
            마지막으로 joystickImg를 터치한 좌표값으로 이동시킵니다.

             */ 

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        innerImg.rectTransform.anchoredPosition = Vector3.zero;
        outerImg.rectTransform.anchoredPosition = new Vector3(-30f, 30f, 0f);
    }
    public float GetHorizontalValue()
    {
        return inputVector.x;
    }
    public float GetVerticalValue()
    {
        return inputVector.y;
    }
}
