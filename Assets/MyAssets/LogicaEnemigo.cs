using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEnemigo : MonoBehaviour
{

    public int hp;
    public int weaponDmg;
    public int meleeDmg;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        /*if(other.gameObject.tag == "weaponImpact")
        {
            if (anim != null)
            {
                anim.Play("EnemigoCubo1");
            }
            hp -= weaponDmg;
        }
        */
        if(other.gameObject.tag == "meleeImpact")
        {
            if(anim != null)
            {
                anim.Play("EnemigoCubo1");
            }

            hp -= meleeDmg;
        }
        hp -= meleeDmg;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }
}
