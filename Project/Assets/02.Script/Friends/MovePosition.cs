using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

enum pos
{
    DL, DR, UL, UR,
    DLM, DRM, ULM, URM
}

public class MovePosition : MonoBehaviour
{
    [SerializeField] private Transform[] node;
    [SerializeField] private int now = -1;
    [SerializeField] private int next = -1;

    private Queue<Transform> goPos = new Queue<Transform>();
    private Queue<int> posNum = new Queue<int>();

    static int[,] point = new int[8, 8] {
        {0, 1, 0, 0, 1, 1, 0, 0 },
        {1, 0, 0, 0, 1, 1, 0, 0 },
        {0, 0, 0, 1, 0, 0, 1, 1 },
        {0, 0, 1, 0, 0, 0, 1, 1 },
        {1, 1, 0, 0, 0, 1, 0, 1 },
        {1, 1, 0, 0, 1, 0, 1, 0 },
        {0, 0, 1, 1, 0, 1, 0, 1 },
        {0, 0, 1, 1, 1, 0, 1, 0 }
    };

    public (Queue<Transform>, Queue<int>) GetRoot(int finish)
    {
        goPos.Clear();
        posNum.Clear();
        int start = now;
        if (now == finish) return (null, null);

        if (start < 0)
        {
            if (finish > 1)
            {
                goPos.Enqueue(node[(int)pos.DRM]);
                goPos.Enqueue(node[(int)pos.ULM]);

                posNum.Enqueue((int)pos.DRM);
                posNum.Enqueue((int)pos.ULM);
            }
            goPos.Enqueue(node[finish]);
            posNum.Enqueue(finish);
        }
        else
        {
            if (point[start, finish] == 1)
            {
                goPos.Enqueue(node[finish]);
                posNum.Enqueue(finish);
            }
            else
            {
                if (start < 4) start += 4;
                for (int i = 0; i < 8; i++)
                {
                    if (i == start || i == finish) continue;
                    if (point[start, i] == 1 && point[i, finish] == 1)
                    {
                        goPos.Enqueue(node[start]);
                        goPos.Enqueue(node[i]);
                        goPos.Enqueue(node[finish]);

                        posNum.Enqueue(start);
                        posNum.Enqueue(i);
                        posNum.Enqueue(finish);

                        break;
                    }
                }
            }
        }
        return (goPos, posNum);
    }

    public void PrintMove()
    {
        /*
        동료 FSM - Run(FriendRun)
        Queue<Transform> gp = new Queue<Transform>();
        Queue<int> pn = new Queue<int>();

        (gp, pn) = GetRoot(Random.Range(0,4));
        if (null != gp)
        {
            while (pn.Count > 0)
            {
                next = pn.Dequeue();
                gp.Dequeue();
                //이동
                now = next;
                Debug.Log(now);
            }
        }*/
        while (posNum.Count > 0)
        {
            next = posNum.Dequeue();
            goPos.Dequeue();
            //이동
            now = next;
            Debug.Log(now);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            GetRoot(0);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            GetRoot(1);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            GetRoot(2);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            GetRoot(3);
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            PrintMove();
        }
    }
}
