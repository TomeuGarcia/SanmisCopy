using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndOfGame : MonoBehaviour
{
    [SerializeField] GameObject endOfGameCanvas;

    [SerializeField] CanvasGroup[] canvasGroupScores;
    [SerializeField] TextMeshProUGUI[] textScores;

    [SerializeField] GameObject objectTime;
    [SerializeField] TextMeshProUGUI textTime;

    [SerializeField] GameObject objectTotalScore;

    private float totalTime;


    private void Awake()
    {
        HideAllCanvas();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartOnGameEnd(other.gameObject);
        }

    }


    private void StartOnGameEnd(GameObject playerGameObject)
    {
        playerGameObject.GetComponentInParent<CharacterMovement>().DisableMovement();
        
        SanmisController sanmisController = playerGameObject.GetComponentInParent<SanmisController>();

        StartCoroutine(ScoreSequence(sanmisController.GetSanmis()));
    }

    private void HideAllCanvas()
    {
        for (int i = 0; i < canvasGroupScores.Length; ++i)
        {
            canvasGroupScores[i].alpha = 0.0f;
            textScores[i].text = "";
        }

        objectTime.SetActive(false);
        textTime.text = "";

        objectTotalScore.SetActive(false);
        

        endOfGameCanvas.SetActive(false);
    }


    IEnumerator ScoreSequence(Dictionary<Sanmi.SanmiType, int> sanmis)
    {
        endOfGameCanvas.SetActive(true);

        float scoreIncDuration = 0.5f;
        float displayFinishDuration = 1.0f;

        for (int i = 0; i < sanmis.Count; ++i)
        {
            canvasGroupScores[i].alpha = 1.0f;

            Sanmi.SanmiType sanmiType = (Sanmi.SanmiType)i;
            Debug.Log(sanmis[sanmiType]);
            for (int sanmiCount = 0; sanmiCount <= sanmis[sanmiType]; ++sanmiCount)
            {
                textScores[i].text = "x" + sanmiCount;
                yield return new WaitForSeconds(scoreIncDuration - (Time.deltaTime * 10.0f * sanmiCount));
            }

            textScores[i].text += " = " + sanmis[sanmiType] * Sanmi.scores[i] + "p";

            yield return new WaitForSeconds(displayFinishDuration);

        }






    }


}
