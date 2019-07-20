using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPantalla.Módulo_Técnicos
{
    public class Tecnico
    {
        String nombre;
        String correo;
        String identificacion;
        String sector;
        String alcance;
        String estado;
        String situacion;
        String convencional1;
        String convencional2;
        String movil1;
        String movil2;

        public Tecnico(String nombre, String correo, String identificacion, String sector, String alcance, String estado, String situacion, String convencional1, String convencional2, String movil1, String movil2)
        {
            this.nombre = nombre;
            this.correo = correo;
            this.identificacion = identificacion;
            this.sector = sector;
            this.alcance = alcance;
            this.estado = estado;
            this.situacion = situacion;
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

        public String GetSector()
        {
            return sector;
        }

        public void SetSector(String sector)
        {
            this.sector = sector;
        }

        public String GetAlcance()
        {
            return alcance;
        }

        public void SetAlcance(String alcance)
        {
            this.alcance = alcance;
        }

        public String GetEstado()
        {
            return estado;
        }

        public void SetEstado(String estado)
        {
            this.estado = estado;
        }

        public String GetSituacion()
        {
            return situacion;
        }

        public void SetSituacion(String situacion)
        {
            this.situacion = situacion;
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
