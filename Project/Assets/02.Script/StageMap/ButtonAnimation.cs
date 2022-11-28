using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField] ButtonList buttonList;
    public int speed = 5;

    void Start()
    {
        buttonList = GetComponent<ButtonList>();
    }

    void Update()
    {

    }
    public void UnlockNextStage(int NumberOfStage)
    {
        if(NumberOfStage == 6)
        {
            
        }
        else
        {
            Vector3 stage1 = new Vector3();
            Vector3 stage2 = new Vector3();
            stage1 = buttonList.GetButtonInfo(NumberOfStage).transform.position;
            stage2 = buttonList.GetButtonInfo(NumberOfStage + 1).transform.position;
            gameObject.transform.position = stage1;
            gameObject.SetActive(true);

            StartCoroutine(ZoomOut(stage1, stage2));

            gameObject.SetActive(false);
        }
    }

    IEnumerator ZoomOut(Vector3 stage1, Vector3 stage2)
    {
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        while (true)
        {
            while (true)
            {
                gameObject.transform.position = Vector3.Lerp(stage1, stage2, speed * Time.deltaTime);
                if (Vector3.Distance(stage1, stage2) <= 1f)
                {
                    yield break;
                }
            }
            yield return waitForEndOfFrame;

        }
    }
}
