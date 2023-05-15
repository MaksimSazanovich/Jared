using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    public GameObject lightOn;
    Vector3 startPoint;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                UpdateWire(collider.transform.position);

                if (transform.parent.name.Equals("Wire Green") && collider.transform.parent.name.Equals("Not Wire Green"))
                {
                    Main.Instance.SwitchChange(1);

                    collider.GetComponent<Wire>()?.Done();
                    Done();
                    return;
                }

                if (transform.parent.name.Equals(collider.transform.parent.name) && !transform.parent.name.Equals("Wire Green") && !collider.transform.parent.name.Equals("Wire Green"))
                {
                   
                    Main.Instance.SwitchChange(1);

                    collider.GetComponent<Wire>()?.Done();
                    Done();
                }
                return;
            }
        }

        UpdateWire(newPosition);
    }

    void Done()
    {
        lightOn.SetActive(true);

        Destroy(this);
    }

    private void OnMouseUp()
    {
        UpdateWire(startPosition);
    }

    void UpdateWire(Vector3 newPosition)
    {
        transform.position = newPosition;

        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);

    }
 }
