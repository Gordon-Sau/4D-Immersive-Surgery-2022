using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform startPoint = null;
    private Transform endPoint = null;

    private void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    public void addDot(Transform point) {
        if (startPoint == null) {
            startPoint = point;
        } else if (endPoint == null) {
            endPoint = point;
            lr.SetPosition(0, startPoint.position);
            lr.SetPosition(1, endPoint.position);
        } else {
            Debug.Log("There are already two dots in the line!");
        }
    }

    public LineRenderer getLineRenderer() {
        return lr;
    }
}
