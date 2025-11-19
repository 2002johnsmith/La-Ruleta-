using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WheelGenerator : MonoBehaviour
{
    [Header("Prefabs y Referencias")]
    public GameObject slicePrefab;         // Prefab de un segmento
    public Transform wheelContainer;       // Donde se generan los segmentos

    [Header("Datos de la Ruleta")]
    public List<string> entries = new List<string>();  // Nombres agregados
    private List<GameObject> slices = new List<GameObject>();

    public void GenerateWheel()
    {
        // 1. Limpiar ruleta anterior
        foreach (var s in slices)
            Destroy(s);
        slices.Clear();

        int count = entries.Count;
        if (count == 0) return;

        float anglePerSlice = 360f / count;

        // 2. Crear segmentos
        for (int i = 0; i < count; i++)
        {
            GameObject newSlice = Instantiate(slicePrefab, wheelContainer);
            slices.Add(newSlice);

            // Ajustar imagen shape type a radial
            Image img = newSlice.GetComponent<Image>();
            img.fillAmount = 1f / count;
            img.color = Random.ColorHSV(); // Color aleatorio

            // Rotar slice
            newSlice.transform.localRotation = Quaternion.Euler(0, 0, -anglePerSlice * i);

            // Texto
            TMP_Text txt = newSlice.GetComponentInChildren<TMP_Text>();
            txt.text = entries[i];
        }
    }

    public void AddEntry(string name)
    {
        entries.Add(name);
        GenerateWheel();
    }

    public int GetSegmentCount()
    {
        return entries.Count;
    }

    public string GetEntryByIndex(int index)
    {
        if (index < 0 || index >= entries.Count) return "";
        return entries[index];
    }
}
