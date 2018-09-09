using FileReceiverExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileReceiverExample.Controllers {
  /// <summary>
  /// Manages images
  /// Note: The Route will be "api/Images" it cuts of the controller. All controllers have to be named in this pattern
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class ImagesController {
    private readonly ImageManager _imageManager;

    /// <summary>
    /// ctor
    /// </summary>
    public ImagesController() {
      this._imageManager = new ImageManager();
    }

    /// <summary>
    /// Posts a new image
    /// </summary>
    /// <param name="value"></param>
    [HttpPost]
    public void Post([FromBody] string value) {
      Image newImage = Newtonsoft.Json.JsonConvert.DeserializeObject<Image>(value);
      this._imageManager.UpsertImage(newImage);
    }

    /// <summary>
    /// Deletes an image
    /// DELETE api/images/CoolPicture.png
    /// </summary>
    /// <param name="fileName"></param>
    [HttpDelete("{fileName}")]
    public void Delete(string fileName) {
      this._imageManager.DeleteImage(fileName);
    }

    /// <summary>
    /// Gets an image by its name
    /// GET api/images/CoolPicture.png
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    [HttpGet("{fileName}")]
    public ActionResult<Image> Get(string fileName) {
      return new ActionResult<Image>(this._imageManager.GetImage(fileName));
    }
  }
}
