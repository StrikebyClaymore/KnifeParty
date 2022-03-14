using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private GameObject part1;
    [SerializeField] private GameObject part2;
    [SerializeField] private float force = 4f;
    public void GetHit()
    {
        part1.transform.SetParent(transform.parent.parent);
        part2.transform.SetParent(transform.parent.parent);
        part1.SetActive(true);
        part2.SetActive(true);
        var angle = Random.Range(10, 30);
        var rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        var direction = rotation * Vector3.up;
        part1.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
        part1.GetComponent<Rigidbody2D>().AddTorque(1, ForceMode2D.Force);
        angle = Random.Range(-10, -30);
        rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        direction = rotation * Vector3.up;
        part2.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
        part2.GetComponent<Rigidbody2D>().AddTorque(1, ForceMode2D.Force);

        GameManager.GameData.Apples++;
    }
}
