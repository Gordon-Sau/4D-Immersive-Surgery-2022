using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLine : MonoBehaviour
{
    public GameObject linePrefab; // for instantiating the line
    private LineController lineController = null;
    private GameObject line = null;

    private Transform currPoint = null;

    public void addPoint(Transform point) {
        if (lineController == null) {
            line = Instantiate<GameObject>(linePrefab, Vector3.zero, Quaternion.identity);
            lineController = line.GetComponent<LineController>();
            lineController.addDot(point);
            currPoint = point;
        } else {
            lineController.addDot(point);
            point.gameObject.GetComponent<ClickDot>().cancelClick();
            currPoint.gameObject.GetComponent<ClickDot>().cancelClick();
            currPoint = null;
            lineController = null;
        }
    }

    public void cancelPoint(Transform point) {
        if (currPoint == point) {
            currPoint.gameObject.GetComponent<ClickDot>().cancelClick();
            currPoint = null;
            Destroy(line);
            lineController = null;
            line = null;
        } else {
            Debug.Log("different point! Cannot cancelPoint!");
        }
    }

}
