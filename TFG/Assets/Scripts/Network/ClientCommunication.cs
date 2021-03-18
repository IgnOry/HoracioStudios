using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class ClientCommunication : MonoBehaviour
{
    public static void GetItem(int id)
    {
        string url = "http://localhost:25565/prueba";
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
        string url = "http://localhost:25565/prueba";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        string json = "";
        //json = datos
        request.Method = "GET";
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

            throw;
        }
    }
}
