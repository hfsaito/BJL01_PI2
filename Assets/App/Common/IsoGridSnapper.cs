using UnityEngine;

using Assets.App.Common.CustomProperties.Vector2WithLimits;

#if UNITY_EDITOR
namespace Assets.App.Common
{
    [ExecuteInEditMode]
    public class IsoGridSnapper : MonoBehaviour
    {
        [Vector2WithLimits(-.5f, .5f, -.5f, .5f)]
        [SerializeField]
        private Vector2 isoOffset;

        [Vector2WithLimits(-.5f, .5f, -.5f, .5f)]
        [SerializeField]
        private Vector2 cartesianOffset;

        private Grid gridComponent;

        private Vector2 input;
        private Vector2 output;

        private float sizeX;
        private float sizeY;
        private float sizedInputX;
        private float sizedInputY;
        private float isoX;
        private float isoY;
        private float snappedIsoX;
        private float snappedIsoY;

        void Start()
        {
            GetGrid();
        }

        void OnTransformParentChanged()
        {
            GetGrid();
        }

        void Update()
        {
            Snap();
        }

        void OnValidate()
        {
            if (enabled)
            {
                Snap(true);
            }
        }

        private void Snap(bool recalculate = false)
        {
            if (gridComponent == null) return;

            input = transform.position;
            if (!recalculate && input == output) return;

            sizeX = gridComponent.cellSize.x;
            sizeY = gridComponent.cellSize.y;

            sizedInputX = (input.x / sizeX) - cartesianOffset.x;
            sizedInputY = (input.y / sizeY) - cartesianOffset.y;

            isoX = sizedInputX + sizedInputY - isoOffset.x;
            isoY = -sizedInputX + sizedInputY - isoOffset.y;

            snappedIsoX = Mathf.Round(isoX) + isoOffset.x;
            snappedIsoY = Mathf.Round(isoY) + isoOffset.y;

            output = new(
                (snappedIsoX - snappedIsoY + cartesianOffset.x) * (.5f * sizeX),
                (snappedIsoX + snappedIsoY + cartesianOffset.y) * (.5f * sizeY)
            );

            transform.position = output;
        }

        private void GetGrid()
        {
            gridComponent = GetComponentInParent<Grid>();
            if (gridComponent == null)
            {
                Debug.LogError($"Missing parent with Grid component.", gameObject);
            }
            if (gridComponent.cellLayout != GridLayout.CellLayout.Isometric)
            {
                gridComponent = null;
            }
        }
    }
}
#endif
