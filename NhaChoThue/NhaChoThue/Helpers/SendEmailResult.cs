using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaChoThue.Helpers
{
    public class SendEmailResult
    {
        #region Properties

        public Exception Exception
        {
            get;
            set;
        }

        public bool Failed
        {
            get { return this.Exception != null; }
        }

        public System.Net.Mail.MailMessage Message
        {
            get;
            internal set;
        }

        #endregion Properties
    }
}