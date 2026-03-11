using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // ✅ This is required

public class UIButtonSound : MonoBehaviour, IPointerClickHandler
{
    public AudioClip clickSound;

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySFX(clickSound);
    }
}
