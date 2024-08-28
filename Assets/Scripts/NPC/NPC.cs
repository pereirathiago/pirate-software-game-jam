using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float initialSpeed;
    private int index;

    [SerializeField]
    private List<Transform> paths = new List<Transform>();

    public float Speed { get => speed; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueControl.instance.IsShowing)
        {
            Speed = 0;
        }
        else
        {
            Speed = initialSpeed;
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, Speed * Time.deltaTime);
        
        if(Vector2.Distance(transform.position, paths[index].position) < 0.1f)
        {
            if(index < paths.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }
}
