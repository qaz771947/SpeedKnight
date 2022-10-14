using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    public bool left = false, right = false, beenTouch = false;
    public bool playerBeenHit = false;
    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        beenTouch = false;
        if (!playerBeenHit && !playerController.isDead)
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
        else
        {
            left = false;
            right = false;
            beenTouch = false;
            playerController.isDead = true;
        }





    }

    public void ResetData()
    {
        left = false;
        right = false;
        beenTouch = false;
        playerBeenHit = false;
    }
}
