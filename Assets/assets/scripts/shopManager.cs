using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class shopManager : MonoBehaviour
{
    
    private static List<(string producto, int cantidad)> compras = new List<(string producto, int cantidad)>();
    public static TextMeshProUGUI txtSanguche;
    public static TextMeshProUGUI txtGalleta;
    public static TextMeshProUGUI txtCafe;
    public static TextMeshProUGUI txtLate;

    [SerializeField] private TextMeshProUGUI txtSangucheInstance;
    [SerializeField] private TextMeshProUGUI txtGalletaInstance;
    [SerializeField] private TextMeshProUGUI txtCafeInstance;
    [SerializeField] private TextMeshProUGUI txtLateInstance;

    

    private void Awake()
    {
        
        txtSanguche = txtSangucheInstance;
        txtGalleta = txtGalletaInstance;
        txtCafe = txtCafeInstance;
        txtLate = txtLateInstance;
    }

    public static void RecibirCompra((string producto, int cantidad) compra)
    {
        compras.Add(compra);
        Debug.Log($"[RECEPTOR] Producto: {compra.producto}, Cantidad: {compra.cantidad}");
       storeOwner.carlos.ChangeSpriteRandomNoRepeat();
    }


    public static void ProcesarCompras()
    {
        Debug.Log("-----------------------------------------------------------------------------------------------------------------------");
        var productosValidos = new[] { "sanguche", "galleta", "cafe", "late" };

      
        var resumen = compras
            .Where(c => productosValidos.Contains(c.producto.ToLower()))
            .GroupBy(c => c.producto.ToLower())
            .ToDictionary(g => g.Key, g => g.Sum(c => c.cantidad));

       
        int cantidadSanguche = resumen.ContainsKey("sanguche") ? resumen["sanguche"] : 0;
        int cantidadGalleta = resumen.ContainsKey("galleta") ? resumen["galleta"] : 0;
        int cantidadCafe = resumen.ContainsKey("cafe") ? resumen["cafe"] : 0;
        int cantidadLate = resumen.ContainsKey("late") ? resumen["late"] : 0;
       

        Debug.Log($"Sanguche: {cantidadSanguche}");
        Debug.Log($"Galleta: {cantidadGalleta}");
        Debug.Log($"Café: {cantidadCafe}");
        Debug.Log($"Late: {cantidadLate}");
        Debug.Log("-----------------------------------------------------------------------------------------------------------------------");
        string resumenCompleto = string.Join(", ", resumen.Select(kv => $"{kv.Key}: {kv.Value}"));
        Debug.Log($"Resumen total de compras: {resumenCompleto}");

        Debug.Log("-----------------------------------------------------------------------------------------------------------------------");
        txtSanguche.text = $"Sánguches vendidos: {cantidadSanguche}";
        txtGalleta.text = $"Galletas vendidas: {cantidadGalleta}";
        txtCafe.text    = $"Cafés vendidos: {cantidadCafe}";
        txtLate.text    = $"Lattes vendidos: {cantidadLate}";
        
    }
}
