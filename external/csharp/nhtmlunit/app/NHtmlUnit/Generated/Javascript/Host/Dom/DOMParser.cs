// Generated class v2.19.0.0, don't modify

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace NHtmlUnit.Javascript.Host.Dom
{
   public partial class DOMParser : NHtmlUnit.Javascript.SimpleScriptable
   {
      static DOMParser()
      {
         ObjectWrapper.RegisterWrapperCreator((com.gargoylesoftware.htmlunit.javascript.host.dom.DOMParser o) =>
            new DOMParser(o));
      }

      public DOMParser(com.gargoylesoftware.htmlunit.javascript.host.dom.DOMParser wrappedObject) : base(wrappedObject) {}

      public new com.gargoylesoftware.htmlunit.javascript.host.dom.DOMParser WObj
      {
         get { return (com.gargoylesoftware.htmlunit.javascript.host.dom.DOMParser)WrappedObject; }
      }

      public DOMParser()
         : this(new com.gargoylesoftware.htmlunit.javascript.host.dom.DOMParser()) {}

// Generating method code for parseFromString
      public virtual NHtmlUnit.Javascript.Host.Xml.XMLDocument ParseFromString(string str, object type)
      {
         var arg = WObj.parseFromString(str, type);
         return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Xml.XMLDocument>(arg);
      }

   }


}
