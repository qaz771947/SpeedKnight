using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] UIManager uIManager;
    [SerializeField] GameObject player;
    [SerializeField] PlayerController playerController;
    [SerializeField] InputController inputController;
    public int m_seconds;
    public int m_min;
    public int m_sec;
    public GameObject text;
    public Text m_timer;
    public bool dizzyTimeOver = true;
    [SerializeField] int tempTime = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        m_seconds = (m_min * 60) + m_sec;
        tempTime = m_seconds;
        uIManager = gameObject.GetComponent<UIManager>();
        StartCoroutine(GetScript());
    }

    private void Update()
    {
        if (!dizzyTimeOver)
        {
            text.SetActive(true);
            
            StartCoroutine(Countdown());
        }
    }

    private IEnumerator Countdown()
    {
        uIManager.ResetTarget();
        while (m_seconds > 0)
        {
            m_timer.text = m_seconds.ToString();
            yield return new WaitForSeconds(1);

            m_seconds--;
            m_sec--;

            if (m_sec < 0 && m_min > 0)
            {
                m_min -= 1;
                m_min = 59;

            }
            else if (m_sec < 0 && m_min == 0)
            {
                m_sec = 0;
            }            

        }

        yield return new WaitForSeconds(1);
        inputController.playerBeenHit = false;
        playerController.isDizzy = false;
        dizzyTimeOver = true;
        m_seconds = tempTime;
        text.SetActive(false);

    }
    IEnumerator findPlayer() 
    {
        yield return new WaitForSeconds(0.1f);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    IEnumerator GetScript()
    {
        bool done = false;
        yield return StartCoroutine(findPlayer());
        playerController = player.gameObject.GetComponent<PlayerController>();
        inputController = player.gameObject.GetComponent<InputController>();
        done = true;
        yield return new WaitWhile(() => done == false);
    }
}
