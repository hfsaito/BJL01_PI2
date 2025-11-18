using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.Investigation.Observer
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ObserverControls))]
    [RequireComponent(typeof(ObserverZoom))]
    public class ObserverTutorial : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        private ObserverControls c_observerControls;

        private GameObject tutorialFollow;

        void Start()
        {
            c_observerControls = GetComponent<ObserverControls>();
        }

        void Update()
        {
            if (tutorialFollow != null)
            {
                transform.position = tutorialFollow.transform.position;
            }
        }

        public void TutorialStart(GameObject target)
        {
            tutorialFollow = target;
            c_observerControls.MoveAction.Disable();
            c_observerControls.ZoomAction.Disable();
            c_observerControls.PhotoAction.Disable();
        }

        public void TutorialSetZoomEnabled(bool enabled)
        {
            if (enabled)
            {
                c_observerControls.ZoomAction.Enable();
            } else
            {
                c_observerControls.ZoomAction.Disable();
            }
        }

        public void TutorialSetPhotoEnabled(bool enabled)
        {
            if (enabled)
            {
                c_observerControls.PhotoAction.Enable();
            } else
            {
                c_observerControls.PhotoAction.Disable();
            }
        }

        public void TutorialEnd()
        {
            tutorialFollow = null;
            c_observerControls.MoveAction.Enable();
            c_observerControls.ZoomAction.Enable();
            c_observerControls.PhotoAction.Enable();
        }
    }
}
