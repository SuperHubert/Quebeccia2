using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public int startingHp = 600;
    public int currentHp;
    public bool canTakeDamage = true;
    public float invulFrames = 1;
    public Animator anim;

    public Image lifeBar;
    

    void Start()
    {
        currentHp = startingHp;
    }
    
    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            currentHp -= damage;
            /*if (damage > 0)
            {
                StartCoroutine(InvulnerabilityFrames());
            }*/
            if (currentHp <= 0)
            {
                currentHp = 0;
                SceneManager.LoadScene(3); 
            }
            lifeBar.fillAmount = (float)currentHp / startingHp;
        }
        
    }

    IEnumerator InvulnerabilityFrames()
    {
        canTakeDamage = false;
        anim.SetTrigger("PlayAnim");
        yield return new WaitForSeconds(invulFrames);
        canTakeDamage = true;
    }

}
