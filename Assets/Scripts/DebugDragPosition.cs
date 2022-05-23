using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DebugDragPosition : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    [SerializeField]
    private DragHandler _dragHandler;

    private void Awake()
    {
        _dragHandler.OnDragEvent += OnDrag;
        _dragHandler.OnEndDragEvent += OnEndDrag;
    }

    private void OnDrag(PointerEventData eventData)
    {
        var pos = eventData.position;
        _text.text = string.Format("{0}, {1}", pos.x.ToString("F0"), pos.y.ToString("F0"));
    }

    private void OnEndDrag(PointerEventData eventData)
    {
        _text.text = string.Empty;
    }
}