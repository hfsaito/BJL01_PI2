using UnityEngine;

using Assets.App.BlockTest.Clues;

namespace Assets.App.BlockTest.Observer
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

        private void HandlePhotoStart()
        {
            audioSource.PlayOneShot(audioClipPhoto);
        }

        private void HandleZoomStart()
        {
            audioSource.PlayOneShot(audioClipZoom);
        }

        private void HandleClueFound(Clue _)
        {
            audioSource.PlayOneShot(audioClipClue);
        }
    }
}
