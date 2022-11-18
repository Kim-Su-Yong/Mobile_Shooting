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

    //�Է� ���� : �Է� ��ǥ ����
    void Start()
    {
        outerImg = GetComponent<Image>();
        innerImg = this.transform.GetChild(0).GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        //RectTransform�� ����ϱ� ���� Helper �޼ҵ尡 ���Ե� ��ƿ��Ƽ Ŭ����
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(outerImg.rectTransform,
            eventData.position, eventData.pressEventCamera, out pos))
        {   //��ũ�� ���� ���� ���簢�� ��鿡 �ִ� RectTransform�� ���� ������ �ִ� ��ġ�� ��ȯ
            //��ũ�� ��ǥ -> ����(���󼼰�)�� �ִ� ���̽�ƽ UI�� �´� ���� ��ǥ�� ��ȯ
            pos.x = (pos.x / outerImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / outerImg.rectTransform.sizeDelta.y);
            inputVector = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1, 0f);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            innerImg.rectTransform.anchoredPosition = 
                new Vector3(inputVector.x * (outerImg.rectTransform.sizeDelta.x / 3),
                inputVector.y * (outerImg.rectTransform.sizeDelta.y / 3), 0f);
            /*
             ��ġ�е带 ������ ���� �� ������ onDrag(PointerEventData ped)�Լ��� �����մϴ�.
             bgImg������ ��ġ�� �߻�������
             (RectTransformUtility.ScreenPointToLocalPointRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out.pos)��  true�϶�),
            ��ġ�� ���� ��ǥ���� pos�� �Ҵ��ϰ� bgImg ���簢���� sizeDelta������ ������ pos.x�� 0-1, pos.y�� 0-1������ ������ ����ϴ�.
            joystickImg�� �������� �¿�� ���������� pos.x�� -1 -1������ ������, ���Ϸ� ���������� pos.y�� -1 -1�� ������ ��ȯ�ϱ�
            ���� pos.x *2 +1, pos.y * 2 -1 ó���� �մϴ�.
            �� ���� inputVector�� �����ϰ� �������ͷ� ����ϴ�.
            ���������� joystickImg�� ��ġ�� ��ǥ������ �̵���ŵ�ϴ�.

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
