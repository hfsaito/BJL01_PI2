using UnityEngine;

namespace Assets.App.Common.WorldBounds
{
    [RequireComponent(typeof(RectTransform))]
    public class WorldBoundsSetter : MonoBehaviour
    {
        private RectTransform c_rectTransform;

        void Awake()
        {
            c_rectTransform = GetComponent<RectTransform>();
            Globals.WorldBounds = new(
                c_rectTransform.rect.center,
                c_rectTransform.rect.size
            );
        }

        #region EDITOR
        void OnDrawGizmos()
        {
            GetRectTransform();
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, c_rectTransform.rect.size);
        }

        void OnDrawGizmosSelected()
        {
            GetRectTransform();
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, c_rectTransform.rect.size);
        }

        private void GetRectTransform()
        {
            if (c_rectTransform == null)
            {
                c_rectTransform = GetComponent<RectTransform>();
            }
        }
        #endregion
    }
}
