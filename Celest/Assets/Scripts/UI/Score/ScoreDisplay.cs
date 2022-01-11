using UnityEngine;
using TMPro;
using System.Collections;
public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreTex;
    public float displacementTimeHorizontal;
    public float distanceToReacheHorizontal;
    void Start()
    {
        StartCoroutine(Move(Vector3.right, displacementTimeHorizontal, distanceToReacheHorizontal));
    }
   
    private void ScoreUp(int value)
    {

    }

    IEnumerator Move(Vector3 direction, float displacementTime, float distance)
    {
        for (float i = 0; i < displacementTime; i+= 0.01f)
        {
            transform.Translate(direction * distance / displacementTime);
            yield return new WaitForSeconds(0.01f);
        }
        for (float i = 0; i < displacementTime; i += 0.01f)
        {
            transform.Translate(direction * distance / displacementTime);
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    
}
