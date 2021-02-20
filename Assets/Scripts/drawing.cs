using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class drawing : MonoBehaviour
{
    public AudioClip painting;

    AudioSource m_MyAudioSource;

    //Palette button
    public Button RedButton;
    public Button PinkButton;
    public Button GreenButton;
    public Button BlueButton;
    public Button YellowButton;
    public Button WhiteButton;
    public Button SwapButton;

    //Palette material
    public Material red;
    public Material pink;
    public Material green;
    public Material yellow;
    public Material white;
    public Material blue;

    public OVRInput.Button drawInput;
    public Transform drawPositionSource;
    public float lineWidth = 0.03f;
    public Material lineMaterial;
    
    public float distanceThreshold = 0.05f;

    private List<Vector3> currentLinePositions = new List<Vector3>();
    private XRController controller;
    private bool isDrawing = false;
    private bool isPressed = false;
    private LineRenderer currentLine;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<XRController>();
        m_MyAudioSource = GetComponent<AudioSource>();

        Button btnRed = RedButton.GetComponent<Button>();
        btnRed.onClick.AddListener(OnClickRED);

        Button btnpink = RedButton.GetComponent<Button>();
        btnpink.onClick.AddListener(OnClickPINk);

        Button btngreen = RedButton.GetComponent<Button>();
        btngreen.onClick.AddListener(OnClickGREEN);

        Button btnyellow = RedButton.GetComponent<Button>();
        btnyellow.onClick.AddListener(OnClickYELLOW);

        Button btnwhite = RedButton.GetComponent<Button>();
        btnwhite.onClick.AddListener(OnClickWHITE);

        Button btnblue = RedButton.GetComponent<Button>();
        btnblue.onClick.AddListener(OnClickBLUE);
    }

    void OnClickRED()
    {
        lineMaterial = red;
    }

    void OnClickPINk()
    {
        lineMaterial = pink;
    }

    void OnClickGREEN()
    {
        lineMaterial = green;
    }

    void OnClickYELLOW()
    {
        lineMaterial = yellow;
    }

    void OnClickWHITE()
    {
        lineMaterial = white;
    }

    void OnClickBLUE()
    {
        lineMaterial = blue;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if input down
        //OVRInput.Button.IsPressed(controller.inputDevice, drawInput, out bool isPressed);
        if (OVRInput.Get(OVRInput.Button.One) == true)
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }

        if (!isDrawing && isPressed)
        {
            StartDrawing();
        }
        else if (isDrawing && !isPressed)
        {
            StopDrawing();
        }
        else if (isDrawing && isPressed)
        {
            UpdateDrawing();
        }
    }

    public void SetLineMaterial(Material newMat)
    {
        lineMaterial = newMat;
    }

    void StartDrawing()
    {
        isDrawing = true;
        //create line
        GameObject lineGameObject = new GameObject("Line");
        currentLine = lineGameObject.AddComponent<LineRenderer>();

        UpdateLine();
        //MakeSound(painting);
        m_MyAudioSource.Play();
    }

    void UpdateLine()
    {
        //update line
        //update line position
        currentLinePositions.Add(drawPositionSource.position);
        currentLine.positionCount = currentLinePositions.Count;
        currentLine.SetPositions(currentLinePositions.ToArray());

        //update line visual
        currentLine.material = lineMaterial;
        currentLine.startWidth = lineWidth;
    }

    void StopDrawing()
    {
        isDrawing = false;
        currentLinePositions.Clear();
        currentLine = null;
        m_MyAudioSource.Stop();
    }

    void UpdateDrawing()
    {
        //check if we have a line
        if (!currentLine || currentLinePositions.Count == 0)
            return;

        Vector3 lastSetPosition = currentLinePositions[currentLinePositions.Count - 1];
        if (Vector3.Distance(lastSetPosition, drawPositionSource.position) > distanceThreshold)
        {
            UpdateLine();
        }
        
    }
}
