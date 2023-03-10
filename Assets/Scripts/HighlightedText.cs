// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;
// using TMPro;

// public class HighlightedText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
// {
//     public enum TextType {Text, TMP};
//     [SerializeField] private TextType textType;

//     public Color highlightedColor;
//     public Color clickedColor;

//     private TMP_Text tmpTextComponent;
//     private Text textComponent;
//     private Material textMaterial;
//     private Color originalColor;

//     void Start()
//     {
//         if (textType == TextType.Text)
//         {
//             textComponent = GetComponent<Text>();
//             originalColor = textComponent.color;
//         }
//         else if (textType == TextType.TMP)
//         {
//             tmpTextComponent = GetComponent<TMP_Text>();
//             textMaterial = tmpTextComponent.fontMaterial;
//             originalColor = textMaterial.GetColor("_FaceColor");
//         }
//     }

//     public void OnPointerEnter(PointerEventData eventData)
//     {
//         if (textType == TextType.Text)
//         {
//             textComponent.color = highlightedColor;
//         }
//         else if (textType == TextType.TMP)
//         {
//             textMaterial.SetColor("_FaceColor", highlightedColor);
//             tmpTextComponent.UpdateMeshPadding();
//         }
//     }

//     public void OnPointerExit(PointerEventData eventData)
//     {
//         if (textType == TextType.Text)
//         {
//             textComponent.color = originalColor;
//         }
//         else if (textType == TextType.TMP)
//         {
//             textMaterial.SetColor("_FaceColor", originalColor);
//             tmpTextComponent.UpdateMeshPadding();
//         }
//     }

//     public void OnPointerClick(PointerEventData eventData)
//     {
//         if (textType == TextType.Text)
//         {
//             textComponent.color = clickedColor;
//         }
//         else if (textType == TextType.TMP)
//         {
//             textMaterial.SetColor("_FaceColor", clickedColor);
//             tmpTextComponent.UpdateMeshPadding();
//         }
//     }
// }



using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class HighlightedText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public enum TextType { Text, TMP };
    [SerializeField] private TextType textType;

    public Color highlightedColor;
    public Color clickedColor;

    private TMP_Text tmpTextComponent;
    private Text textComponent;
    private Material textMaterial;
    private Color originalColor;

    void Start()
    {
        if (textType == TextType.Text)
        {
            textComponent = GetComponent<Text>();
            originalColor = textComponent.color;
        }
        else if (textType == TextType.TMP)
        {
            tmpTextComponent = GetComponent<TMP_Text>();
            textMaterial = tmpTextComponent.fontMaterial;
            originalColor = textMaterial.GetColor("_FaceColor");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (textType == TextType.Text)
        {
            textComponent.color = highlightedColor;
        }
        else if (textType == TextType.TMP)
        {
            textMaterial.SetColor("_FaceColor", highlightedColor);
            tmpTextComponent.UpdateMeshPadding();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (textType == TextType.Text)
        {
            textComponent.color = originalColor;
        }
        else if (textType == TextType.TMP)
        {
            textMaterial.SetColor("_FaceColor", originalColor);
            tmpTextComponent.UpdateMeshPadding();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (textType == TextType.Text)
        {
            textComponent.color = clickedColor;
        }
        else if (textType == TextType.TMP)
        {
            textMaterial.SetColor("_FaceColor", clickedColor);
            tmpTextComponent.UpdateMeshPadding();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (textType == TextType.Text)
        {
            textComponent.color = originalColor;
        }
        else if (textType == TextType.TMP)
        {
            textMaterial.SetColor("_FaceColor", originalColor);
            tmpTextComponent.UpdateMeshPadding();
        }
    }
}
