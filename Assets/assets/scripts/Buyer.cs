using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyer : MonoBehaviour
{
    public float moveSpeed = 200f;
    public Sprite nuevoSprite;
    private Vector3 initialPosition;
    private Transform destino;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }
    public void Initialize(Transform waypoint, List<(string producto, int cantidad)> compras)
    {
        initialPosition = transform.position;
        destino = waypoint;
        StartCoroutine(RutinaDeCompra(compras));
    }

    private IEnumerator RutinaDeCompra(List<(string producto, int cantidad)> compras)
    {
       
        yield return StartCoroutine(MoveTo(destino.position));

        
        foreach (var compra in compras)
        {
            SendPurchaseData(compra);
            yield return new WaitForSeconds(0.3f);
        }

        spriteRenderer.sprite = nuevoSprite;
        yield return new WaitForSeconds(1f);

        
        yield return StartCoroutine(MoveTo(initialPosition));

        Debug.Log($"{gameObject.name} terminó la compra.");
        Debug.Log("-----------------------------------------------------------------------------------------------------------------------");
    }

    private IEnumerator MoveTo(Vector3 destino)
    {
        while (Vector3.Distance(transform.position, destino) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void SendPurchaseData((string producto, int cantidad) compra)
    {
        Debug.Log($"[ENVIADO AL RECEPTOR] Producto: {compra.producto}, Cantidad: {compra.cantidad}");
        shopManager.RecibirCompra(compra);
    }
}