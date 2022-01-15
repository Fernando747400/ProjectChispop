using UnityEngine;

public class Grass_Script : MonoBehaviour
{
    public Material GreenMaterial;
    public Color InitialColor;
    public Color TransparentColor;
    public bool ChangeColor = false;

    public BoolVariable Hidden;

    public void Awake()
    {
        GreenMaterial.color = InitialColor;
        Hidden.Value = false;
    }

    public void Update()
    {
        if (ChangeColor == false)
        {
            GreenMaterial.color = InitialColor;
            Hidden.Value = false;
        }
        else if (ChangeColor == true)
        {
            GreenMaterial.color = TransparentColor;
            Hidden.Value = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ChangeColor = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        ChangeColor = false;
    }
}
