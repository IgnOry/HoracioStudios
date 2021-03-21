using Newtonsoft.Json;
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
                LogIn("posna", "contraseña");
                //PostItem("si");
                Console.ReadLine();
            }
        }

        class User
        {
            public string username;
            public string password;
        }

        public static int LogIn(string username, string password)
        {
            string url = "http://localhost:25565/login";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"username\":\"{username}\"}}";
            User user = new User();
            user.username = username;
            user.password = password;
            string jsonPrueba = JsonConvert.SerializeObject(user);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonPrueba);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return -1;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            //Hacer algo con la respuesta
                            Console.WriteLine(responseBody);

                            // Returns 0 if username and password are wrong
                            // or the id
                            return int.Parse(responseBody);
                        }
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
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
