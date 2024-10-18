using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayAttach : MonoBehaviour
{
    IXRSelectInteractable m_SelectInteractable;

    private void OnEnable()     // ���� ���� ��
    {
        m_SelectInteractable = GetComponent<IXRSelectInteractable>();
        if (m_SelectInteractable as Object == null)          // m_SelectInteractable�� Object�� null�� ���
            return;

        m_SelectInteractable.selectEntered.AddListener(OnSelectEntered);    //OnSelectEntered�� ȣ���Ѵ�
    }

    private void OnDisable()        // ���� ���߾��� ��
    {
        if (m_SelectInteractable as Object != null)             // m_SelectInteractable�� Object�� null�� �ƴ� ��
            m_SelectInteractable.selectEntered.RemoveListener(OnSelectEntered);     //OnSelectEntered�� ���´�
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!(args.interactorObject is XRRayInteractor))        //
            return;

        var attachTransform = args.interactorObject.GetAttachTransform(m_SelectInteractable);
        var originalAttachPos = args.interactorObject.GetLocalAttachPoseOnSelect(m_SelectInteractable);
        attachTransform.SetLocalPose(originalAttachPos);
    }
}
