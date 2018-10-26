using System.Collections;
using UnityEngine;

public class Mining : MonoBehaviour
{

    private float timer = 0;
    private bool isMining = false;
    private IEnumerator coroutineMine;
    private enum Ressources
    {
        Stone,
        Iron,
        Gold
    }

    IEnumerator Mine()
    {
        isMining = true;
        Debug.Log("Started mining");

        while (timer < 4)
        {
            yield return new WaitForSeconds(0);
            timer += Time.deltaTime;
        }

        Debug.Log("Finished mining. You mined " + GenerateRessource());
        timer = 0;
        isMining = false;
        StopCoroutine(coroutineMine);

    }

    public string GenerateRessource()
    {
        float rng = Random.value;
        string ressource = null;

        if (rng < 0.5f)
        {
            ressource = Ressources.Stone.ToString();
        }
        else if (rng > 0.5f && rng < 0.9f)
        {
            ressource = Ressources.Iron.ToString();
        }
        else if (rng > 0.9f && rng < 1)
        {
            ressource = Ressources.Gold.ToString();
        }

        return ressource;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && !isMining)
            {
                coroutineMine = Mine();
                StartCoroutine(coroutineMine);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isMining)
            {
                isMining = false;
                StopCoroutine(coroutineMine);
                Debug.Log("Stopped mining prematurely");
            }
        }
    }
}

