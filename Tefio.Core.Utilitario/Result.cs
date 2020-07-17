using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using Tefio.Core.Location;

namespace Tefio.Core.Utilitario
{
    public class Result
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetail { get; set; }
        public int rowsAffected { get; set; }
        public object Data { get; set; }

        public Result()
        {
            this.Code = ResultTable.RESULT_OK_CODE;
            this.Message = ResultTable.RESULT_OK_MSG;
            this.ErrorCode = "";
            this.ErrorMessage = "";
            this.ErrorDetail = "";
        }

        public Result(string code, string msg)
        {
            this.setError(code, msg);
        }

        public Result(string code, string msg, string detail)
        {
            this.setError(code, msg, detail);
        }

        public void setError(string code, string msg)
        {
            this.Code = ResultTable.RESULT_CODE_ERROR;
            this.Message = ResultTable.RESULT_ERR_GENERIC_MSG;
            this.ErrorCode = code;
            this.ErrorMessage = msg;

        }
        public void setError(string code)
        {
            this.Code = code;
            //this.Message = ResultTable.;
            this.Message = Resources.ResourceManager.GetString(code, Resources.Culture);
            this.ErrorCode = code;
            this.ErrorMessage = this.Message;
            this.ErrorDetail = String.Empty;
        }
        public void setError(string code, string msg, string detail)
        {
            setError(code, msg);
            this.ErrorDetail = detail;
        }
    }
}
