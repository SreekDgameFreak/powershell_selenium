// Generated class v2.19.0.0, don't modify

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace NHtmlUnit.Html
{
   public partial class HtmlArticle : NHtmlUnit.Html.HtmlElement, NHtmlUnit.W3C.Dom.INode, NHtmlUnit.W3C.Dom.IElement, NHtmlUnit.W3C.Dom.IElementTraversal
   {
      static HtmlArticle()
      {
         ObjectWrapper.RegisterWrapperCreator((com.gargoylesoftware.htmlunit.html.HtmlArticle o) =>
            new HtmlArticle(o));
      }

      public HtmlArticle(com.gargoylesoftware.htmlunit.html.HtmlArticle wrappedObject) : base(wrappedObject) {}

      public new com.gargoylesoftware.htmlunit.html.HtmlArticle WObj
      {
         get { return (com.gargoylesoftware.htmlunit.html.HtmlArticle)WrappedObject; }
      }

   }


}
