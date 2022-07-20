using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    [SerializeField] GameObject endOfGameCanvas;

    [SerializeField] CanvasGroup[] canvasGroupScores;
    [SerializeField] TextMeshProUGUI[] textScores;

    [SerializeField] GameObject objectTime;
    [SerializeField] TextMeshProUGUI textTime;
    [SerializeField] GameObject objectNegativeScoreTime;
    [SerializeField] TextMeshProUGUI textNegativeScoreTime;

    [SerializeField] GameObject objectTotalScore;
    [SerializeField] TextMeshProUGUI textTotalScore;

    private float totalTime = 0.0f;
    private bool playerArrivedToEnd = false;


    public delegate void EndOfGameAction();
    public static event EndOfGameAction OnEndOfGameStart;
    public static event EndOfGameAction OnEndOfGameFinish; // TODO use to reload scene


    private void Awake()
    {
        HideAllCanvas();
    }

    private void Start()
    {
        StartCoroutine(CountTime());
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
        if (OnEndOfGameStart != null) OnEndOfGameStart();

        playerArrivedToEnd = true;

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
        objectNegativeScoreTime.SetActive(false);
        textNegativeScoreTime.text = "";

        objectTotalScore.SetActive(false);
        

        endOfGameCanvas.SetActive(false);
    }


    IEnumerator ScoreSequence(Dictionary<Sanmi.SanmiType, int> sanmis)
    {
        endOfGameCanvas.SetActive(true);

        float scoreIncDuration = 0.5f;
        float displayFinishDuration = 1.0f;

        int totalPoints = 0;

        for (int i = 0; i < sanmis.Count; ++i)
        {
            canvasGroupScores[i].alpha = 1.0f;

            Sanmi.SanmiType sanmiType = (Sanmi.SanmiType)i;
            for (int sanmiCount = 0; sanmiCount <= sanmis[sanmiType]; ++sanmiCount)
            {
                textScores[i].text = "x" + sanmiCount;
                yield return new WaitForSeconds(scoreIncDuration - (Time.deltaTime * 10.0f * sanmiCount));
            }

            int sanmiTypePoints = sanmis[sanmiType] * Sanmi.scores[i];
            textScores[i].text += " = " + sanmiTypePoints + "p";

            totalPoints += sanmiTypePoints;

            yield return new WaitForSeconds(displayFinishDuration);

        }


        objectTime.SetActive(true);

        int totalMinutes = (int)(totalTime / 60);
        int totalSeconds = (int)(totalTime % 60);

        textTime.text = "Time: " + totalMinutes + ":" + (totalSeconds < 10 ? "0" : "") + totalSeconds;

        yield return new WaitForSeconds(displayFinishDuration);

        objectNegativeScoreTime.SetActive(true);

        int negativeTimePoints = -(int)totalTime;
        totalPoints -= negativeTimePoints; 
        textNegativeScoreTime.text = "=\n" + negativeTimePoints + "p";

        yield return new WaitForSeconds(displayFinishDuration);


        objectTotalScore.SetActive(true);
        textTotalScore.text = totalPoints + "p";


        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator CountTime()
    {
        while (!playerArrivedToEnd)
        {
            totalTime += Time.deltaTime;
            yield return null;
        }
    }


}
