﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ApplicationInstaller.Classes
{
    [Serializable]
    class XmlValidatorException : Exception
    {
        public XmlValidatorException() : base() { }

        public XmlValidatorException(string message) : base(message) { }

        public XmlValidatorException(string format, params object[] args) : base(string.Format(format, args)) { }

        public XmlValidatorException(string message, Exception innerException) : base(message, innerException) { }

        public XmlValidatorException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }

        protected XmlValidatorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
