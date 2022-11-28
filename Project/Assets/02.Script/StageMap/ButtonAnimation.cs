using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField] ButtonList buttonList;
    [SerializeField] GameObject particle;
    public int speed = 5;

    void Start()
    {
        particle.SetActive(false);
        buttonList = GetComponent<ButtonList>();
    }

    void Update()
    {

    }
    public void UnlockNextStage(int NumberOfStage)
    {
        Debug.Log(NumberOfStage);
        if (NumberOfStage == 6)
        {

        }
        else
        {
            Vector3 stage1 = new Vector3(buttonList.GetButtonInfo(NumberOfStage).transform.position.x, buttonList.GetButtonInfo(NumberOfStage).transform.position.y, 0);
            Vector3 stage2 = new Vector3(buttonList.GetButtonInfo(NumberOfStage + 1).transform.position.x, buttonList.GetButtonInfo(NumberOfStage + 1).transform.position.y, 0);
            particle.gameObject.transform.position = stage1;
            Debug.Log("#####");
            particle.SetActive(true);

            StartCoroutine(ZoomOut(stage1, stage2));
        }
    }

    IEnumerator ZoomOut(Vector3 stage1, Vector3 stage2)
    {
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        while (true)
        {
            particle.transform.position = Vector3.MoveTowards(particle.transform.position, stage2, speed * Time.deltaTime);
            if (Vector3.Distance(particle.transform.position, stage2) <= 0.01f)
            {
                Debug.Log("99");
                particle.SetActive(false);
                yield break;
            }
            Debug.Log(particle.active);
            yield return waitForEndOfFrame;
        }

    }
}
