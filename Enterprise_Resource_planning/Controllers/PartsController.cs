using Enterprise_Resource_planning.Models;
using Enterprise_Resource_planning.Models.CenDek.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using File = Enterprise_Resource_planning.Models.CenDek.Tables.File;

namespace Enterprise_Resource_planning.Controllers
{
    public class PartsController : Controller
    {
        #region Local Fields
        UnitOfWork _unitOfWork = new UnitOfWork();
        private static List<File> _listSelectedFiles = new List<File>();
        private static List<FileTmp> _listFiles = new List<FileTmp>();
        private static Image _image = new Image();
        #endregion
        #region Index Get and Post

        // GET: Parts
        public async Task<ActionResult> Index()
        {
            await InitVBAsync();
            var customer = (_unitOfWork.CustomerContactRepository.Get()).GroupBy(p => p.First).Select(p => new { name = p.Key }).ToList();
            ViewBag.CustomerID = new SelectList(customer, "name", "name");


            if (Session["TmpModel"] != null)
            {
                var modelErrors = (ModelStateDictionary)Session["TmpModel"];

                foreach (ModelState modelState in modelErrors.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        if (error.ErrorMessage == "Required field Start Date" || error.ErrorMessage == "Required field End Date" || error.ErrorMessage == "Required field Cost" || error.ErrorMessage == "Required field Sell")
                        {
                            ModelState.AddModelError("ReviewErrors", "The Price is invalid");
                        }
                        else
                        {
                            ModelState.AddModelError("PartErrors", error.ErrorMessage);
                        }
                    }
                }

            }
            return View();
        }
        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PartCreate(
    [Bind(Include = "CategoryID,AltPart,Name,Description,ProductLineID,PartStatusID,CustomFlag,Comments,ModifiedDate,Weight,Height,Width,Length,MeasUnitID,PartInventoryID")] Part part,
    [Bind(Include = "PartID,DateCreated,CostValue,CostCurrencyID,SellValue,SellCurrencyID,EmployeeID")] Price price,
    string CategoryName, string startdate, string finishdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var date = DateTime.Today;
                    var category = _unitOfWork.CategoryRepository.Get(n => n.CategoryName == CategoryName);
                    part.Files = _listSelectedFiles;
                    if (_image != null)
                    {
                        if (!string.IsNullOrEmpty(_image.Name))
                        {
                            part.Image = _image;
                            part.ImageID = _image.ImageID;
                        }
                    }
                    part.PartID = new Random().Next();
                    part.PriceID = price.ID;
                    part.CreatedDate = date;
                    part.EmployeeID = 1;
                    part.ModifiedDate = date;
                    part.CategoryID = category.Select(i => i.CategoryID).FirstOrDefault();
                    part.Category = category.FirstOrDefault();
                    part.MeasUnit = _unitOfWork.MeasUnitRepository.Get(p => p.MeasUnitID == part.MeasUnitID).FirstOrDefault();
                    await _unitOfWork.PartRepository.Create(part);

                    price.PartID = part.PartID;
                    price.EmployeeID = 1;
                    price.DateCreated = date;
                    price.ValidStart = DateTime.ParseExact(startdate, "dd.MM.yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                    price.ValidEnd = DateTime.ParseExact(finishdate, "dd.MM.yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                    await _unitOfWork.PriceRepository.Create(price);

                    await InitVBAsync();
                    var customer = _unitOfWork.CustomerContactRepository.Get();
                    var cust = (from p in customer
                                select new { id = p.CustomerID, name = p.First }).Distinct();

                    ViewBag.CustomerID = new SelectList(cust, "id", "name");

                    foreach (var item in _listFiles)
                    {
                        string filePath = Path.Combine(Server.MapPath(@"~/Images/WallFiles/filepath"), item.Name + '.' + item.Type);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }
                    string imagePath = Path.Combine(Server.MapPath(@"~/Images/WallImages/imagepath"), _image.Name + '.' + _image.Ext);

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    _listFiles.Clear();
                    _listSelectedFiles.Clear();

                    return View("Index");
                }
                else
                {
                    Session["TmpModel"] = ViewData.ModelState;
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                var s = e.Message;
            }

            return View("Index");
        }
        #endregion
        #region Initialization ViewBag Tables for Index
        public async Task InitVBAsync()
        {
            ViewBag.ProductLineID = new SelectList(_unitOfWork.ProductLineRepository.Get(), "ProductLineID", "Name");
            ViewBag.MeasUnitID = new SelectList(_unitOfWork.MeasUnitRepository.Get(), "MeasUnitID", "ShortDescription");

            ViewBag.PartStatusID = new SelectList(_unitOfWork.PartStatuRepository.Get(), "PartStatusID", "Status");
            ViewBag.CostCurrencyID = new SelectList(_unitOfWork.CurrencyRepository.Get(), "CurrencyID", "CurrencyName");
            ViewBag.SellCurrencyID = new SelectList(_unitOfWork.CurrencyRepository.Get(), "CurrencyID", "CurrencyName");
        }
        #endregion
        #region Category GET
        // GET: CategoryCreate
        public ActionResult CategoryCreate()
        {

            ViewBag.CategoryParentID = new SelectList(GetCategoriesParents(), "CategoryID", "Name");
            return PartialView("Pats/CategoryCreate");
        }
        private List<Category> GetCategoriesParents()
        {
            var parents = _unitOfWork.CategoryRepository.Get(c => c.CategoryParentID == 0).OrderBy(a => a.CategoryName);
            List<Category> child = new List<Category>();
            foreach (var parent in parents)
            {
                foreach (var item in _unitOfWork.CategoryRepository.Get(x => x.CategoryParentID == parent.CategoryID))
                {
                    child.Add(item);
                }
            }
            return child;
        }
        #endregion
        #region Currency Post
        // POST: Parts/CurrencyCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CurrencyCreate([Bind(Include = "Code,Name")] Currency currency)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (currency != null)
                    {
                        await _unitOfWork.CurrencyRepository.Create(currency);
                    }
                    else
                    {
                        return Json(new { warning = "currency is null" });
                    }
                }
                else
                {
                    return Json(new { warning = "model is not valid" });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(currency);
            }
            return RedirectToAction("Index", "Parts");
        }

        #endregion
        #region MeasUnit GET and POST
        // GET: MeasUnitCreate
        public ActionResult MeasUnitCreate()
        {
            return View();
        }
        // POST: Parts/MeasUnitCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MeasUnitCreate([Bind(Include = "ShortDescription, LongDescription")] MeasUnit measUnit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (measUnit != null)
                    {
                        await _unitOfWork.MeasUnitRepository.Create(measUnit);
                    }
                    else
                    {
                        return Json(new { warning = "status is null" });
                    }
                }
                else
                {
                    return Json(new { warning = "model is not valid" });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(measUnit);
            }
            return RedirectToAction("Index", "Parts");
        }
        #endregion
        #region ProductLine GET and POST
        // GET: ProductLine
        public ActionResult ProductLineCreate()
        {
            return View();
        }
        // POST: Parts/ProductLineCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProductLineCreate([Bind(Include = "Name, Description")] ProductLine productLine)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (productLine != null)
                    {
                        await _unitOfWork.ProductLineRepository.Create(productLine);
                    }
                    else
                    {
                        return Json(new { warning = "ProductLines is null" });
                    }
                }
                else
                {
                    return Json(new { warning = "model is not valid" });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(productLine);
            }
            return RedirectToAction("Index", "Parts");
        }
        #endregion
        #region Status GET and POST
        // GET: StatusCreate
        public ActionResult StatusCreate()
        {
            return View();
        }
        // POST: Parts/StatusCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> StatusCreate([Bind(Include = "Status")] PartStatu partStatu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (partStatu != null)
                    {
                        partStatu.PartStatusID = new Random().Next();
                        await _unitOfWork.PartStatuRepository.Create(partStatu);
                    }
                    else
                    {
                        return Json(new { warning = "status is null" });
                    }
                }
                else
                {
                    return Json(new { warning = "model is not valid" });
                }
            }
            catch (Exception e)
            {
                return Json(new { warning = e.Message });
            }
            return RedirectToAction("Index", "Parts");
        }
        #endregion
        #region File and Image
        /// <summary>
        /// This method saves the image for each click on the «Image_ Dropzone»
        /// </summary>
        public async Task<PartialViewResult> SelectedImageView()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            var image = new Image();
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;

                    List<string> extensions = new List<string>() { ".gif", ".png", ".jpg" };
                    string extension = Path.GetExtension(fName);

                    if (extensions.Contains(extension))
                    {

                        if (file != null && file.ContentLength > 0)
                        {
                            int size = 2 * 1024 * 1024;
                            if (file.ContentLength <= size)
                            {
                                var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\WallImages", Server.MapPath(@"\")));

                                string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");

                                var fileName1 = Path.GetFileName(file.FileName);

                                bool isExists = System.IO.Directory.Exists(pathString);

                                if (!isExists)
                                    System.IO.Directory.CreateDirectory(pathString);

                                var path = string.Format("{0}\\{1}", pathString, file.FileName);
                                file.SaveAs(path);

                                BinaryReader b = new BinaryReader(file.InputStream);
                                byte[] binData = b.ReadBytes((int)file.InputStream.Length);
                                image = new Image { Name = fileName1.Remove(fileName1.Length - 4), Ext = extension.Replace(".", ""), Image1 = binData };
                                await _unitOfWork.ImageRepository.Create(image);
                                _image = image;
                            }
                            else
                            {
                                //ViewBag.Message = "Maximum allowed file size is 2 mb";
                            }
                        }
                    }
                    else
                    {
                        //ViewBag.Message = "Error. Valid file extensions - '.png', '.jpg', '.gif'";
                    }
                }

            }
            catch (Exception)
            {
                isSavedSuccessfully = false;
            }

            if (isSavedSuccessfully)
            {
                ViewBag.success = fName;
            }
            else
            {
                ViewBag.Message = "Error in saving file";
            }
            if (_image != null)
                return PartialView("Partial_Views/_ImageView", !string.IsNullOrEmpty(_image.Name) ? _image : null);
            else
                return PartialView("Partial_Views/_ImageView");
        }
        /// <summary>
        /// This method deletes the image, when for deletion press the button from «Image_ Dropzone» or «_ImageView»
        /// </summary>
        /// <param name="ImageID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> DeleteImageFromImageViewOrDropzone(int? ImageID, string name)
        {
            if (_image != null)
            {
                try
                {
                    await _unitOfWork.ImageRepository.Remove(_unitOfWork.ImageRepository.Get(n => n.ImageID == _image.ImageID).FirstOrDefault());
                    _image = null;
                }
                catch (Exception)
                {
                }
            }
            return PartialView("Partial_Views/_ImageView", _image);
        }
        /// <summary>
        /// This method saves files for each click on the «File_ Dropzone»
        /// </summary>
        public async Task<PartialViewResult> SelectedFilesView()
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            try
            {
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    //Save file content goes here
                    fName = file.FileName;

                    List<string> extensions = new List<string>() { ".gif", ".png", ".jpg", ".txt", ".pdf" };
                    string extension = Path.GetExtension(fName);

                    if (extensions.Contains(extension))
                    {

                        if (file != null && file.ContentLength > 0)
                        {
                            int size = 5 * 1024 * 1024;
                            if (file.ContentLength <= size)
                            {
                                var originalDirectory = new DirectoryInfo(string.Format("{0}Images\\WallFiles", Server.MapPath(@"\")));

                                string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "filepath");

                                var fileName1 = Path.GetFileName(file.FileName);

                                bool isExists = System.IO.Directory.Exists(pathString);

                                if (!isExists)
                                    System.IO.Directory.CreateDirectory(pathString);

                                var path = string.Format("{0}\\{1}", pathString, file.FileName);
                                file.SaveAs(path);

                                BinaryReader b = new BinaryReader(file.InputStream);
                                byte[] binData = b.ReadBytes((int)file.InputStream.Length);
                                string name = "";
                                if (extension.Length == 4)
                                {
                                    name = fileName1.Remove(fileName1.Length - 4);
                                }
                                else if (extension.Length == 5)
                                {
                                    name = fileName1.Remove(fileName1.Length - 5);
                                }
                                _listFiles.Add(new FileTmp { ID = new Random().Next(), Name = name, Type = extension.Replace(".", ""), Contents = binData });
                                ViewBag.DocumentTypeID = new SelectList(_unitOfWork.DocumentTypeRepository.Get(), "DocumentTypeID", "Name");
                            }
                            else
                            {
                                //ViewBag.Message = "Maximum allowed file size is 5 mb";
                            }
                        }
                    }
                    else
                    {
                        //ViewBag.Message = "Error. Valid file extensions - '.png', '.jpg', '.gif', '.pdf','.txt'";
                    }
                }

            }
            catch (Exception)
            {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                ViewBag.success = fName;
            }
            else
            {
                ViewBag.Message = "Error in saving file";
            }

            return PartialView("Partial_Views/_FilesHome", _listFiles.Count != 0 ? _listFiles : null);
        }
        /// <summary>
        /// This method deletes files, when for deletion press the button from «File_ Dropzone» or «_FilesView»
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult DeleteFilesFromDropzoneOrFilesView(string name, int? id)
        {
            var list = _listFiles.Find(i => i.Name == name);
            if (list != null)
            {
                _listFiles.Remove(list);
                if (_listSelectedFiles.Find(i => i.Name == name) != null)
                {
                    _listSelectedFiles.Remove(_listSelectedFiles.Find(i => i.Name == name));
                }
                return PartialView("Partial_Views/_FilesHome", _listFiles);
            }
            else if (id != null)
            {
                var file = _listFiles.Where(p => p.ID == id).FirstOrDefault();
                var selectedfile = _listSelectedFiles.Find(i => i.Name == file.Name);
                if (file != null)
                {
                    _listFiles.Remove(file);
                }
                else
                {
                    return Json(new { warning = "file not found" });
                }
                if (selectedfile != null)
                {
                    _listSelectedFiles.Remove(selectedfile);
                }
                return PartialView("Partial_Views/_FilesHome", _listFiles);
            }
            else
            {
                return Json(new { warning = "Files is not valid" }); ;
            }
        }
        // GET: SaveFile
        [HttpGet]
        public async Task<ActionResult> SaveFile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = new File();
            var filetmp = _listFiles.Where(p => p.ID == id).FirstOrDefault();
            if (filetmp != null)
            {
                file.FileID = filetmp.ID;
                file.Name = filetmp.Name;
                file.Type = filetmp.Type;
            }

            ViewBag.DocumentTypeID = new SelectList(_unitOfWork.DocumentTypeRepository.Get(), "DocumentTypeID", "Name", file?.DocumentTypeID);
            return PartialView("Partial_Views/_FilesSaved", file);
        }
        // POST: File/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveFile(File file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var filetmp = _listFiles.Where(p => p.ID == file.FileID).FirstOrDefault();
                    if (filetmp != null)
                    {
                        _listSelectedFiles.Add(new File { Name = filetmp.Name, Type = filetmp.Type, Contents = filetmp.Contents, DocumentTypeID = file.DocumentTypeID, EmployeeID = file.EmployeeID });
                    }
                    else
                    {
                        return Json(new { warning = "file not found" });
                    }
                }
                else
                {
                    return Json(new { warning = "model is not valid" });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(file);
            }
            return PartialView("Partial_Views/_FilesSelected", _listSelectedFiles);
        }
        /// <summary>
        /// This method refreshes partial view Files
        /// </summary>
        /// <returns></returns>
        public ActionResult Refresh()
        {
            return PartialView("Partial_Views/_FilesSelected", _listSelectedFiles);
        }
        #endregion
    }
}