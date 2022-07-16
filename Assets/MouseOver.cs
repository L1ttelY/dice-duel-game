using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver:MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
	protected bool isMouseOver;
	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) { isMouseOver=true; }
	void IPointerExitHandler.OnPointerExit(PointerEventData eventData) { isMouseOver=false; }
	void IPointerClickHandler.OnPointerClick(PointerEventData eventData) { OnClick(); }
	protected virtual void OnClick() { }
}
