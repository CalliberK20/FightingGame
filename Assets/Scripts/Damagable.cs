using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public bool isHurt = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Damage(float amount)
    {
        if (!isHurt)
            StartCoroutine(DamageAnim());
    }

    private IEnumerator DamageAnim()
    {
        isHurt = true;
        anim.SetBool("Hurt", isHurt);
        yield return new WaitForSeconds(2f);
        isHurt = false;
        anim.SetBool("Hurt", isHurt);
    }
}
