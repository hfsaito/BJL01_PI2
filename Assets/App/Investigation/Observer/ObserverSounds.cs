using UnityEngine;

using Assets.App.Common.Clues;

namespace Assets.App.Investigation.Observer
{
    [RequireComponent(typeof(ObserverPhoto))]
    [RequireComponent(typeof(ObserverZoom))]
    public class ObserverSounds : MonoBehaviour
    {
        private ObserverPhoto c_observerPhoto;
        private ObserverZoom c_observerZoom;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip audioClipPhoto;
        [SerializeField] private AudioClip audioClipZoom;
        [SerializeField] private AudioClip audioClipClue;

        void Start()
        {
            c_observerPhoto = GetComponent<ObserverPhoto>();
            c_observerZoom = GetComponent<ObserverZoom>();

            c_observerPhoto.OnPhotoStart += HandlePhotoStart;
            c_observerZoom.OnZoomStart += HandleZoomStart;
            Globals.OnClueFound += HandleClueFound;
        }

        void OnDisable()
        {
            c_observerPhoto.OnPhotoStart -= HandlePhotoStart;
            c_observerZoom.OnZoomStart -= HandleZoomStart;
            Globals.OnClueFound -= HandleClueFound;
        }

        private void HandlePhotoStart()
        {
            audioSource.PlayOneShot(audioClipPhoto);
        }

        private void HandleZoomStart()
        {
            audioSource.PlayOneShot(audioClipZoom);
        }

        private void HandleClueFound(ClueId _)
        {
            audioSource.PlayOneShot(audioClipClue);
        }
    }
}
