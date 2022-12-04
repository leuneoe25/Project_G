using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScienceSkill : MonoBehaviour
{
    [SerializeField] GameObject MENTOS;
    [SerializeField] GameObject Cola;

    public int cost;
    public bool IsTest;
    private bool SkillOn;
    Vector3[] mentosPos = new Vector3[10];
    public float time = 1;
    int mentosSprite = 2;
    void Start()
    {
        
    }

    public void Skill()
    {
        SkillOn = true;
    }

    private void SpriteMentos()
    {

        for (int i = 0; i < 10; ++i)
        {
            Vector3 pointB = new Vector3(gameObject.transform.position.x + Random.Range(-11.1f, 11.1f), gameObject.transform.position.y - 3.5f, gameObject.transform.position.z);
            Vector3 dir = pointB - transform.position;
            GameObject NewArrow;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            NewArrow = Instantiate(MENTOS, transform.position, Quaternion.identity);
            mentosPos[i] = pointB;
            NewArrow.transform.rotation = Quaternion.AngleAxis(angle - 70, Vector3.forward);
        }
    }

    private void SpriteCola()
    {
        GameObject cola = Instantiate(Cola, transform.position, Quaternion.identity);
        cola.transform.rotation = Quaternion.AngleAxis(-180, Vector3.forward);
    }
    // Update is called once per frame
    void Update()
    {
        if(IsTest)
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                Skill();
            }
        }
        if(SkillOn)
        {
            if(mentosSprite > 0)
            {
                SpriteMentos();
                mentosSprite--;
            }
            time -= Time.deltaTime;
            if(time <= 0)
            {
                SpriteCola();
                time = 1;
                SkillOn = false;
            }
        }
    }
}
