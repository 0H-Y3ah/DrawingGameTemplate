using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    private string click;

    Line activeLine;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) ){
            GameObject newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<Line>();
        }

        if(Input.GetMouseButtonUp(0)){
            activeLine = null;
        }

        if(activeLine != null){
            Vector2 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mPosition);
        }
    }

    
}
