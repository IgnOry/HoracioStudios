using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCliente
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                PostItem("si");
                Console.ReadLine();
            }
        }

        public static void GetItem(int id)
        {
            string url = "http://localhost:25565/prueba/get";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            //Hacer algo con la respuesta
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static void PostItem(string data)
        {
            string url = "http://localhost:25565/prueba/post";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"data\":\"{data}\"}}";
            //json = datos
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";         

            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (System.Exception)
            {

                //throw;
            }
        }
    }
}
