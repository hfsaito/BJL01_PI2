using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

using Assets.App.Common.Scripts.CustomProperties.InputActionPicker;
using System.Collections;

namespace Assets.App.BlockTest.Scripts
{
    [RequireComponent(typeof(PixelPerfectCamera))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class CameraControls : MonoBehaviour
    {
        [InputActionPicker(InputActionType.Value, typeof(Vector2))]
        [SerializeField]
        private string moveActionId;
        private InputAction moveAction;
        private Vector2 moveValue;

        private InputActionMap actionMap;

        private Rigidbody2D rigidbody2dComponent;

        [InputActionPicker(InputActionType.Button)]
        [SerializeField]
        private string zoomActionId;
        private InputAction zoomAction;
        [SerializeField]
        private Animator animator;

        readonly WaitForSeconds delayBetweenZoomToggles = new(1f);

        private PixelPerfectCamera pixelPerfectCamera;

        void Awake()
        {
            moveAction = InputSystem.actions.FindAction(moveActionId);
            actionMap = moveAction.actionMap;
            actionMap.Enable();
            foreach (InputActionMap i_actionMap in InputSystem.actions.actionMaps)
            {
                if (i_actionMap != moveAction.actionMap)
                {
                    i_actionMap.Disable();
                }
            }

            zoomAction = InputSystem.actions.FindAction(zoomActionId);
            zoomAction.performed += OnToggleZoom;

            rigidbody2dComponent = GetComponent<Rigidbody2D>();
            pixelPerfectCamera = GetComponent<PixelPerfectCamera>();
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            moveValue = moveAction.ReadValue<Vector2>();
        }

        void FixedUpdate()
        {
            rigidbody2dComponent.linearVelocity = moveValue;
        }

        void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        void OnEnable()
        {
            actionMap.Enable();
        }

        void OnDisable()
        {
            actionMap.Disable();
        }

        private void OnToggleZoom(InputAction.CallbackContext context)
        {
            animator.SetTrigger("Toggle Trigger");
            if (pixelPerfectCamera.assetsPPU == 64)
            {
                pixelPerfectCamera.assetsPPU = 128;
            } else
            {
                pixelPerfectCamera.assetsPPU = 64;
            }
            StartCoroutine(DisableToggleTemporarily());
        }

        private IEnumerator DisableToggleTemporarily()
        {
            actionMap.Disable();
            yield return delayBetweenZoomToggles;
            actionMap.Enable();
        }
    }
}
