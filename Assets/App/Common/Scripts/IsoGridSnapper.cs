using UnityEngine;

namespace Assets.App.Common.Scripts
{
    [ExecuteInEditMode]
    public class IsoGridSnapper : MonoBehaviour
    {
        [SerializeField]
        private Vector2 isoOffset;

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

            sizedInputX = input.x / sizeX;
            sizedInputY = input.y / sizeY;

            isoX = sizedInputX + sizedInputY - isoOffset.x;
            isoY = -sizedInputX + sizedInputY - isoOffset.y;

            snappedIsoX = Mathf.Round(isoX) + isoOffset.x;
            snappedIsoY = Mathf.Round(isoY) + isoOffset.y;

            output = new(
                (snappedIsoX - snappedIsoY) * (.5f * sizeX),
                (snappedIsoX + snappedIsoY) * (.5f * sizeY)
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
