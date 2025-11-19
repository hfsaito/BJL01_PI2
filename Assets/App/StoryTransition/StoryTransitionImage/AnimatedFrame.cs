using System;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.App.StoryTransition.StoryTransitionImage
{
    public enum ANIMATED_FRAME_ANIMATION_STATE
    {
        IDLE,
        TEXT_ANIMATION,
        FADE_OUT,
    }

    [RequireComponent(typeof(Image))]
    public class AnimatedFrame : MonoBehaviour
    {
        private Image image;

        private ANIMATED_FRAME_ANIMATION_STATE animationState;
        private float animationStartedAt;

        private Sprite[][] spritesOfFrames;
        private int currentFrame = -1;
        private int currentSprite;
        private int nextSprite;
        private readonly float TEXT_ANIMATION_STEP_IN_SECS = .05f;

        private float fadeProgress;
        private Color nextColor;
        private readonly float FADE_OUT_DURANTION_IN_SECS = 1f;

        public event System.Action<ANIMATED_FRAME_ANIMATION_STATE> OnAnimationFish;

        void Start()
        {
            image = GetComponent<Image>();

            spritesOfFrames = new Sprite[][] {
                Resources.LoadAll<Sprite>("StoryTransition/Intro/Frame 01").ToArray(),
                Resources.LoadAll<Sprite>("StoryTransition/Intro/Frame 02").ToArray(),
                Resources.LoadAll<Sprite>("StoryTransition/Intro/Frame 03").ToArray(),
                Resources.LoadAll<Sprite>("StoryTransition/Intro/Frame 04").ToArray(),
            };
        }

        void Update()
        {
            if (animationState == ANIMATED_FRAME_ANIMATION_STATE.IDLE) return;

            if (animationState == ANIMATED_FRAME_ANIMATION_STATE.TEXT_ANIMATION)
            {
                nextSprite = (int)((Time.time - animationStartedAt) / TEXT_ANIMATION_STEP_IN_SECS);
                if (nextSprite == currentSprite) return;
                if (nextSprite < spritesOfFrames[currentFrame].Length)
                {
                    currentSprite = nextSprite;
                    image.sprite = spritesOfFrames[currentFrame][currentSprite];
                    return;
                }
            }

            if (animationState == ANIMATED_FRAME_ANIMATION_STATE.FADE_OUT)
            {
                fadeProgress = (Time.time - animationStartedAt) / FADE_OUT_DURANTION_IN_SECS;
                nextColor = image.color;
                nextColor.a = 1f - fadeProgress;
                image.color = nextColor;
                if (fadeProgress < 1f) return;
            }

            StartCoroutine(TriggerAnimationFinishEvent(animationState));
            animationState = ANIMATED_FRAME_ANIMATION_STATE.IDLE;
        }

        private System.Collections.IEnumerator TriggerAnimationFinishEvent(ANIMATED_FRAME_ANIMATION_STATE stateWas)
        {
            yield return new WaitForEndOfFrame();
            OnAnimationFish.Invoke(stateWas);
        }

        public bool HasNextFrame()
        {
            return (currentFrame + 1) < spritesOfFrames.Length;
        }

        public void TriggerNextFrame()
        {
            if (HasNextFrame())
            {
                StartCoroutine(DelayedTextAnimation());
            } else
            {
                throw new NotImplementedException($"No folder with images in Resource\\Intro\\Frame {currentFrame}");
            }
        }
        private readonly WaitForSeconds DELAY_TO_START_TEXT_ANIMATION = new(1f);
        private System.Collections.IEnumerator DelayedTextAnimation()
        {
            if (animationState != ANIMATED_FRAME_ANIMATION_STATE.IDLE) yield break;
            yield return DELAY_TO_START_TEXT_ANIMATION;
            currentSprite = 0;
            currentFrame++;
            animationStartedAt = Time.time;
            animationState = ANIMATED_FRAME_ANIMATION_STATE.TEXT_ANIMATION;

            image.sprite = spritesOfFrames[currentFrame][currentSprite];
            image.color = Color.white;
        }

        public void FadeOut()
        {
            animationStartedAt = Time.time;
            animationState = ANIMATED_FRAME_ANIMATION_STATE.FADE_OUT;
            image.color = Color.white;
        }
    }
}
