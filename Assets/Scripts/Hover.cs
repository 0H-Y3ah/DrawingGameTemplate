using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CurrentColor c;
    
    public void OnPointerEnter(PointerEventData e){
        c.canDraw = true;
    }
    public void OnPointerExit(PointerEventData e){
        c.canDraw = false;
    }
}
