using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererSettings : MonoBehaviour
{
    [SerializeField] LineRenderer rend;
    Vector3[] points;

    public LayerMask layerMask;
    public GameObject panel;
    public Image img;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        img = panel.GetComponent<Image>();
        
        rend = gameObject.GetComponent<LineRenderer>();
        
        points = new Vector3[2];
        points[0] = Vector3.zero;
        points[1] = transform.position + new Vector3(0, 0, 20);

        rend.SetPositions(points);
        rend.enabled = true;
    }
    
    public bool AlignLineRenderer(LineRenderer rend)
    {
        bool isHit = false;

        Ray ray;
        RaycastHit hit;
        ray = new Ray(transform.position, transform.forward);
        // Debug.DrawRay(ray.origin, ray.direction);

        if (Physics.Raycast(ray, out hit, layerMask)) {
            isHit = true;

            rend.startColor = Color.red;
            rend.endColor = Color.red;

            points[1] = transform.forward + new Vector3(0, 0, hit.distance);
            btn = hit.collider.gameObject.GetComponent<Button>();
        }
        else
        {
            isHit = false;

            rend.startColor = Color.green;
            rend.endColor = Color.green;

            points[1] = transform.forward + new Vector3(0, 0, 20);
        }

        rend.SetPositions(points);
        rend.material.color = rend.startColor;
        return isHit;
    }

    public void ColorChangeOnClick()
    {
        if (btn != null)
        {
            if (btn.name == "red_btn")
            {
                img.color = Color.red;
            }
            else if (btn.name == "blue_btn")
            {
                img.color = Color.blue;
            }
            else if (btn.name == "green_btn")
            {
                img.color = Color.green;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        AlignLineRenderer(rend);

        if(AlignLineRenderer(rend) && Input.GetAxis("Submit") > 0)
        {
            btn.onClick.Invoke();
        }
    }
}
