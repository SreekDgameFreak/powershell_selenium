// Generated class v2.19.0.0, don't modify

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace NHtmlUnit.Javascript.Host.Dom
{
   public partial class DOMStringMap : NHtmlUnit.Javascript.SimpleScriptable
   {
      static DOMStringMap()
      {
         ObjectWrapper.RegisterWrapperCreator((com.gargoylesoftware.htmlunit.javascript.host.dom.DOMStringMap o) =>
            new DOMStringMap(o));
      }

      public DOMStringMap(com.gargoylesoftware.htmlunit.javascript.host.dom.DOMStringMap wrappedObject) : base(wrappedObject) {}

      public new com.gargoylesoftware.htmlunit.javascript.host.dom.DOMStringMap WObj
      {
         get { return (com.gargoylesoftware.htmlunit.javascript.host.dom.DOMStringMap)WrappedObject; }
      }

      public DOMStringMap()
         : this(new com.gargoylesoftware.htmlunit.javascript.host.dom.DOMStringMap()) {}

      public DOMStringMap(NHtmlUnit.Javascript.Host.Dom.Node node)
         : this(new com.gargoylesoftware.htmlunit.javascript.host.dom.DOMStringMap((com.gargoylesoftware.htmlunit.javascript.host.dom.Node)node.WrappedObject)) {}

   }


}
