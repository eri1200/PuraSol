using ExcelDataReader;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPurasol.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View("Upload");
        }

        
        

        // GET: Reporte/Create
        public ActionResult Create(int id)
        {
            string NombreTarifa = string.Empty;
            switch (id)
            {
               case  1:
                    NombreTarifa = "Comercial";
                    ViewBag.NombreTarifa = NombreTarifa;
                    break;

                case 2:
                    NombreTarifa = "Residencial";
                    ViewBag.NombreTarifa = NombreTarifa;
                    break;
                case 3:
                    NombreTarifa = "Microred";
                    ViewBag.NombreTarifa = NombreTarifa;
                    break;
                case 4:
                    NombreTarifa = "TMT";
                    ViewBag.NombreTarifa = NombreTarifa;
                    break;
                default:
                    return View();
                    
            }

            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {
                    // ExcelDataReader works with the binary Excel file, so it needs a FileStream
                    // to get started. This is how we avoid dependencies on ACE or Interop:
                    Stream stream = upload.InputStream;

                    // We return the interface, so that
                    IExcelDataReader reader = null;


                    if (upload.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (upload.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }

                    reader.AsDataSet();

                    DataSet result = reader.AsDataSet();
                    reader.Close();

                    return View(result.Tables[0]);
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }




        //[HttpPost]
        //public ActionResult Create()
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


    }
}
