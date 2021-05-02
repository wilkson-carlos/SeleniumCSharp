using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace BotMegaSena
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("informe o numero do consurso");
            string numero = Console.ReadLine();

            Console.WriteLine("consurso: " + numero);
            if (string.IsNullOrEmpty(numero))
            {
                numero = "2103";
            }

            string url = @"http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage//p=concurso=" + numero;
            string json;

            using (WebClient wc = new WebClient())
            {
                wc.Headers["Cookie"] = "security=true";
                json = wc.DownloadString(url);
            }

            var resultado = JsonConvert.DeserializeObject<Resultado>(json);

            List<string> listaResult = new List<string>();

            listaResult =  resultado.dezenasSorteadasOrdemSorteio;

            foreach (var item in listaResult)
            {
                Console.Write(item + " - ");
            }


            Console.ReadLine();


        }
    }
}
