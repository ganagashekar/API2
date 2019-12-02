
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EMSVU.API.Models
{
    public interface IResponse
    {
        string Message { get; set; }

        bool DidError { get; set; }

        string ErrorMessage { get; set; }
    }

    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }

    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
    public interface IPagedResponse<TModel> : IListResponse<TModel>
    {
        int ItemsCount { get; set; }

        double PageCount { get; }
    }
    [DataContract]
    public class Response : IResponse
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public bool DidError { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
    }

    [DataContract]
    public class SingleResponse<TModel> : ISingleResponse<TModel>
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public bool DidError { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public TModel Model { get; set; }
    }
    [DataContract]
    public class ListResponse<TModel> : IListResponse<TModel>
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public bool DidError { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public IEnumerable<TModel> Model { get; set; }
    }

    [DataContract]
    public class PagedResponse<TModel> : IPagedResponse<TModel>
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public bool DidError { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public IEnumerable<TModel> Model { get; set; }
        [DataMember]
        public int PageSize { get; set; }
        [DataMember]
        public int PageNumber { get; set; }
        [DataMember]
        public int ItemsCount { get; set; }

        [DataMember]
        public double PageCount { get; set; }

    }

    public static class ResponseExtensions
    {
        public static ActionResult ToHttpResponse(this IResponse response)
        {
            var status = response.DidError ? HttpStatusCode.InternalServerError : HttpStatusCode.OK;

            return new JsonResult()
            {
                Data = response,
            };
        }


        public static ActionResult ToHttpResponseExcelFile<TModel>(this ISingleResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NotFound;
            // HttpResponseHeader.ContentType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            // HttpResponseHeader.hea("Content-Disposition", "attachment; filename=deployment-definitions.xlsx");
            return new JsonResult()
            {
                Data = response,
            };
        }

        public static ActionResult ToHttpResponse<TModel>(this ISingleResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NotFound;

            return new JsonResult()
            {
                Data = response,
            };
        }

        public static ActionResult ToHttpResponse<TModel>(this IListResponse<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NoContent;

            return new JsonResult()
            {
                Data = response,
            };
        }

        public static ActionResult ToHttpResponseUnAuthorized<TModel>(this ISingleResponse<TModel> response)
        {
            var status = HttpStatusCode.Unauthorized;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NoContent;

            return new JsonResult()
            {
                Data = response,
            };
        }
    }
}
