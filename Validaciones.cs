using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace proyectoPantalla
{
    public class Validaciones
    {

        public static bool VerificaCedula(string ced)
        {
            int isNumeric;
            var total = 0;
            const int tamanoLongitudCedula = 10;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            const int numeroProvincia = 24;
            const int tercerDigito = 6;

            if (int.TryParse(ced, out isNumeric) && ced.Length == tamanoLongitudCedula)
            {
                var provincia = Convert.ToInt32(string.Concat(ced[0], ced[1], string.Empty));
                var digitoTres = Convert.ToInt32(ced[2] + string.Empty);
                if ((provincia > 0 && provincia <= numeroProvincia) && digitoTres < tercerDigito)
                {
                    var digitoVerificadorRecibido = Convert.ToInt32(ced[9] + string.Empty);
                    for (var k = 0; k < coeficientes.Length; k++)
                    {
                        var valor = Convert.ToInt32(coeficientes[k] + string.Empty) * Convert.ToInt32(ced[k] + string.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;
                    }
                    var digitoVerificadorObtenido = total >= 10 ? (total % 10) != 0 ? 10 - (total % 10) : (total % 10) : total;
                    return digitoVerificadorObtenido == digitoVerificadorRecibido;
                }
                return false;
            }
            return false;
        }

        public static bool RucPersonaNatural(string ruc)
        {
            long isNumeric;
            const int tamanoLongitudRuc = 13;
            const string establecimiento = "001";
            if (long.TryParse(ruc, out isNumeric) && ruc.Length.Equals(tamanoLongitudRuc))
            {
                var numeroProvincia = Convert.ToInt32(string.Concat(ruc[0] + string.Empty, ruc[1] + string.Empty));
                var personaNatural = Convert.ToInt32(ruc[2] + string.Empty);
                if ((numeroProvincia >= 1 && numeroProvincia <= 24) && (personaNatural >= 0 && personaNatural < 6))
                {
                    return ruc.Substring(10, 3) == establecimiento && VerificaCedula(ruc.Substring(0, 10));
                }
                return false;
            }
            return false;
        }

        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool formatoTelefono(string telefono)
        {
            String formato;
            formato = "^0([2-7])([0-9]{7})$";
            if (Regex.IsMatch(telefono, formato))
            {
                if (Regex.Replace(telefono, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool formatoCelular(string celular)
        {
            String formato;
            formato = "^09([0-9]{8})$";
            if (Regex.IsMatch(celular, formato))
            {
                if (Regex.Replace(celular, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool soloNumero(string valor)
        {
            String formato;
            formato = "/^[0-9]+$/";
            if (Regex.IsMatch(valor, formato))
            {
                if (Regex.Replace(valor, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static int verificarCedulaRepetida(TextBox tbCedula, SqlConnection conexion)
        {
            int result = -1;
            conexion.Open();
            Console.WriteLine(tbCedula.Text);
            SqlCommand cmd = new SqlCommand("SP_VERIFICAR_CEDULA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@identificacion", tbCedula.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            Console.WriteLine(result);
            conexion.Close();
            return result;
        }
    }
}

