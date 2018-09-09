using System;
using System.IO;
using FileReceiverExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileReceiverExample {
  /// <summary>
  /// Handles the images on the fileSystem
  /// </summary>
  public class ImageManager : IImageManager {
    /// <summary>
    /// Holds the path to the imageStore
    /// </summary>
    public string ImageStoreDirectory { get; set; }

    /// <summary>
    /// default ctor
    /// </summary>
    public ImageManager() {
      this.ImageStoreDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    }

    /// <summary>
    /// ctor 
    /// </summary>
    /// <param name="imageStoreDirectory"></param>
    public ImageManager(string imageStoreDirectory) {
      this.ImageStoreDirectory = imageStoreDirectory;
    }

    /// <summary>
    /// Images are identified by their fileName
    /// </summary>
    /// <param name="image"></param>
    public void UpsertImage(Image image) {
      string filePath = GetFilePathForImage(image.FileName);
      if (File.Exists(filePath)) {
        try {
          File.Delete(filePath);
        } catch (Exception) { //Never catch swallow the exception
          //I'm a bad way of checking access to a file. Better check if you have access to the file before deleting it
        }
      } 
      File.WriteAllBytes(filePath, image.ImageBytes);

      //TODO Safe metadata if needed
    }

    /// <summary>
    /// Deletes the image
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>true if file was deleted</returns>
    public bool DeleteImage(string fileName) {
      string filePath = GetFilePathForImage(fileName);
      if (File.Exists(filePath)) {
        try {
          File.Delete(filePath);
        }
        catch (Exception) { //Never catch swallow the exception
         return false; //I'm a bad way of checking access to a file. Better check if you have access to the file before deleting it
        }
      }

      return false;
    }

    /// <summary>
    /// Gets the path for the given image
    /// </summary>
    /// <param name="fileName">the fileName of the image</param>
    /// <returns></returns>
    private string GetFilePathForImage(string fileName) {
      return $"{this.ImageStoreDirectory}/{fileName}";
    }

    /// <summary>
    /// Gets the image using the given fileName
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public Image GetImage(string fileName) {
      string filePath = GetFilePathForImage(fileName);
      if (!File.Exists(filePath)) {
        return null;
      }
      
      //TODO add errorHandling for ReadAllBytes call
      //TODO fetch metaData if needed
      Image result = new Image();
      result.FileName = fileName;
      result.ImageBytes = File.ReadAllBytes(filePath);
      return result;
    }
  }
}
