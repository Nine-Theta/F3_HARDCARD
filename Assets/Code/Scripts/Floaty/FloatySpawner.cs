using System.Collections;
using UnityEngine;

public class FloatySpawner : MonoBehaviour
{
    [SerializeField] GameObject floatyPrefab;
    [SerializeField] float delay = 1f;

    IEnumerator SpawnPrefab()
    {
        yield return new WaitUntil(() => this.transform.childCount == 0);
        yield return new WaitForSeconds(delay);
        Instantiate(floatyPrefab, this.transform.position, floatyPrefab.transform.rotation, this.transform);

        StartCoroutine(SpawnPrefab());
    }

    private void Start()
    {
        StartCoroutine(SpawnPrefab());
    }
}
