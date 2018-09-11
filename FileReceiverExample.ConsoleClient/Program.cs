using System.IO;
using System.Reflection;
using FileReceiverExample.Models;

namespace FileReceiverExample.ConsoleClient {
  class Program {
    static void Main(string[] args) {
      //The ServiceBaseURL and Port is defined in the launchSettings.json
      Client client = new Client("https://localhost:44326");
      byte[] imageBytes = ExtractResource("image.png");
      Image image = new Image(imageBytes, "coolImage.png", "Some metadata");
      client.UpsertImage(image);
    }

    /// <summary>
    /// Helper method to extract the example image from the embedded ressources
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static byte[] ExtractResource(string filename) {
      Assembly assembly = Assembly.GetExecutingAssembly();
      using (Stream resFilestream = assembly.GetManifestResourceStream(filename)) {
        if (resFilestream == null) {
          return null;
        }
        byte[] result = new byte[resFilestream.Length];
        resFilestream.Read(result, 0, result.Length);
        return result;
      }
    }
  }
}
