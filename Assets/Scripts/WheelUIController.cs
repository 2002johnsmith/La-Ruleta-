using UnityEngine;
using TMPro;

public class WheelUIController : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_InputField inputField;
    public TMP_Text mensajeError;

    [Header("Reglas")]
    public int maxCharacters = 25;

    [Header("Ruleta")]
    public WheelGenerator generator;

    private void Start()
    {
        mensajeError.text = "";
    }

    public void AddEntryFromInput()
    {
        string texto = inputField.text.Trim();

        // Validaciones básicas
        if (texto == "")
        {
            mensajeError.text = "Ingresa un nombre.";
            return;
        }

        if (texto.Length > maxCharacters)
        {
            mensajeError.text = "Máximo " + maxCharacters + " caracteres.";
            return;
        }

        mensajeError.text = "";

        // Agregar a la ruleta dinámica
        generator.AddEntry(texto);

        // Limpiar campo
        inputField.text = "";
    }
}