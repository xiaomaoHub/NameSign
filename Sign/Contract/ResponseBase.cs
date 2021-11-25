using System;

namespace Sign.Contract
{
    /// <summary>
    /// BaseResponse
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// ResponseBase
        /// </summary>
        public ResponseBase()
        {
            this.Init();
        }

        /// <summary>
        /// ResponseBase
        /// </summary>
        /// <param name="isSuccess"></param>
        public ResponseBase(bool isSuccess)
        {
            this.Init();
            if (isSuccess)
                this.Success();
            else
                this.Error();
        }

        /// <summary>
        /// Init
        /// </summary>
        public void Init()
        {
            this.Code = -1;
            this.Msg = string.Empty;
            this.ErrMsg = string.Empty;
            this.SubCode = string.Empty;
            this.SubMsg = string.Empty;
            this.IsSuccess = false;
        }

        /// <summary>
        /// Error
        /// </summary>
        public void Error()
        {
            this.Error(string.Empty, StatusCodeEnum.ServiceInternalError);
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="code"></param>
        public void Error(string errMsg, StatusCodeEnum code)
        {
            this.Code = (int)code;
            this.ErrMsg = !string.IsNullOrEmpty(errMsg) ? errMsg : string.Empty;
            this.IsSuccess = false;
        }

        /// <summary>
        /// Success
        /// </summary>
        public void Success()
        {
            this.Success(string.Empty, StatusCodeEnum.Success);
        }

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="code"></param>
        public void Success(string msg, StatusCodeEnum code)
        {
            this.Code = (int)code;
            this.Msg = !string.IsNullOrEmpty(msg) ? msg : nameof(Success);
            this.IsSuccess = true;
        }

        /// <summary>
        /// IsSuccess
        /// success:true, fail:false
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Code
        /// success:20000
        /// fail:others
        /// InvalidParameter:-1
        /// ServiceInternalError:40000
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// message
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// data
        /// </summary>
        public virtual object Result { get; set; }

        /// <summary>
        /// ErrMsg
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// SubCode
        /// </summary>
        public string SubCode { get; set; }

        /// <summary>
        /// SubMsg
        /// </summary>
        public string SubMsg { get; set; }
    }
}
