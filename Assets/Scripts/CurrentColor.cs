using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CurrentColor : MonoBehaviour, IPointerClickHandler
{
    private GameObject c;

    [SerializeField]
    private GameObject currentC;

    public bool canDraw;
    public bool penDraw = true;


    //Lines variables
    public GameObject linePrefab;
    private LineRenderer lineColorRenderer;
    Line activeLine;
    private Color lineColor;
    List<GameObject> lineClones = new List<GameObject>();

    void Start(){
        lineColorRenderer = linePrefab.GetComponent<LineRenderer>();
        lineColor = Color.black;
        canDraw = false;
    }
    // Update is called once per frame
    void Update()
    {
        //Draws the lines
        if(Input.GetMouseButtonDown(0) && canDraw && penDraw){
            GameObject newLine = Instantiate(linePrefab);
            lineClones.Add(newLine);
            activeLine = newLine.GetComponent<Line>();
        }

        if(Input.GetMouseButtonUp(0)){
            activeLine = null;
        }

        if(activeLine != null && canDraw){
            Vector2 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mPosition);
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)   
    {
        c = pointerEventData.pointerCurrentRaycast.gameObject;
        Debug.Log("Clicked " + c.name);
        clicking(c);
        
    }

    public void clicking(GameObject c)
    {
        if(c.tag == "Colors"){
            lineColor = c.GetComponent<Image>().color;
            currentC.GetComponent<Image>().color = lineColor;
            lineColorRenderer.startColor = lineColor;
            lineColorRenderer.endColor = lineColor;
        }
        if(c.tag == "width1"){
            lineColorRenderer.startWidth = .15f;
            lineColorRenderer.endWidth = .15f;
        }
        if(c.tag == "width2"){
            lineColorRenderer.startWidth = .25f;
            lineColorRenderer.endWidth = .25f;
        }
        if(c.tag == "width3"){
            lineColorRenderer.startWidth = .4f;
            lineColorRenderer.endWidth = .4f;
        }
        if(c.tag == "pencil"){
            penDraw = true;
        }
        if(c.tag == "eraser"){
            foreach (GameObject x in lineClones){
                Destroy(x);
            }
        }
    }

}