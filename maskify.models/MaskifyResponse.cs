using System.Collections;

namespace maskify.models
{
    public class MaskifyResponse
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
                case 500:
                    return "Internal Server Error";
                case 401:
                    return "Unauthorized";
                case 422:
                    return "Unprocessable Entity"; ;
                case 400:
                    return "Bad Request"; ;
                case 200:
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
                case 500:
                    return "Internal Server Error";
                case 401:
                    return "Unauthorized";
                case 422:
                    return "Unprocessable Entity"; ;
                case 400:
                    return "Bad Request"; ;
                case 200:
                    return "OK";
            }

            return defaultValue;
        }
    }

    public class MaskifyResponse<T> : MaskifyResponse
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
