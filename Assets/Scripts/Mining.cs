using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{

    private float timer = 0;
    private bool isMining = false;
    private IEnumerator coroutineMine;

    IEnumerator Mine()
    {
        isMining = true;
        Debug.Log("Started mining");

        while (timer < 4)
        {
            yield return new WaitForSeconds(0);
            timer += Time.deltaTime;
        }

        Debug.Log("Finished mining");
        StopCoroutine(coroutineMine);
    }

    private void Start()
    {
        coroutineMine = Mine();
    }

    public string GenerateRessource()
    {
        return "Stone";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && !isMining)
            {
                StartCoroutine(coroutineMine);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopCoroutine(coroutineMine);
            Debug.Log("Stopped mining prematurely");
        }
    }
}
    
