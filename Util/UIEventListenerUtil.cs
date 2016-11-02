using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Game.Util
{
    public class UIEventListenerUtil :MonoBehaviour, 
        IDragHandler,IPointerClickHandler,IPointerDownHandler,
        IPointerUpHandler,IPointerEnterHandler,IPointerExitHandler
    {
        public delegate void VoidOpinterEventDelegate(PointerEventData go);
        public delegate void VoidBaseEventDelegate(BaseEventData go);
        public delegate void VoidAxisEventDelegate(AxisEventData go);
        public VoidOpinterEventDelegate onClick;
        public VoidOpinterEventDelegate onDown;
        public VoidOpinterEventDelegate onEnter;
        public VoidOpinterEventDelegate onExit;
        public VoidOpinterEventDelegate onUp;
        public VoidOpinterEventDelegate onDrag;
        public VoidOpinterEventDelegate onDragEnd;
        public VoidOpinterEventDelegate onDrop;
        public VoidOpinterEventDelegate onScroll;

        public VoidBaseEventDelegate onSelect;
        public VoidBaseEventDelegate onUpdateSelect;
        public VoidBaseEventDelegate onDeSelect;

        public VoidAxisEventDelegate onMove;
        public void OnPointerClick(PointerEventData eventData) { if (onClick != null) onClick(eventData); }
        public void OnPointerDown(PointerEventData eventData) { if (onDown != null) onDown(eventData); }
        public void OnPointerEnter(PointerEventData eventData) { if (onEnter != null) onEnter(eventData); }
        public void OnPointerExit(PointerEventData eventData) { if (onExit != null) onExit(eventData); }
        public void OnPointerUp(PointerEventData eventData) { if (onUp != null) onUp(eventData); }
        public void OnDrag(PointerEventData eventData) { if (onDrag != null) onDrag(eventData); }
        public void OnEndDrag(PointerEventData eventData) { if (onDragEnd != null) onDragEnd(eventData); }
        public void OnDrop(PointerEventData eventData) { if (onDrop != null) onDrop(eventData); }
        public void OnScroll(PointerEventData eventData) { if (onScroll != null) onScroll(eventData); }

        public void OnSelect(BaseEventData eventData) { if (onSelect != null) onSelect(eventData); }
        public void OnUpdateSelected(BaseEventData eventData) { if (onUpdateSelect != null) onUpdateSelect(eventData); }
        public void OnDeselect(BaseEventData eventData) { if (onDeSelect != null) onDeSelect(eventData); }

        public void OnMove(AxisEventData eventData) { if (onMove != null) onMove(eventData); }
        static public UIEventListenerUtil Get(GameObject go)
        {
            UIEventListenerUtil listener = go.GetComponent<UIEventListenerUtil>();
            if (listener == null) listener = go.AddComponent<UIEventListenerUtil>();
            return listener;
        }

    }

}