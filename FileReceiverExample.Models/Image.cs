using System;
using System.Collections.Generic;

namespace FileReceiverExample.Models {

  /// <summary>
  /// This model stores all Data for an image
  /// </summary>
  public class Image {
    /// <summary>
    /// Holds the image as bytes
    /// </summary>
    public byte[] ImageBytes { get; set; }
    // The actual filename of the image
    public string FileName { get; set; }
    /// <summary>
    /// Some random metaData, could be anything
    /// </summary>
    public string SomeMetaData { get; set; }

    /// <summary>
    /// ctor
    /// </summary>
    public Image() {
    }

    /// <summary>
    /// ctorp
    /// </summary>
    /// <param name="imageBytes"></param>
    /// <param name="fileName"></param>
    /// <param name="someMetaData"></param>
    public Image(byte[] imageBytes, string fileName, string someMetaData) {
      this.ImageBytes = imageBytes;
      this.FileName = fileName;
      this.SomeMetaData = someMetaData;
    }
  }
}
