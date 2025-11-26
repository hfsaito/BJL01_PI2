using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.App.StoryTransition.StoryTransitionImage
{
    public class ManageAnimatedObjects : MonoBehaviour
    {
        private AnimatedFrame storyTransitionImageAnimator;
        private AnimatedContinue storyTransitionImageContinue;
        private InputSystem_Actions input;

        void Awake()
        {
            input = new();
        }

        void OnEnable()
        {
            input.Observer.Continue.performed += HandleContinue;
        }

        void OnDisable()
        {
            input.Disable();
            input.Observer.Continue.performed -= HandleContinue;
        }

        void Start()
        {
            storyTransitionImageAnimator = GetComponentInChildren<AnimatedFrame>();
            storyTransitionImageContinue = GetComponentInChildren<AnimatedContinue>();
            input.Disable();

            storyTransitionImageAnimator.OnAnimationFish += HandleFrameAnimationEnd;

            StartCoroutine(LateStart());
        }

        private System.Collections.IEnumerator LateStart()
        {
            yield return new WaitForEndOfFrame();
            storyTransitionImageAnimator.TriggerNextFrame();
        }

        private void HandleFrameAnimationEnd(ANIMATED_FRAME_ANIMATION_STATE stateWas)
        {
            switch (stateWas)
            {
                case ANIMATED_FRAME_ANIMATION_STATE.TEXT_ANIMATION:
                    storyTransitionImageContinue.FadeIn();
                    input.Enable();
                    break;
                case ANIMATED_FRAME_ANIMATION_STATE.FADE_OUT:
                    if (storyTransitionImageAnimator.HasNextFrame())
                    {
                        storyTransitionImageAnimator.TriggerNextFrame();
                    } else
                    {
                        LoadInvestigationNight();
                    }
                    break;
            }
        }

        private void HandleContinue(InputAction.CallbackContext _)
        {
            storyTransitionImageAnimator.FadeOut();
            storyTransitionImageContinue.FadeOut();
            input.Disable();
        }

        private void LoadInvestigationNight()
        {
            string nextSceneName = $"InvestigationNight";
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
