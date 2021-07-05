using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Net;

/*
public class CodeRunnerRequest : MonoBehaviour
{
    string playerInputCode = "";

    public String Input()
    {
        var url = "https://localhost:5001/Api/Compile";

        var request = WebRequest.Create(url);
        request.Method = "POST";

        string json = @"{
         'language' : 'dotnet',
         'version' : '5.0.201',
         'code': {
           'args': [
            ''
           ],
           'stdin' : ' ',
           'mainFile': 'main.cs',
           'files': [
             {
               'name':'main.cs',
               'content':'hieristdercode'
             }
           ]
          }
        }";

        JObject jss = JObject.Parse(json);
        jss["content"] = playerInputCode;

        byte[] byteArray = Encoding.UTF8.GetBytes(jss);

        request.ContentType = "application/json";
        request.ContentLength = byteArray.Length;

        // Get the request stream.
        Stream dataStream = request.GetRequestStream();
        // Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length);
        // Close the Stream object.
        dataStream.Close();

        // Get the response.
        WebResponse response = request.GetResponse();
        // Display the status.
        Console.WriteLine(((HttpWebResponse)response).StatusDescription);

        // Get the stream containing content returned by the server.
        // The using block ensures the stream is automatically closed.
        using (dataStream = response.GetResponseStream())
        {
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
        }

        // Close the response.
        response.Close();


        return "test";
    } 
}
*/