using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelasUIController : MonoBehaviour
{
    [SerializeField] private List<GameObject> telas;

    public void DesabilitarHabilitarTela(GameObject telaAtivar)
    {
        foreach (GameObject tela in telas)
        {
            tela.SetActive(false);
        }

        telaAtivar.SetActive(true);
    }
}
