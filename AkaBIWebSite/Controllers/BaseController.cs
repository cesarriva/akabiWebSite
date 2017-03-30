using AkaBIWebSite.Models.Mappers;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace AkaBIWebSite.Controllers
{
    public class BaseController : Controller
    {
        private IMapper _mapper;
        public IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    return _mapper = AutoMapperConfiguration.GetMapperConfiguration().CreateMapper();
                }
                return _mapper;
            }
        }

        protected new ContentResult Json(object data, JsonRequestBehavior behaviour = JsonRequestBehavior.DenyGet)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            if (Request.RequestType == WebRequestMethods.Http.Get && behaviour == JsonRequestBehavior.DenyGet)
            {
                throw new InvalidOperationException("GET is not permitted for this request");
            }

            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(data, jsonSerializerSettings),
                ContentType = "application/json"
            };

            return jsonResult;
        }

        public void DoModelStateValidation()
        {
            if (!ModelState.IsValid)
            {
                StringBuilder stbErrors = new StringBuilder();
                stbErrors.Append("<h4>There are validation errors to fix:</h4>");

                foreach (var modelState in ModelState.Values)
                {
                    if (modelState.Errors.Any())
                    {
                        stbErrors.AppendFormat("<ul>{0}</ul>", ModelErrorsToOrderedList(modelState.Errors));
                    }
                }

                throw new Exception(stbErrors.ToString());
            }
        }

        /// <summary>
        /// Does special handling for AJAX calls
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            //TODO: Log the error with Log4Net
            if (IsAjax(filterContext))
            {
                var exception = filterContext.Exception;

                filterContext.Result = new JsonResult()
                {
                    Data = new { message = exception.Message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            else
            {
                base.OnException(filterContext);
            }
        }

        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        private string ModelErrorsToOrderedList(ModelErrorCollection errors)
        {
            var stbList = new StringBuilder();

            foreach (ModelError error in errors)
            {
                stbList.AppendFormat("<li>{0}</li>", error.ErrorMessage);
            }

            return stbList.ToString();
        }
    }
}