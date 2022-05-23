using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Action<PointerEventData> OnBeginDragEvent;

    public Action<PointerEventData> OnDragEvent;

    public Action<PointerEventData> OnEndDragEvent;

    /// <summary> 自身が所属してるキャンバス </summary>
    private Canvas _belongedCanvas;

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragEvent?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragEvent?.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragEvent?.Invoke(eventData);
    }

    /// <summary>
    /// スクリーン座標を自身が所属してるキャンバス上の座標に変換
    /// 本プロジェクトでは端末の解像度に移動しない操作量を計算する目的で使用している
    /// </summary>
    /// <param name="pointerPos">クリーン座標</param>
    /// <returns>自身が所属してるキャンバス上の座標</returns>
    public Vector2 GetPositionOnCanvas(Vector2 pointerPos)
    {
        if(_belongedCanvas == null)
        {
            _belongedCanvas = GetBelongedCanvas(transform);
        }
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_belongedCanvas.transform as RectTransform, pointerPos, _belongedCanvas.worldCamera, out Vector2 localPointerPos);
        return localPointerPos;
    }

    /// <summary> 所属するCanvasを取得 </summary>
    private Canvas GetBelongedCanvas(Transform t)
    {
        if (t == null)
        {
            return null;
        }

        var canvas = t.GetComponent<Canvas>();
        if (canvas != null)
        {
            return canvas;
        }

        return GetBelongedCanvas(t.parent);
    }
}