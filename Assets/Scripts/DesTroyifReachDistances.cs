using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesTroyifReachDistances : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DesTroyIfOutofView());
    }


    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator DesTroyIfOutofView()
    {
        while (true)
        {
            var a = (Camera.main.WorldToViewportPoint(transform.position));


            if (a.y < -1)
            {
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}