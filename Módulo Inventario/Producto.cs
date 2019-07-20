using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPantalla.Módulo_Inventario
{
    public class Producto
    {
        String codigo;
        String descripcion;
        int cantidad;
        float precio;

        public Producto(String codigo, String descripcion, int cantidad, float precio)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
            this.precio = precio;
        }

        public String GetCodigo()
        {
            return codigo;
        }

        public void SetCodigo(String codigo)
        {
            this.codigo = codigo;
        }

        public String GetDescripcion()
        {
            return descripcion;
        }

        public void SetDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }

        public int GetCantidad()
        {
            return cantidad;
        }

        public void SetCantidad(int cantidad)
        {
            this.cantidad = cantidad;
        }

        public float GetPrecio()
        {
            return precio;
        }

        public void SetPrecio(float precio)
        {
            this.precio = precio;
        }
    }
}
