using System.Collections;
using System.Collections.Generic;
using System.Linq; // <-- Esto es clave para usar Where y ToList
using UnityEngine;

public class BuyerGenerator : MonoBehaviour
{
    public GameObject buyerPrefab;
    public Transform spawnPoint;
    public Transform waypoint;
    public int totalBuyers=3;



    public void starsequence()
    {
        
        StartCoroutine(GenerateBuyers(totalBuyers));
    }

    private IEnumerator GenerateBuyers(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            GameObject buyerGO = Instantiate(buyerPrefab, spawnPoint.position, Quaternion.identity);
            buyerGO.name = "Comprador_" + i;

            Buyer buyerScript = buyerGO.GetComponent<Buyer>();

            if (buyerScript != null)
            {
                var compras = new List<(string producto, int cantidad)>
                {
                    ("cafe", Random.Range(0,5)),
                    ("galleta", Random.Range(0,5)),
                    ("sanguche", Random.Range(0,5)),
                    ("late", Random.Range(0,5)),
                    ("pizza", Random.Range(0,5))
                };

                // Remover compras con cantidad 0 para no enviar innecesarios
                compras = compras.Where(c => c.cantidad > 0).ToList();

                buyerScript.Initialize(waypoint, compras);
            }
            yield return new WaitForSeconds(5f);
        }

        yield return new WaitForSeconds(3f);

        shopManager.ProcesarCompras();
    }
}