using Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Support
{
    public class ExecutionResponse<T>
    {

        ResponseState _state;
        string Lang;

        public T Result { get; set; }
        public virtual string MessageCode { get; set; }
        public virtual string Message { get; set; } = "تم بنجاح";
        Exception _exception;
        public ExecutionResponse()
        {

        }
        public ExecutionResponse(string lang = "ar")
        {
            this.Lang = lang;
            this.Message = lang == "ar" ? "تم بنجاح" : "Done Successfully";
        }

        public virtual ResponseState State
        {
            get { return _state; }
            set
            {
                _state = value;
                if (_state != ResponseState.Success && string.IsNullOrEmpty(this.Message))
                {
                    this.Message = this.Lang == "ar" ? " حدث  خطأ" : "Error has occurred";
                }
            }
        }


        public virtual Exception Exception
        {
            get
            {

                return _exception;
            }
            set
            {
                _exception = value;

            }

        }
    }
  }

