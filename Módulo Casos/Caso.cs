using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPantalla.Módulo_Casos
{
    public class Caso
    {

        String numero;
        String fecha;
        String sla;
        String informe_Inicial;
        String sector;
        String estado;
        String parte_Path;
        String informe_Final;
        String numero_Factura;

        public Caso(String numero, String fecha, String sla, String informe_Inicial, String sector, String estado, String parte_Path, String informe_Final, String numero_Factura)
        {
            this.numero = numero;
            this.fecha = fecha;
            this.sla = sla;
            this.informe_Inicial = informe_Inicial;
            this.sector = sector;
            this.estado = estado;
            this.parte_Path = parte_Path;
            this.informe_Final = informe_Final;
            this.numero_Factura = numero_Factura;
        }

        public String GetNumero()
        {
            return numero;
        }

        public void SetNumero(String numero)
        {
            this.numero = numero;
        }

        public String GetFecha()
        {
            return fecha;
        }

        public void SetFecha(String fecha)
        {
            this.fecha = fecha;
        }

        public String GetSla()
        {
            return sla;
        }

        public void SetSla(String sla)
        {
            this.sla = sla;
        }

        public String GetInforme_Inicial()
        {
            return informe_Inicial;
        }

        public void SetInforme_Inicial(String informe_Inicial)
        {
            this.informe_Inicial = informe_Inicial;
        }

        public String GetSector()
        {
            return sector;
        }

        public void SetSector(String sector)
        {
            this.sector = sector;
        }

        public String GetEstado()
        {
            return estado;
        }

        public void SetEstado(String estado)
        {
            this.estado = estado;
        }

        public String GetParte_Path()
        {
            return parte_Path;
        }

        public void SetParte_Path(String parte_Path)
        {
            this.parte_Path = parte_Path;
        }

        public String GetInforme_Final()
        {
            return informe_Final;
        }

        public void SetInforme_Final(String informe_Final)
        {
            this.informe_Final = informe_Final;
        }

        public String GetNumero_Factura()
        {
            return numero_Factura;
        }

        public void SetNumero_Factura(String numero_Factura)
        {
            this.numero_Factura = numero_Factura;
        }
    }
}
