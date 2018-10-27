using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Mining : MonoBehaviour
{
    private PlayerInventory playerInventory;
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

        while (timer < 4)
        {
            yield return new WaitForSeconds(0);
            timer += Time.deltaTime;
            GameObject.Find("MiningBar").GetComponent<Image>().fillAmount = timer / 4;
        }

        GenerateRessource();
        timer = 0;
        GameObject.Find("MiningBar").GetComponent<Image>().fillAmount = timer;
        isMining = false;
        StopCoroutine(coroutineMine);

    }

    private void Start()
    {
        playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>(); 
    }

    public void GenerateRessource()
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

        playerInventory.AddItem(ressource);
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

