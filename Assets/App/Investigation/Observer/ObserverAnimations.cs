using UnityEngine;

using Assets.App.Investigation.Clues;

namespace Assets.App.Investigation.Observer
{
    [RequireComponent(typeof(ObserverPhoto))]
    [RequireComponent(typeof(ObserverZoom))]
    public class ObserverAnimations : MonoBehaviour
    {
        private ObserverPhoto c_observerPhoto;
        private ObserverZoom c_observerZoom;

        [SerializeField] private Animator cameraAnimator;
        [SerializeField] private Animator notificationAnimator;

        void Start()
        {
            c_observerPhoto = GetComponent<ObserverPhoto>();
            c_observerZoom = GetComponent<ObserverZoom>();

            c_observerPhoto.OnPhotoStart += HandlePhotoStart;
            c_observerZoom.OnZoomStart += HandleZoomStart;
            Globals.OnClueFound += HandleClueFound;
        }

        private void HandlePhotoStart()
        {
            cameraAnimator.SetTrigger("Photo");
        }

        private void HandleZoomStart()
        {
            cameraAnimator.SetTrigger("Zoom");
        }

        private void HandleClueFound(Clue _)
        {
            notificationAnimator.SetTrigger("Clue");
        }
    }
}
