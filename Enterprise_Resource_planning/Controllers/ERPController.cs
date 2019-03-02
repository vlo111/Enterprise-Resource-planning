using Enterprise_Resource_planning.Helpers;
using Enterprise_Resource_planning.Models;
using Enterprise_Resource_planning.Models.CenDek.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Enterprise_Resource_planning.Controllers
{
    public class ERPController : Controller
    {
        public static UnitOfWork _unitOfWork = new UnitOfWork();
        private static List<int> selRowIds = new List<int>();
        private static object Lock = new object();
        public static Dictionary<string, string> temp_listIds = new Dictionary<string, string>();

        /// <summary>
        /// Builds a JQGrid table! Sort, Pagination and Filter search
        /// </summary>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="searchPart"></param>
        /// <param name="startdate1"></param>
        /// <param name="finishdate1"></param>
        /// <param name="Currency"></param>
        /// <param name="Customer"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetJqGridValuesAsync(string sidx, string sord, int page, int rows, string searchPart, string startdate1, string finishdate1, int? Currency, string Customer, string name)
        {
            try
            {
                // Data Caching : class - ListPTable
                #region Cache Manager

                if (!MemoryCache.Default.Contains("CacheKey"))
                {
                    CacheManager.List = (await _unitOfWork.PartRepository.GetWithInclude(
                        p => p.CustomerContact,
                        p => p.Price,
                        p => p.Price.Currency,
                        p => p.Category));
                }
                var Results = (CacheManager.List as IEnumerable<Part>).Select(a => new
                {
                    a.PartID,
                    a.PartPrimary,
                    a.Description,
                    a.CreatedDate,
                    a.Price.SellValue,
                    a.Price.CostValue,
                    a.Price.ValidStart,
                    a.Price.ValidEnd,
                    a.Price.Currency.CurrencyID,
                    a.Price.Currency.CurrencyName,
                    a.Category.CategoryName,
                    a.CustomerContact.First
                });
                #endregion
                // Pagination in jqgrid
                if (!string.IsNullOrEmpty(name))
                {
                    name = name.Replace(" ", "");
                    Results = Results.Where(p => p.PartPrimary == name);
                    return Json(new
                    {
                        total = (int)Math.Ceiling(Results.Count() / (float)rows),
                        page,
                        records = Results.Count(),
                        rows = Results
                    }, JsonRequestBehavior.AllowGet);
                }
                // Filter of Part
                #region Search  
                if (!string.IsNullOrEmpty(searchPart))
                {
                    var PartID = Convert.ToInt32(searchPart);
                    Results = Results.ToList().Where(p => p.PartID == PartID);
                }

                if (!string.IsNullOrEmpty(Customer) & Customer != " All")
                    Results = Results.Where(p => p.First == Customer);


                if (Currency != null)
                    Results = Results.Where(p => p.CurrencyID == Currency);

                if (!string.IsNullOrEmpty(startdate1))
                    Results = Results.Where(p => p.ValidStart == DateTime.Parse(startdate1));
                if (!string.IsNullOrEmpty(finishdate1))
                    Results = Results.Where(p => p.ValidEnd == DateTime.Parse(finishdate1));
                #endregion

                // Sort a rows of Part Table
                #region order by  
                switch (sidx.ToLower())
                {
                    case "orderby_partname":
                        if (sord.ToLower() == "asc")
                            Results = Results.OrderBy(d => d.PartPrimary);
                        else
                            Results = Results.OrderByDescending(d => d.PartPrimary);
                        break;
                    case "orderby_categoryname":
                        if (sord.ToLower() == "asc")
                            Results = Results.OrderBy(d => d.CategoryName);
                        else
                            Results = Results.OrderByDescending(d => d.CategoryName);
                        break;
                    case "orderby_description":
                        if (sord.ToLower() == "asc")
                            Results = Results.OrderBy(d => d.Description);
                        else
                            Results = Results.OrderByDescending(d => d.Description);
                        break;
                    case "orderby_start":
                        if (sord.ToLower() == "asc")
                            Results = Results.OrderBy(d => d.ValidStart);
                        else
                            Results = Results.OrderByDescending(d => d.ValidStart);
                        break;
                    case "orderby_end":
                        if (sord.ToLower() == "asc")
                            Results = Results.OrderBy(d => d.ValidEnd);
                        else
                            Results = Results.OrderByDescending(d => d.ValidEnd);
                        break;
                    case "orderby_dcreated":
                        if (sord.ToLower() == "asc")
                            Results = Results.OrderBy(d => d.CreatedDate);
                        else
                            Results = Results.OrderByDescending(d => d.CreatedDate);
                        break;
                    case "orderby_cost":
                        if (sord.ToLower() == "asc")
                            Results = Results.OrderBy(d => d.CostValue);
                        else
                            Results = Results.OrderByDescending(d => d.CostValue);
                        break;
                    case "orderby_sell":
                        if (sord.ToLower() == "asc")
                            Results = Results.OrderBy(d => d.SellValue);
                        else
                            Results = Results.OrderByDescending(d => d.SellValue);
                        break;
                    case "orderby_currencyname":
                        if (sord.ToLower() == "asc")
                            Results = Results.OrderBy(d => d.CurrencyName);
                        else
                            Results = Results.OrderByDescending(d => d.CurrencyName);
                        break;
                    case "orderby_customername":
                        if (sord.ToLower() == "asc")
                            Results = Results.OrderBy(d => d.First);
                        else
                            Results = Results.OrderByDescending(d => d.First);
                        break;

                    default:
                        Results = Results.OrderBy(d => d.PartPrimary);
                        break;
                }
                #endregion
                #region Page 
                int pageIndex = Convert.ToInt32(page) - 1;
                int pageSize = rows;
                int totalRecords = Results.Count();
                var totalPages = (int)Math.Ceiling(totalRecords / (float)rows);
                #endregion

                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);

                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = Results
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [HttpGet]
        public PartialViewResult Edit()
        {
            if (selRowIds != null)
                selRowIds = null;
            return PartialView("~/Views/Parts/PriceManagement/_Edit.cshtml");
        }
        /// <summary>
        /// Multiple Editing 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="editList"></param>
        ///        Fields values : 0-radio buttons Date
        ///                        1-value date [Datepicker]
        ///                        2-checkbox Date
        ///                        3-radio buttons Percentage Price
        ///                        4-value Percentage Price
        ///                        5-checkbox PgPrice
        ///                        6-radio buttons Fixed Price
        ///                        7-value Fixed Price
        ///                        8-checkbox Fixed Price
        /// <param name="name"></param> which buttons[Apply] is clicked
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(List<int> values, List<string> editList, string name)
        {
            if (values != null)
                selRowIds = values;
            else
                values = selRowIds;

            if (selRowIds == null)
            {
                return Json(new { success = false, responseText = "Please select row(s)" }, JsonRequestBehavior.AllowGet);
            }
            foreach (var partID in values)
            {
                var part = _unitOfWork.PartRepository.Get(p => p.PartID == partID).FirstOrDefault();
                if (part != null)
                {
                    var price = _unitOfWork.PriceRepository.Get(p => p.PartID == partID).FirstOrDefault();
                    if (price != null)
                    {
                        if (part.MeasUnit.ShortDescription == null)
                            part.MeasUnit = (await _unitOfWork.MeasUnitRepository.Take(1)).FirstOrDefault();
                        if (part.Category.CategoryName == null)
                            part.Category = (await _unitOfWork.CategoryRepository.Take(1)).FirstOrDefault();
                        var list = (CacheManager.List as List<ListPTable>).Where(p => p.PartID == partID).FirstOrDefault();

                        if (name == "date")
                        {
                            if (editList.ElementAt(0) == "Start")
                            {
                                price.ValidStart = DateTime.ParseExact(editList.ElementAt(1), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                list.ValidStart = price.ValidStart;
                            }
                            else if (editList.ElementAt(0) == "End")
                            {
                                price.ValidEnd = DateTime.ParseExact(editList.ElementAt(1), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                list.ValidEnd = price.ValidEnd;
                            }
                            if (editList.ElementAt(2) == "on")
                            {
                                price.EmailCustomer = true;
                            }
                        }
                        if (name == "percentagePrice")
                        {
                            if (editList.ElementAt(3) == "PSell")
                            {
                                var sell = Convert.ToDecimal((float)price.SellValue - Convert.ToSingle(editList.ElementAt(4)) / 100F * (float)price.SellValue);
                                if (sell != list.SellValue)
                                {
                                    price.SellValue = sell;
                                    list.SellValue = sell;
                                }
                            }
                            else if (editList.ElementAt(3) == "PCost")
                            {
                                var cost = Convert.ToDecimal((float)price.CostValue - Convert.ToSingle(editList.ElementAt(4)) / 100F * (float)price.SellValue);
                                if (cost != list.CostValue)
                                {
                                    price.CostValue = cost;
                                    list.CostValue = cost;
                                }
                            }
                            if (editList.ElementAt(5) == "on")
                            {
                                price.EmailCustomer = true;
                            }
                        }
                        if (name == "FixedPrice")
                        {
                            if (editList.ElementAt(6) == "FSell")
                            {
                                var sell = Convert.ToDecimal(editList.ElementAt(7));
                                if (sell != list.SellValue)
                                {
                                    price.SellValue = sell;
                                    list.SellValue = sell;
                                }
                            }
                            else if (editList.ElementAt(6) == "FCost")
                            {
                                var cost = Convert.ToDecimal(editList.ElementAt(7));
                                if (cost != list.CostValue)
                                {
                                    price.CostValue = cost;
                                    list.CostValue = cost;
                                }
                            }
                            if (editList.ElementAt(8) == "on")
                            {
                                price.EmailCustomer = true;
                            }
                        }
                        await _unitOfWork.PriceRepository.Update(price);
                    }
                    else
                    {
                        return Json(new { success = false, responseText = "There is no price on the part, PartNo - " + (CacheManager.List as List<ListPTable>).Where(p => p.PartID == partID).Select(p => p.PartPrimary).FirstOrDefault() }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(new { success = true, responseText = "successfully changed" }, JsonRequestBehavior.AllowGet);
            //return PartialView("PriceManagement/_Edit");
        }
        /// <summary>
        /// Multiple deleting open modal action[GET] Partial View 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="DelName"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(List<int> values)
        {
            try
            {

                //  return Json(new { success = false, responseText = "Please select row(s)" }, JsonRequestBehavior.AllowGet);

                if (values != null)
                {
                    if (temp_listIds.Count() != 0)
                    {
                        temp_listIds.Clear();
                    }
                    foreach (var PartID in values)
                    {
                        var part = _unitOfWork.PartRepository.GetWithInclude(p => p.PartID == PartID, p => p.CustomerContact).FirstOrDefault();
                        part.PartPrimary = part.PartPrimary.Replace(" ", "");
                        temp_listIds.Add(part.PartPrimary, part.CustomerContact.First);
                    }
                    ViewBag.list_rows = temp_listIds;
                    return Json(new { success = true, responseText = "", data = JsonConvert.SerializeObject(temp_listIds) }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Please select row(s)" }, JsonRequestBehavior.AllowGet);
                }
                //if (temp_listIds.Count() == 0)
                //{
                //    return PartialView("PriceManagement/_Delete");
                //}
            }
            catch (Exception e)
            {

            }
            return PartialView("~/Views/Parts/PriceManagement/_Delete.cshtml", temp_listIds);
        }
        [HttpPost]
        public async Task<ActionResult> Delete()
        {

            //try
            //{
            //    foreach (var partDict in temp_listIds)
            //    {
            //        var part = _unitOfWork.PartRepository.Get(p => p.PartID == partDict.Key).FirstOrDefault();
            //        if (part.MeasUnit.ShortDescription == null)
            //            part.MeasUnit = (await _unitOfWork.MeasUnitRepository.Take(1)).FirstOrDefault();
            //        if (part.Category.CategoryName == null)
            //            part.Category = (await _unitOfWork.CategoryRepository.Take(1)).FirstOrDefault();
            //        var altPart = _unitOfWork.AltPartRepository.Get(p => p.PartID == partDict.Key).FirstOrDefault();
            //        var price = _unitOfWork.PriceRepository.Get(p => p.PartID == partDict.Key).FirstOrDefault();
            //        if (price != null)
            //            await _unitOfWork.PriceRepository.Remove(price);
            //        if (altPart != null)
            //            await _unitOfWork.AltPartRepository.Remove(altPart);
            //        await _unitOfWork.PartRepository.Remove(part);
            //        (CacheManager.List as List<ListPTable>).RemoveAll(p => p.PartID == partDict.Key);
            //    }
            return Json(new { success = true, responseText = "successfully deleted" }, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception e)
            //{
            //    if (e.InnerException.Message != null)
            //    {
            //return Json(new { success = false, responseText = e.InnerException.Message }, JsonRequestBehavior.AllowGet);
            //    }
            //    else
            //    {
            //        return Json(new { success = false, responseText = e.Message }, JsonRequestBehavior.AllowGet);

            //    }
            //}

        }
        public string Delete(string id)
        {
            //try
            //{
            //    var ids = id.Split(',');
            //    foreach (var Priceid in ids)
            //    {
            //        int prID = Convert.ToInt32(Priceid);
            //        db.Prices.Remove(db.Prices.Find(prID));
            //        await db.SaveChangesAsync();
            //    }
            //}
            //catch (Exception e)
            //{

            //    return "Error : " + e.Message;
            //}
            return "Deleted successfully";
        }
        /// <summary>
        /// In filters Field Search First name or Id
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public async Task<JsonResult> AutocompleteSearch(string term)
        {
            // Id and Name
            // var models = new[] { new { value = 0, title = "" } }.ToList();
            var models = new[] { new { title = "" } }.ToList();
            if (string.IsNullOrEmpty(term))
            {
                var mod = (CacheManager.List as List<ListPTable>).Select(p => new { value = p.PartID }).Distinct();
                return Json(mod, JsonRequestBehavior.AllowGet);
            }
            else
            {
                foreach (var item in await _unitOfWork.PartRepository.Get())
                {
                    // Search ID and Name
                    #region MyRegion

                    //if (Convert.ToString(item.PartID).Contains(term))
                    //{
                    //    models.Add(new { value = item.PartID, title = item.PartPrimary });
                    //}
                    //if (item.PartPrimary.Contains(term))
                    //{
                    //    models.Add(new { value = item.PartID, title = item.PartPrimary });
                    //}
                    #endregion
                    if (item.PartPrimary.Contains(term))
                    {
                        models.Add(new { title = item.PartPrimary });
                    }
                }
            }

            models.RemoveAt(0);

            return Json(models, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public async Task<JsonResult >AutocompleteSearchSelected(string title)
        //{
        //    await GetJqGridValuesAsync(null, null, 1, 10, null, null, null, null, null, title);
        //    return Json("", JsonRequestBehavior.AllowGet);
        //}
    }
}