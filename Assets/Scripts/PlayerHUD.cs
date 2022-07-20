using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private SanmisController sanmisController;

    [SerializeField] private GameObject HUD;
    [SerializeField] private Image sanmiImage;
    [SerializeField] private Animator sanmiImageAnimatior;
    [SerializeField] private TextMeshProUGUI sanmiCounter;
    [SerializeField] private Animator sanmiCounterAnimatior;
    [SerializeField] private TextMeshProUGUI sanmiName;
    [SerializeField] private Animator sanmiNameAnimatior;



    private void Awake()
    {
        ShowHUD();

        SetTextMatchSanmiCount();
    }

    private void OnEnable()
    {
        sanmisController.OnNewSanmiAdded += DisplayNewAddedSanmi;
        sanmisController.OnSanmiRemoved += DisplayRemovedSanmi;

        EndOfGame.OnEndOfGameStart += HideHUD;
    }

    private void OnDisable()
    {
        sanmisController.OnNewSanmiAdded -= DisplayNewAddedSanmi;
        sanmisController.OnSanmiRemoved -= DisplayRemovedSanmi;

        EndOfGame.OnEndOfGameStart -= HideHUD;
    }




    private void ShowHUD()
    {
        HUD.SetActive(true);
    }

    private void HideHUD()
    {
        HUD.SetActive(false);
    }


    private void DisplayNewAddedSanmi(Sanmi.SanmiType sanmiType)
    {
        SetTextMatchSanmiCount();

        sanmiCounterAnimatior.SetTrigger("Add");

        sanmiName.text = Sanmi.names[(int)sanmiType];
        sanmiNameAnimatior.SetTrigger("Display");
    }

    private void DisplayRemovedSanmi()
    {
        SetTextMatchSanmiCount();

        StopCoroutine("SanmiImageHurted");
        StartCoroutine("SanmiImageHurted", 1.0f);

        sanmiImageAnimatior.SetTrigger("Shake");
    }

    private void SetTextMatchSanmiCount()
    {
        sanmiCounter.text = "x" + sanmisController.sanmiCount;
    }

    IEnumerator SanmiImageHurted(float duration)
    {
        sanmiImage.color = Color.red;
        yield return new WaitForSeconds(duration);
        sanmiImage.color = Color.white;
    }



}
