using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeff;

    private int LayersCount;
   private void Start()
    {  
        LayersCount = layers.Length;
    }


  private void Update()
    {
        for (int i = 0; i < LayersCount; i++)
        {
            layers[i].position = transform.position * coeff[i];
        }  
    }
}
