using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] ModeSupervisor modeSupervisor;
    [SerializeField] PlayerController playerController;
    public bool left = false, right = false, beenTouch = false;
    public bool playerBeenHit = false;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(GetScript());
    }

    // Update is called once per frame
    void Update()
    {
        beenTouch = false;
        if (playerBeenHit)
        {
            if (modeSupervisor.modeNum == 1)
            {
                playerController.isDead = true;
            }
            else
            {
                playerController.isDizzy = true;
            }
            
        }

        if(!playerController.isDead && !playerController.isDizzy) 
        {
            Control();
        }
        else
        {            
            left = false;
            right = false;
            beenTouch = false;
        }





    }

    private void Control()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            FindObjectOfType<AudioManager>().Play("Attack");
            left = true;
            right = false;
            beenTouch = true;
            Debug.Log("ек");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            FindObjectOfType<AudioManager>().Play("Attack");
            right = true;
            left = false;
            beenTouch = true;
            Debug.Log("еk");
        }
    }

    public void ResetData()
    {
        left = false;
        right = false;
        beenTouch = false;
        playerBeenHit = false;
    }
    IEnumerator GetScript()
    {
        yield return new WaitForSeconds(0.1f);
        modeSupervisor = FindObjectOfType<ModeSupervisor>();
        playerController = gameObject.GetComponent<PlayerController>();
    }
}
