using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public IEnumerator Start(int seconds, bool randomisedColour, Action callBack)
    {
        for (var i = 0; i < seconds; i++)
        {
            text.text = i.ToString();

            if (randomisedColour)
            {
                text.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 1);
            }
            yield return oneSecond;
        }
        text.text = string.Empty;
        callBack();
    }
}
