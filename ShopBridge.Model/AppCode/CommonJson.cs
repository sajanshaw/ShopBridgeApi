using System;
using System.Collections.Generic;

namespace ShopBridge.Common
{

    public class JSONRequest
    {
        public object jsondata;
    }
    public class JSONRequestGeneric<T>
    {
        public T jsondata;
    }
    public class JSONResponse
    {
        public bool status;
        public string value;
        public object jsondata;
        public int rowcount;
        public string responseMsg;
        public JSONValidation validatonMsg = new JSONValidation();
        public string errorMsg;
    }

    public class JSONValidation
    {
        public List<string> alertMessages = new List<string>();
        public string validatonType;//success,info,warning,error
    }
}
    
