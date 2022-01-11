using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CheckPointManager))]
public class CheckPointManagerEditor : Editor
{
    private CheckPointManager checkPointManager;
    private void OnEnable()
    {
        checkPointManager = target as CheckPointManager;
        checkPointManager.checkPoints = new List<CheckPoint>();

    }
    public override void OnInspectorGUI()
    {
        for (int i = 0; i < checkPointManager.transform.childCount; i++)
        {
            var child =checkPointManager.transform.GetChild(i);
            CheckPoint checkPoint;
            
            if (child.TryGetComponent<CheckPoint>(out checkPoint))
            {
               
                if(!checkPointManager.checkPoints.Contains(checkPoint))
                checkPointManager.checkPoints.Add(checkPoint);
            }
        }
        for (int i = 0; i < checkPointManager.checkPoints.Count; i++)
        {
            checkPointManager.checkPoints[i].index = i;
        }
    }
}
