using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class GlobalPanel : MonoBehaviour
{
    public Image panel;
    public float lenght = 5;
    private void Start()
    {
        EventHandler.instance.OnTakeDamage += LaunchFade;
        EventHandler.instance.OnDeath += LaunchFade;
    }
    void LaunchFade()
    {
        StartCoroutine(Fade(lenght));
    }
    IEnumerator Fade(float timer)
    {
        for (float i = 0; i < timer/3f; i+=0.01f)
        {
            panel.color = Color.black * i * 3 / timer;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(timer / 3);
        for (float i =timer/3; i > 0 ; i -= 0.01f)
        {
            panel.color = Color.black * i  /3* timer;
            yield return new WaitForSeconds(0.01f);
        }
    }
    

}
