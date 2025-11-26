using UnityEngine;

using Assets.App.Investigation.Observer;

namespace Assets.App.Common.Utils
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundWithFadeDistance : MonoBehaviour
    {
        private AudioSource c_walkAudioSource;
        private readonly float AUDIO_DISTANCE_MIN_VOLUME = .1f;
        private readonly float AUDIO_DISTANCE_MAX_VOLUME = 3.5f;
        private readonly float AUDIO_DISTANCE_PAN_STEREO = 2f;
        private float audioDistanceRange;
        private float audioVolumeDistance;

        void Start()
        {
            c_walkAudioSource = GetComponent<AudioSource>();
            audioDistanceRange = AUDIO_DISTANCE_MAX_VOLUME - AUDIO_DISTANCE_MIN_VOLUME;
        }

        void Update()
        {
            Update_FadeSoundOverDistance();
            Update_PanStereo();
        }

        private void Update_FadeSoundOverDistance()
        {
            audioVolumeDistance = Vector2.Distance(
                transform.position,
                Camera.main.transform.position
            );
            if (!Globals.ObserverZoomed)
            {
                audioVolumeDistance *= 2f;
            }
            c_walkAudioSource.volume = Mathf.Clamp(
                1f - ((audioVolumeDistance - AUDIO_DISTANCE_MIN_VOLUME) / audioDistanceRange),
                0f,
                1f
            );
        }

        private void Update_PanStereo()
        {
            c_walkAudioSource.panStereo = Mathf.Clamp(
                (
                    transform.position.x -
                    Camera.main.transform.position.x
                ) / AUDIO_DISTANCE_PAN_STEREO,
                -1f,
                1f
            );
        }
    }
}