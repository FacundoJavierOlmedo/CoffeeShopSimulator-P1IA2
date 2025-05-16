using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class vnManager : MonoBehaviour
{

    public GameObject[] hideVN;
    public BuyerGenerator buyerGenerator;
    [System.Serializable]
    public class DialogSegment
    {
        public string texto;
        public float velocidad;
        public CharacterEmotion emocion;
    }

    public List<DialogSegment> segmentos;
    public TextMeshProUGUI textoUI; 

    private void Start()
    {
     
        StartCoroutine(ReproducirDialogo());
         





    }

    private IEnumerator ReproducirDialogo()
    {
        foreach (var segmento in segmentos)
        {
            vnPlayerAvatar.ExpresionVaAvatarChanger(segmento.emocion);
            yield return StartCoroutine(MostrarTextoPorLetra(segmento));
            yield return new WaitForSeconds(0.5f); // Pausa entre frases
        }
        buyerGenerator.starsequence();
        foreach (var obj in hideVN)
        {
            obj.SetActive(false);
        }
    }

   
    private IEnumerator MostrarTextoPorLetra(DialogSegment segmento)
    {
        string textoActual = "";
        foreach (char c in segmento.texto)
        {
            textoActual += c;
            textoUI.text = textoActual;
            yield return new WaitForSeconds(segmento.velocidad); 
        }
    }


}


