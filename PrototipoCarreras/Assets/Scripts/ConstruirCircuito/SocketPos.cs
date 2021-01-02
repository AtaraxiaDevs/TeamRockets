using System;
using UnityEngine;


//Socket necesario para el modo editor, ya que cuenta con información de si ha sido ocupado por un modulo o no.
// Un socket en el contexto de nuestro juego es una posicion, en este caso, una posicion dentro de un modulo donde
// se le puede unir otro para asi conformar el circuito.

public class SocketPos : MonoBehaviour
{
    //Referencias
    private Modulo parent, attach;
    public GameObject particleSistem;
    //Información socket
    private TipoSocket tipo;
    private bool disponible = true;

    #region Modificar Info
    public void setParent(Modulo modulo)
    {
        parent = modulo;
        this.transform.parent = modulo.gameObject.transform;
    }

    public void setTipo(TipoSocket tipo)
    {
        this.tipo = tipo;
    }

    public void setDisponible(bool value)
    {
        disponible = value;
    }

    public void LiberarSocket()
    {
        attach = null;
        disponible = true;
        particleSistem.SetActive(true);
        parent.RemoveVecino(tipo);
    }
    public void setAttach(Modulo modulo)
    {
        attach = modulo;
        disponible = false;
        particleSistem.SetActive(false);
        parent.AddVecino(tipo, modulo);
        modulo.SetAncla(this);
    }
    #endregion
    #region Comprobaciones
    public void esSocketValido(Modulo m)
    {
        if (disponible)
        {
            switch (tipo)
            {
                case TipoSocket.NEGX:

                    if ((m.socket1.Equals(TipoSocket.POSX)) || (m.socket2.Equals(TipoSocket.POSX)))
                    {
                        setAttach(m);
                        m.AddVecinoAndSocket(TipoSocket.POSX, parent);

                        Vector3 posicion = new Vector3(transform.position.x - m.sizeModulo / 2, transform.position.y, transform.position.z);
                        m.transform.position = posicion;
                    }

                    break;

                case TipoSocket.NEGZ:

                    if ((m.socket1.Equals(TipoSocket.POSZ)) || (m.socket2.Equals(TipoSocket.POSZ)))
                    {
                        setAttach(m);
                        m.AddVecinoAndSocket(TipoSocket.POSZ, parent);
                        Vector3 posicion = new Vector3(transform.position.x, transform.position.y, transform.position.z - m.sizeModulo / 2);
                        m.transform.position = posicion;
                    }

                    break;

                case TipoSocket.POSX:

                    if ((m.socket1.Equals(TipoSocket.NEGX)) || (m.socket2.Equals(TipoSocket.NEGX)))
                    {
                        setAttach(m);
                        m.AddVecinoAndSocket(TipoSocket.NEGX, parent);
                        Vector3 posicion = new Vector3(transform.position.x + m.sizeModulo / 2, transform.position.y, transform.position.z);
                        m.transform.position = posicion;
                    }

                    break;

                case TipoSocket.POSZ:

                    if ((m.socket1.Equals(TipoSocket.NEGZ)) || (m.socket2.Equals(TipoSocket.NEGZ)))
                    {
                        setAttach(m);
                        m.AddVecinoAndSocket(TipoSocket.NEGZ, parent);
                        Vector3 posicion = new Vector3(transform.position.x, transform.position.y, transform.position.z + m.sizeModulo / 2);
                        m.transform.position = posicion;
                    }

                    break;

            }
        }
    }
    #endregion


}
