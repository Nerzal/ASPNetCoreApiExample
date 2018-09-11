using System.IO;
using System.Net;
using System.Net.Http;
using FileReceiverExample.Models;

namespace FileReceiverExample.ConsoleClient {
  /// <summary>
  /// Client to use the FileReceiverExample api
  /// </summary>
  public class Client {
    private readonly string _serviceBaseUrl;
    private HttpClient _httpClient;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="serviceBaseUrl"></param>
    public Client(string serviceBaseUrl) {
      this._serviceBaseUrl = serviceBaseUrl;
      this._httpClient = new HttpClient();
    }

    public void UpsertImage(Image image) {
      //TODO use serviceBaseURL, which should point to the dockerInstance
      HttpWebRequest httpWebRequest = GetNewRequest($"{this._serviceBaseUrl}/api/images", "POST");

      using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
        string body = Newtonsoft.Json.JsonConvert.SerializeObject(image);

        streamWriter.Write(body);
        streamWriter.Flush();
        streamWriter.Close();
      }

      string response = GetResponse(httpWebRequest);
    }
    public void DeleteImage(string fileName) {
      //TODO use serviceBaseURL, which should point to the dockerInstance
      HttpWebRequest request = GetNewRequest($"{this._serviceBaseUrl}/api/images/{fileName}", "DELETE");

      using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream())) {
        streamWriter.Flush();
        streamWriter.Close();
      }

      string response = GetResponse(request);
    }

    private HttpWebRequest GetNewRequest(string url, string method) {
      HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
      httpWebRequest.ContentType = "application/json";
      httpWebRequest.Method = method;
      return httpWebRequest;
    }

    private string GetResponse(HttpWebRequest httpWebRequest) {
      HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
      using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream())) {
        string result = streamReader.ReadToEnd();
        return result;
        //TODO maybe check the result :D
      }
    }
  }
}
