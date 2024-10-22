using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayAttach : MonoBehaviour
{
    IXRSelectInteractable m_SelectInteractable;

    [SerializeField] public bool m_IsActive = false;

    public void OnEnable()     // 동작 했을 때
    {
        m_SelectInteractable = GetComponent<IXRSelectInteractable>();
        if (m_SelectInteractable as Object == null)          // m_SelectInteractable의 Object가 null일 경우
            return;

        m_SelectInteractable.selectEntered.AddListener(OnSelectEntered);    //OnSelectEntered를 호출한다
        m_IsActive = true;
    }

    public void OnDisable()        // 동작 멈추었을 때
    {
        if (m_SelectInteractable as Object != null)             // m_SelectInteractable의 Object가 null이 아닐 때
            m_SelectInteractable.selectEntered.RemoveListener(OnSelectEntered);     //OnSelectEntered를 끊는다
        m_IsActive= false;
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
