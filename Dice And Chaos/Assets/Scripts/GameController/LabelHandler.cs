using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DiceAndChaos
{

    public class LabelHandler : MonoBehaviour
    {
        public GameObject resultLabel;
        private Text resultText;

        public GameObject pathLabel;
        private Text pathText;

        public GameObject jobsStatusLabel;
        private Text jobsStatusText;

        private void Start()
        {
            resultText = resultLabel.GetComponent<Text>();
            resultLabel.SetActive(false);
            pathText = pathLabel.GetComponent<Text>();
            pathLabel.SetActive(false);
            jobsStatusLabel.SetActive(false);
            jobsStatusText = jobsStatusLabel.GetComponent<Text>();
        }

        public void ShowResult(string result)
        {
            resultText.text = "The result: " + result;
            StartCoroutine("IEShowResult");
        }

        IEnumerator IEShowResult()
        {
            resultLabel.SetActive(true);
            yield return new WaitForSeconds(3);
            resultLabel.SetActive(false);
        }

        public void ShowPath()
        {
            pathText.text = "The results are saved to a file: " + Logger.path;
            pathLabel.SetActive(true);
            jobsStatusLabel.SetActive(true);
        }

        public void HidePath()
        {
            pathLabel.SetActive(false);
            jobsStatusLabel.SetActive(false);
        }

        public void UpdateJobs(float value)
        {
            jobsStatusText.text = (100 * value).ToString("0.00") + "%";
        }

    }

}