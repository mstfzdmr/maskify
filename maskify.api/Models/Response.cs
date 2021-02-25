using Microsoft.AspNetCore.Http;
using System.Collections;

namespace maskify.api.Models
{
    public class Response
    {
        private string _message = string.Empty;
        private string _internalMessage = string.Empty;
        public int Code { get; set; }
        public string Message
        {
            get => GetMessage(Code, _internalMessage);
            set => _internalMessage = value;
        }
        private string GetMessage(int code, string defaultValue)
        {
            if (!string.IsNullOrEmpty(defaultValue))
                return defaultValue;

            switch (code)
            {
                case StatusCodes.Status500InternalServerError:
                    return "Internal Server Error";
                case StatusCodes.Status401Unauthorized:
                    return "Unauthorized";
                case StatusCodes.Status422UnprocessableEntity:
                    return "Unprocessable Entity"; ;
                case StatusCodes.Status400BadRequest:
                    return "Bad Request"; ;
                case StatusCodes.Status200OK:
                    return "OK";
            }

            return defaultValue;
        }
        public string InternalMessage
        {
            get => GetInternalMessage(Code, _internalMessage);
            set => _internalMessage = value;
        }
        private string GetInternalMessage(int code, string defaultValue)
        {
            if (!string.IsNullOrEmpty(defaultValue))
                return defaultValue;

            switch (code)
            {
                case StatusCodes.Status500InternalServerError:
                    return "Internal Server Error";
                case StatusCodes.Status401Unauthorized:
                    return "Unauthorized";
                case StatusCodes.Status422UnprocessableEntity:
                    return "Unprocessable Entity"; ;
                case StatusCodes.Status400BadRequest:
                    return "Bad Request"; ;
                case StatusCodes.Status200OK:
                    return "OK";
            }

            return defaultValue;
        }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
        private int _total;
        public int Total
        {
            get
            {
                if (_total == 0 && Data != null && Data is IList list)
                {
                    Total = list.Count;
                }

                return _total;
            }
            set => _total = value;
        }
    }
}
