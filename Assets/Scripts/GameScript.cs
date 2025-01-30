using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject collidersParent;
    public GameObject collidersParent2;
    public GameObject conditions;

    private float conditionAmount = 0;
    private float currentAmount = 0;
    private float maximumAmount = 0;
    private float currentAmount2 = 0;
    private float maximumAmount2 = 0;

    private TextMeshProUGUI currentAmountText;
    private TextMeshProUGUI currentAmountText2;
    private string subjectName;
    private string subjectName2;

    private GameObject NextLevelButton;

    [SerializeField] private AudioManager audioManager;

    private bool winSoundPlayed = false;

    void Start()
    {
        foreach (Transform anim in collidersParent.transform)
        {
            maximumAmount++;
            subjectName = anim.name;
        }
        foreach (Transform c in conditions.transform)
        {
            conditionAmount++;
        }
        if (conditionAmount == 2)
        {
            foreach (Transform anim in collidersParent2.transform)
            {
                maximumAmount2++;
                subjectName2 = anim.name;
            }
        }

        NextLevelButton = GameObject.Find("NextLevelButton");
        NextLevelButton.SetActive(false);
    }

    void Update()
    {
        FindAnimal();
    }

    private void FindAnimal()
    {
        if (Input.GetMouseButtonDown(0) && currentAmount < maximumAmount)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject.name == subjectName)
            {
                hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                currentAmountText = GameObject.Find(subjectName + "Amount").GetComponent<TextMeshProUGUI>();
                hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);

                audioManager.PlayFindObject();
                currentAmount++;
                currentAmountText.text = currentAmount + "/" + maximumAmount;
            }
        }

        if (conditionAmount == 2)
        {
            if (Input.GetMouseButtonDown(0) && currentAmount2 < maximumAmount2)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject.name == subjectName2)
                {
                    hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    currentAmountText2 = GameObject.Find(subjectName2 + "Amount").GetComponent<TextMeshProUGUI>();
                    hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);

                    audioManager.PlayFindObject();
                    currentAmount2++;
                    currentAmountText2.text = currentAmount2 + "/" + maximumAmount2;
                }
            }

            if (currentAmount == maximumAmount && currentAmount2 == maximumAmount2 && !winSoundPlayed)
            {
                audioManager.PlayWinSound();
                winSoundPlayed = true;
            }

            if (currentAmount == maximumAmount && currentAmount2 == maximumAmount2)
            {
                NextLevelButton.SetActive(true);
            }
        }
        else if (conditionAmount == 1)
        {
            if (currentAmount == maximumAmount && !winSoundPlayed)
            {
                audioManager.PlayWinSound();
                winSoundPlayed = true;
            }

            if (currentAmount == maximumAmount)
            {
                NextLevelButton.SetActive(true);
            }
        }
    }
}
