using UnityEngine;
using TMPro;
using System.Collections;
public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreTex;
    public float displacementTimeVertical;
    public float displacementTimeHorizontal;
    public float distanceToReacheVertical;
    public float distanceToReacheHorizontal;
    private bool canMove;
    private bool isRed;
    void Start()
    {
        StartCoroutine(ScoreUpCoroutine());
    }
   
    private void ScoreUp(int value)
    {

    }
    IEnumerator ScoreUpCoroutine()
    {
        StartCoroutine(Move(Vector3.right, displacementTimeHorizontal, distanceToReacheHorizontal));
        yield return new WaitUntil(() => canMove);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Move(Vector3.up, displacementTimeVertical, distanceToReacheVertical, true));
        yield return new WaitUntil(() => canMove);
        yield return new WaitForSeconds(1.5f);

        StartCoroutine(Move(Vector3.left, displacementTimeHorizontal, distanceToReacheHorizontal));
    }

    IEnumerator Move(Vector3 direction, float displacementTime, float distance)
    {
        canMove = false;
        for (float i = 0; i < displacementTime; i+= 0.01f)
        {
            transform.Translate(direction * distance / displacementTime);
            yield return new WaitForSeconds(0.01f);
        }
        canMove = true;
       
    }

    IEnumerator Move(Vector3 direction, float displacementTime, float distance, bool changeColor)
    {
        canMove = false;
        float index = 0;
        bool doOnce= false;
        for (float i = 0; i < displacementTime; i += 0.01f)
        {
            scoreTex.text ="X "+ ScoreManager.instance.DisplayScore();
            if(i > index/5.0f* displacementTime)
            {
                index++;
                if (isRed)
                {
                    scoreTex.color = Color.white;
                }
                else
                    scoreTex.color = Color.red;
                isRed = !isRed;
            }
            if (i >= displacementTime / 2 && !doOnce)
            {
                doOnce = true;
                direction = -direction;
            }
            transform.Translate(direction * distance / displacementTime);
            yield return new WaitForSeconds(0.01f);
        }
        canMove = true;

    }
}
