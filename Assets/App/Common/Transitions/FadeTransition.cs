using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.App.Common.Transitions
{
    [RequireComponent(typeof(Image))]
    public class FadeTransition : MonoBehaviour
    {
        private Image c_image;
        private Color aux_color;

        [HideInInspector] public event System.Action OnSceneLoadStart;

        private float startedAt;
        private readonly float duration = 1;

        private enum AnimationState
        {
            Idle,
            FadeOut,
            FadeIn,
        }
        private AnimationState state;

        void Start()
        {
            c_image = GetComponent<Image>();
            FadeOut();
        }

        void Update()
        {
            if (state == AnimationState.Idle)
            {
                return;
            }
            UpdateFadeOut();
            UpdateFadeIn();
        }

        private void UpdateFadeOut()
        {
            if (state != AnimationState.FadeOut)
            {
                return;
            }
            aux_color = c_image.color;
            aux_color.a = Mathf.Clamp(1f - ((Time.time - startedAt) / duration), 0f, 1f);
            c_image.color = aux_color;
            if (aux_color.a == 0f)
            {
                c_image.raycastTarget = false;
                state = AnimationState.Idle;
            }
        }

        private void UpdateFadeIn()
        {
            if (state != AnimationState.FadeIn)
            {
                return;
            }
            aux_color = c_image.color;
            aux_color.a = Mathf.Clamp((Time.time - startedAt) / duration, 0f, 1f);
            c_image.color = aux_color;
            if (aux_color.a == 1f)
            {
                state = AnimationState.Idle;
            }
        }

        private void FadeOut()
        {
            aux_color = c_image.color;
            aux_color.a = 1;
            c_image.color = aux_color;
            state = AnimationState.FadeOut;
            startedAt = Time.time;
        }

        public void AsyncLoadScene(string sceneName)
        {
            aux_color = c_image.color;
            aux_color.a = 0;
            c_image.color = aux_color;
            c_image.raycastTarget = true;
            state = AnimationState.FadeIn;
            startedAt = Time.time;
            OnSceneLoadStart?.Invoke();
            StartCoroutine(LoadYourAsyncScene(sceneName));
        }

        private System.Collections.IEnumerator LoadYourAsyncScene(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                if (
                    asyncLoad.progress >= 0.9f &&
                    state == AnimationState.Idle
                )
                {
                    asyncLoad.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}
