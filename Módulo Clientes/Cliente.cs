using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPantalla.Módulo_Clientes
{
    public class Cliente
    {

        String nombre;
        String correo;
        String identificacion;
        String nombreContacto;
        String descripcion_Contacto;
        String sla;
        String cuenta;
        String tipo_Pago;
        String situaion;
        String tipo;
        String convencional1;
        String convencional2;
        String movil1;
        String movil2;

        public Cliente(String nombre, String correo, String identificacion, String nombreContacto, String descripcion_Contacto, String sla, String cuenta, String tipo_Pago, String situaion, String tipo, String convencional1, String convencional2, String movil1, String movil2)
        {
            this.nombre = nombre;
            this.correo = correo;
            this.identificacion = identificacion;
            this.nombreContacto = nombreContacto;
            this.descripcion_Contacto = descripcion_Contacto;
            this.sla = sla;
            this.cuenta = cuenta;
            this.tipo_Pago = tipo_Pago;
            this.situaion = situaion;
            this.tipo = tipo;
            this.convencional1 = convencional1;
            this.convencional2 = convencional2;
            this.movil1 = movil1;
            this.movil2 = movil2;
        }

        public String GetNombre()
        {
            return nombre;
        }

        public void SetNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public String GetCorreo()
        {
            return correo;
        }

        public void SetCorreo(String correo)
        {
            this.correo = correo;
        }

        public String GetIdentificacion()
        {
            return identificacion;
        }

        public void SetIdentificacion(String identificacion)
        {
            this.identificacion = identificacion;
        }

        public String GetNombreContacto()
        {
            return nombreContacto;
        }

        public void SetNombreContacto(String nombreContacto)
        {
            this.nombreContacto = nombreContacto;
        }

        public String GetDescripcion_Contacto()
        {
            return descripcion_Contacto;
        }

        public void SetDescripcion_Contacto(String descripcion_Contacto)
        {
            this.descripcion_Contacto = descripcion_Contacto;
        }

        public String GetSla()
        {
            return sla;
        }

        public void SetSla(String sla)
        {
            this.sla = sla;
        }

        public String GetCuenta()
        {
            return cuenta;
        }

        public void SetCuenta(String cuenta)
        {
            this.cuenta = cuenta;
        }

        public String GetTipo_Pago()
        {
            return tipo_Pago;
        }

        public void SetTipo_Pago(String tipo_Pago)
        {
            this.tipo_Pago = tipo_Pago;
        }

        public String GetSituaion()
        {
            return situaion;
        }

        public void SetSituaion(String situaion)
        {
            this.situaion = situaion;
        }

        public String GetTipo()
        {
            return tipo;
        }

        public void SetTipo(String tipo)
        {
            this.tipo = tipo;
        }

        public String GetConvencional1()
        {
            return convencional1;
        }

        public void SetConvencional1(String convencional1)
        {
            this.convencional1 = convencional1;
        }

        public String GetConvencional2()
        {
            return convencional2;
        }

        public void SetConvencional2(String convencional2)
        {
            this.convencional2 = convencional2;
        }

        public String GetMovil1()
        {
            return movil1;
        }

        public void SetMovil1(String movil1)
        {
            this.movil1 = movil1;
        }

        public String GetMovil2()
        {
            return movil2;
        }

        public void SetMovil2(String movil2)
        {
            this.movil2 = movil2;
        }
    }
}
