using UnityEngine;
using TMPro;

public class WheelSpinner : MonoBehaviour
{
    [Header("Referencias")]
    public WheelGenerator generator;
    public Transform wheelTransform;
    public TMP_Text resultadoTexto;

    [Header("Ajustes del Giro")]
    public float minVelocity = 500f;
    public float maxVelocity = 900f;
    public float deceleration = 150f;

    private float currentVelocity = 0f;
    private bool spinning = false;

    private void Update()
    {
        if (!spinning) return;

        wheelTransform.Rotate(0, 0, currentVelocity * Time.deltaTime);

        currentVelocity -= deceleration * Time.deltaTime;

        if (currentVelocity <= 0)
        {
            spinning = false;
            EvaluateResult();
        }
    }

    public void Spin()
    {
        if (generator.GetSegmentCount() == 0) return;

        spinning = true;

        currentVelocity = Random.Range(minVelocity, maxVelocity);
    }

    void EvaluateResult()
    {
        int count = generator.GetSegmentCount();
        if (count == 0) return;

        float zRotation = wheelTransform.eulerAngles.z;

        float adjustedAngle = (360 - zRotation + 90) % 360;

        float anglePerSlice = 360f / count;

        int index = Mathf.FloorToInt(adjustedAngle / anglePerSlice);

        string ganador = generator.GetEntryByIndex(index);

        resultadoTexto.text = "Ganador: " + ganador;
        Debug.Log("Ganador: " + ganador);
    }
}
