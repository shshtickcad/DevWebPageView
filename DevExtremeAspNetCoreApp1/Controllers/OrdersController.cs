using DevExtremeAspNetCoreApp1.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DevExtremeAspNetCoreApp1.Controllers
{

    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        //[HttpGet("RemoteFolders")]
        //public object GetRemoteFolders(DataSourceLoadOptions loadOptions)
        //{
        //    return DataSourceLoader.Load(SampleData.GettingFoldersList(), loadOptions);
        //}

        [HttpGet("Top")]
        public object GetFolders(int parentId)
        {
            var value = SampleData.GetFolder(parentId).Result;

            var folder = value
                            .Select(x => new
                            {
                                id = x.Id,
                                folderId = x.Folder.Id,
                                parentId = x.Folder.ParentFolderId,
                                text = x.Name
                            });

            return folder;
        }

        [HttpGet("GetFiles")]
        public object GetFiles(int folderId)
        {
            var result = SampleData.GetFiles(folderId).Result;

            var file = result.Select(x => new {
                id = x.Id,
                name = x.Name,
                dateCreated = x.DateCreated,
                type = x.Type
            });
            return  file;
        }

        /*public ActionResult GridView()
        {
            var result = SampleData.GettingFiles().Result;

            var fil = (from c in result
                         select new TickToolCloud.Entities.Entity.FileMaster
                         {
                             //Id = c.Id,
                             FileName = c.FileName,
                             DateUpdated = c.DateUpdated,
                             Size = c.Size,
                             VersionNumber = c.VersionNumber
                         }).ToList();

            return View(fil);
        }*/
    }
}