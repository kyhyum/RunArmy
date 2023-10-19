using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingUp : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.PlayBGM(BGM.GoingUp);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �ʹ� ���� ȣ��ɱ�� Layer Collision Matrix ó�� ������
        if (other.TryGetComponent(out CharacterController controller))
        {
            Clear(controller);
        }
    }

    private void Clear(CharacterController controller)
    {
        controller.enabled = false;
        SoundManager.Instance.StopBGM();
        // TODO
        // ShowPopup
    }
}
