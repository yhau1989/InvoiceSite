using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class CA
    {
        public CA() { }




        public string GeneraClaveAcceso(string secuencial)
        {
            string retorno = "";

            DateTime fecha = DateTime.Now;
            retorno = fecha.ToString("dd") + fecha.ToString("MM") + fecha.ToString("yyyy") + "01" + "0990011214001" + "1" + "004" + "040" + "00000" + secuencial + "00000002" + "1";

            Char[] arr;
            arr = retorno.ToCharArray();
            retorno = DigitoVerificadorMod11(arr);

            return retorno;
        }



        private string DigitoVerificadorMod11(char[] ElNumero)
        {
            string Resultado = "";
            int Multiplicador = 2;
            int iNum = 0;
            int Suma = 0;

            for (int i = 47; i >= 0; i += -1)
            {
                iNum = int.Parse(ElNumero[i].ToString());
                Suma += iNum * Multiplicador;
                Multiplicador += 1;
                if (Multiplicador == 8)
                    Multiplicador = 2;
            }
            Resultado = Convert.ToString(11 - (Suma % 11));
            if (Resultado == "10")
                Resultado = "1";
            if (Resultado == "11")
                Resultado = "0";
            return new string(ElNumero) + Resultado;
        }



    }
}
