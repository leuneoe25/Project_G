using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField] ButtonList buttonList;
    [SerializeField] ButtonSaver buttonSaver;
    [SerializeField] GameObject particle;
    [SerializeField] GameObject InvSquare;
    public int speed = 5;

    void Start()
    {
        particle.SetActive(false);
        InvSquare.SetActive(false);
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
            particle.SetActive(true);
            InvSquare.SetActive(true);

            StartCoroutine(ZoomOut(NumberOfStage, stage2));
        }
    }

    IEnumerator ZoomOut(int num, Vector3 stage2)
    {
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        while (true)
        {
            particle.transform.position = Vector3.MoveTowards(particle.transform.position, stage2, speed * Time.deltaTime);
            if (Vector3.Distance(particle.transform.position, stage2) <= 0.01f)
            {
                if(buttonList.buttons[num + 1].gameObject.active)
                {
                    buttonSaver.LockOn(num + 1);
                    particle.SetActive(false);
                    InvSquare.SetActive(false);
                }
                else
                {
                    yield return new WaitForSeconds(1f);
                    buttonSaver.LockOn(num + 1);
                    yield return new WaitForSeconds(0.5f);
                    particle.SetActive(false);
                    InvSquare.SetActive(false);
                }
                yield break;
            }
            Debug.Log(particle.active);
            yield return waitForEndOfFrame;
        }

    }
}
