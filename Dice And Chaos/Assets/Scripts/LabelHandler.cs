using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelHandler : MonoBehaviour
{

    public GameObject label;
    private Text text;

    private void Start()
    {
        text = label.GetComponent<Text>();
        label.SetActive(false);
    }

    public void ShowResult(string result)
    {
        text.text = "The result: " + result;
        StartCoroutine("IEShowResult");
    }

    IEnumerator IEShowResult()
    {
        label.SetActive(true);
        yield return new WaitForSeconds(3);
        label.SetActive(false);
    }

}
