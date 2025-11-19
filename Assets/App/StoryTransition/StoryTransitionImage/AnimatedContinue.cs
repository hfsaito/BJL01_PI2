using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.App.StoryTransition.StoryTransitionImage
{
    public class AnimatedContinue : MonoBehaviour
    {
        private enum ANIMATION_STATE
        {
            IDLE,
            FADE_IN,
            FADE_OUT,
        }

        private Image[] images;
        private TMP_Text[] texts;
        private ANIMATION_STATE animationState;

        private readonly float FADE_DURATION_IN_SECS = 1f;
        private float animationStartedAt = -1f;
        private float animationProgress;
        private float currentAlpha;

        private Color aux_color;

        // public event System.Action<bool> OnAnimationFish;

        private Coroutine lastCoroutine;

        void Start()
        {
            images = GetComponentsInChildren<Image>();
            texts = GetComponentsInChildren<TMP_Text>();
            UpdateAlpha(0);
        }

        public void FadeIn()
        {
            if (animationState == ANIMATION_STATE.FADE_IN) return;
            if (lastCoroutine != null) StopCoroutine(lastCoroutine);
            lastCoroutine = StartCoroutine(FadeInWithDelay());
        }
        private readonly WaitForSeconds FADE_IN_DELAY = new(.5f);
        private System.Collections.IEnumerator FadeInWithDelay()
        {
            yield return FADE_IN_DELAY;
            animationState = ANIMATION_STATE.FADE_IN;
            animationStartedAt = Time.time - (currentAlpha * FADE_DURATION_IN_SECS);
        }

        public void FadeOut()
        {
            if (animationState == ANIMATION_STATE.FADE_OUT) return;
            if (lastCoroutine != null) StopCoroutine(lastCoroutine);
            animationState = ANIMATION_STATE.FADE_OUT;
            animationStartedAt = Time.time - ((1f - currentAlpha) * FADE_DURATION_IN_SECS);
        }

        void Update()
        {
            if (animationState == ANIMATION_STATE.IDLE) return;

            animationProgress = (Time.time - animationStartedAt) / FADE_DURATION_IN_SECS;
            UpdateAlpha(
                animationState == ANIMATION_STATE.FADE_IN ?
                animationProgress :
                (1f - animationProgress)
            );

            if (animationProgress >= 1f)
            {
                // StartCoroutine(TriggerAnimationFinishEvent(animationState));
                animationState = ANIMATION_STATE.IDLE;
            }
        }

        // private System.Collections.IEnumerator TriggerAnimationFinishEvent(ANIMATION_STATE stateWas)
        // {
        //     yield return new WaitForEndOfFrame();
        //     OnAnimationFish.Invoke(stateWas == ANIMATION_STATE.FADE_IN);
        // }

        private void UpdateAlpha(float newAlpha)
        {
            currentAlpha = newAlpha;
            foreach (var image in images)
            {
                aux_color = image.color;
                aux_color.a = newAlpha;
                image.color = aux_color;
            }
            foreach (var text in texts)
            {
                aux_color = text.color;
                aux_color.a = newAlpha;
                text.color = aux_color;
            }
        }
    }
}
