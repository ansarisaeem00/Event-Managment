using BackendApi2.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BackendApi2.Controllers
{
    public class FileApiController : ApiController
    {
        [HttpPost]
        [Route("api/FileAPI/SaveFil")]
        [Authorize]
        public HttpResponseMessage SaveFile()
        {
            //Create HTTP Response.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            //Check if Request contains File.
            if (HttpContext.Current.Request.Files.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            //Read the File data from Request.Form collection.
            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

            //Convert the File data to Byte Array.
            byte[] bytes;
            
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
                
            }

            //Insert the File to Database Table.
            string userid = User.Identity.GetUserId();
            ApplicationDbContext entities = new ApplicationDbContext();
            Poster file = new Poster
            {
                Name = Path.GetFileName(postedFile.FileName),
                ContentType = "image/png",
                Data = bytes

            };

            file.UserId = userid;
            //file.EventId = "hello";
            entities.Posters.Add(file);
            entities.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, new { id = file.Id, Name = file.Name });
        }
    }
}