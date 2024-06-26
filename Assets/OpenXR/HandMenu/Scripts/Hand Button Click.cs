using UnityEngine;
using UnityEngine.UI;

public class HandButtonClick : MonoBehaviour
{
    [SerializeField] private Button button;

    private void OnTriggerEnter(Collider other)
    {
        button.targetGraphic.color = button.colors.pressedColor;
        button.onClick.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        button.targetGraphic.color = button.colors.normalColor;
    }
}
