using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Services.Tools
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string>? ErrorMessages { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccess => ErrorMessages is null;
        [JsonIgnore]
        public bool IsFailed => !IsSuccess;

        public static ServiceResult<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                StatusCode = statusCode
            };
        }
        public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMessages = new List<string>() { errorMessage },
                StatusCode = statusCode
            };
        }
        public static ServiceResult<T> Fail(List<string> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                ErrorMessages = errors,
                StatusCode = statusCode
            };
        }
    }
    public class ServiceResult
    {
        public List<string>? ErrorMessages { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccess => ErrorMessages is null;
        [JsonIgnore] 
        public bool IsFailed => !IsSuccess;

        public static ServiceResult Success(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ServiceResult()
            {
                StatusCode = statusCode
            };
        }
        public static ServiceResult Fail(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMessages = new List<string>() { errorMessage },
                StatusCode = statusCode
            };
        }
        public static ServiceResult Fail(List<string> errors, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                ErrorMessages = errors,
                StatusCode = statusCode
            };
        }
    }
}
