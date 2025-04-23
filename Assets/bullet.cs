using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Bla());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * 4 * Time.deltaTime);
        Vector2 pos = transform.position;
        if (transform.position.x < -10)
        {
            transform.position = new Vector2(10, pos.y);
        }
        else if (transform.position.x > 10)
        {
            transform.position = new Vector2(- 10, pos.y);
        }
        else if (transform.position.y < -6)
        {
            transform.position = new Vector2(pos.x, 6);
        }
        else if (transform.position.y > 6)
        {
            transform.position = new Vector2(pos.x, -6);
        }
    }

    IEnumerator Bla()
    {
        yield return new WaitForSeconds(0.5f);
        col.enabled = true;
    }
}
