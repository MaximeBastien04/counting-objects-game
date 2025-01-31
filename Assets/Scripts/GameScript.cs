using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private Animator bigBox;
    private Animator smallBox1;
    private Animator smallBox2;
    private bool smallBox1Animationplayed = false;
    private bool smallBox2Animationplayed = false;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2")
        {
            bigBox = GameObject.Find("BigNumberBox").GetComponent<Animator>();
        }
        else if (SceneManager.GetActiveScene().name == "Level3" || SceneManager.GetActiveScene().name == "Level4")
        {
            smallBox1 = GameObject.Find("SmallNumberBox1").GetComponent<Animator>();
            smallBox2 = GameObject.Find("SmallNumberBox2").GetComponent<Animator>();
        }
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            smallBox1.SetTrigger("shake");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            smallBox2.SetTrigger("shake");
        }
    }

    private void FindAnimal()
    {
        if (conditionAmount == 1)
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
                else
                {
                    audioManager.WrongItem();
                }
            }

            if (currentAmount == maximumAmount && !winSoundPlayed)
            {
                bigBox.SetTrigger("shake");
                audioManager.PlayWinSound();
                winSoundPlayed = true;
            }

            if (currentAmount == maximumAmount)
            {
                NextLevelButton.SetActive(true);
            }
        }

        if (conditionAmount == 2)
        {
            if (Input.GetMouseButtonDown(0) && currentAmount <= maximumAmount && currentAmount2 <= maximumAmount2)
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
                else if (hit.collider != null && hit.collider.gameObject.name == subjectName2)
                {
                    hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    currentAmountText2 = GameObject.Find(subjectName2 + "Amount").GetComponent<TextMeshProUGUI>();
                    hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);

                    audioManager.PlayFindObject();
                    currentAmount2++;
                    currentAmountText2.text = currentAmount2 + "/" + maximumAmount2;
                }
                else if (hit.collider == null || hit.collider.gameObject.name != subjectName || hit.collider.gameObject.name != subjectName2)
                {
                    audioManager.WrongItem();
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


            // Play shake animation when condition is met
            if (currentAmount == maximumAmount && !smallBox1Animationplayed)
            {
                smallBox1.SetTrigger("shake");
                smallBox1Animationplayed = true;
            }
            if (currentAmount2 == maximumAmount2 && !smallBox2Animationplayed)
            {
                smallBox2.SetTrigger("shake");
                smallBox2Animationplayed = true;
            }
        }
    }
}
