using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicObject.Domain.Helper.HelperModel
{
    public class Response<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessful { get; private set; }
        public List<string> Errors { get; set; }
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode };
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, IsSuccessful = true, Data = default(T) };
        }

        public static Response<T> Failed(List<string> errors, int statusCode)
        {
            return new Response<T>
            {
                StatusCode = statusCode,
                IsSuccessful = false,
                Errors = errors

            };
        }

        public static Response<T> Failed(string error, int statusCode)
        {
            return new Response<T>
            {
                StatusCode = statusCode,
                IsSuccessful = false,
                Errors = new List<string>() { error }
            };
        }

    }
}
