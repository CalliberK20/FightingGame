using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightComboCombat : ComboCombat
{
    public Animator knightAnim;
    public override void Attack(string functionName)
    {
        StartCoroutine(functionName);
    }

    private IEnumerator Atk1()
    {
        yield return null;
        onAttack = true;
        knightAnim.SetTrigger("Attack");
        knightAnim.SetFloat("AttackIndex", 0);
        Debug.Log("Atk 1");
/*
        float time = 0;
        while(time < .1)
        {
            yield return null;
            time += Time.deltaTime;
            Debug.Log("Moving: " + time);
            rb.velocity = -Vector3.left * 5;
        }*/
        rb.velocity = Vector3.zero;
    }

    private IEnumerator Atk2()
    {
        yield return null;
        onAttack = true;
        knightAnim.SetTrigger("Attack");
        knightAnim.SetFloat("AttackIndex", 1);
    }
    private IEnumerator Atk3()
    {
        onAttack = true;
        knightAnim.SetTrigger("Attack");
        knightAnim.SetFloat("AttackIndex", 2);
        yield return null;
    }

    private IEnumerator Fient()
    {
        yield return null;
        knightAnim.SetTrigger("Fient");
    }

    private IEnumerator Block()
    {
        onBlock = true;
        knightAnim.SetBool("Block", true);
        while (true)
        {
            yield return null;
            if (Input.GetKeyUp(matchedCombo.sequence[0]))
            {
                break;
            }
        }
        onBlock = false;
        knightAnim.SetBool("Block", false);
    }
}
