using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector3 delta = new Vector3(3, 0, 0);
    public float transitionTime = .5f;

    int position = 1;

    public void Update()
    {
        if (position > 0)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                position--;
                StartCoroutine(moveLeft());

            }
        }
        if (position < 2)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                position++;
                StartCoroutine(moveRight());
            }
        }

    }

    private IEnumerator moveLeft()
    {
        transform.position = Vector3.Slerp(transform.position, transform.position + delta, transitionTime);
        yield return null;
    }
    private IEnumerator moveRight()
    {

        transform.position = Vector3.Slerp(transform.position, transform.position - delta, transitionTime);
        yield return null;
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Train")
        {
            Debug.Log("Game Over");
        }
    }
}
