using System;
using System.IO;
using System.Net;
using System.Windows;

namespace Task1
{
    public class SomeServer
    {
        string WebServiceUrl = "http://tmgwebtest.azurewebsites.net/api/textstrings/";
        string HeaderName = "TMG-Api-Key";
        string HeaderKey = "0J/RgNC40LLQtdGC0LjQutC4IQ==";

        public string GetResponseParse(string id)
        {
            string response = "";
            try
            {
                WebRequest webRequest = WebRequest.Create(WebServiceUrl + id);
                webRequest.Method = "GET";
                webRequest.Timeout = 12000;
                webRequest.ContentType = "application/json";
                webRequest.Headers.Add(HeaderName, HeaderKey);

                Stream jsonResponsetStream = webRequest.GetResponse().GetResponseStream();
                StreamReader jsonResponseStreamReader = new StreamReader(jsonResponsetStream);
                response = jsonResponseStreamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed request to the server? please try again later. Error: {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return response;
        }
    }
}
