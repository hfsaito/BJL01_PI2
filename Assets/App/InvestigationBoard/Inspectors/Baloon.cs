using UnityEngine;
using UnityEngine.UI;

namespace Assets.App.InvestigationBoard.Inspectors
{
    [RequireComponent(typeof(Image))]
    public class Baloon : MonoBehaviour
    {
        private Image c_image;
        private Color aux_color;

        void Awake()
        {
            c_image = GetComponent<Image>();
            aux_color = c_image.color;
            aux_color.a = 0f;
            c_image.color = aux_color;
        }

        void OnEnable()
        {
            BaloonConnector.OnInspectPointerEnter += DisplayImage;
            BaloonConnector.OnInspectPointerExit += ClearImage;
        }

        void OnDisable()
        {
            BaloonConnector.OnInspectPointerEnter -= DisplayImage;
            BaloonConnector.OnInspectPointerExit -= ClearImage;
        }

        // private void UpdateImage(string imagePath)
        // {
        //     if (imagePath == "")
        //     {
        //         ClearImage();
        //     } else
        //     {
        //         DisplayImage(imagePath);
        //     }
        // }

        private void ClearImage()
        {
            aux_color = c_image.color;
            aux_color.a = 0f;
            c_image.color = aux_color;
            c_image.sprite = null;
        }

        private void DisplayImage(string imagePath)
        {
            Sprite sprite = Resources.Load<Sprite>(imagePath);
            aux_color = c_image.color;
            aux_color.a = 1f;
            c_image.color = aux_color;
            c_image.sprite = sprite;
        }
    }
}
