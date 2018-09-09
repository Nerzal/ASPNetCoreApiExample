using FileReceiverExample.Models;

namespace FileReceiverExample {
  public interface IImageManager {
    /// <summary>
    /// Holds the path to the imageStore
    /// </summary>
    string ImageStoreDirectory { get; set; }

    /// <summary>
    /// Images are identified by their fileName
    /// </summary>
    /// <param name="image"></param>
    void UpsertImage(Image image);

    /// <summary>
    /// Deletes the image
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>true if file was deleted</returns>
    bool DeleteImage(string fileName);
  }
}