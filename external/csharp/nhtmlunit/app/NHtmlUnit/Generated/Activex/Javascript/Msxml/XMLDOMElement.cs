// Generated class v2.19.0.0, don't modify

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace NHtmlUnit.Activex.Javascript.Msxml
{
   public partial class XMLDOMElement : NHtmlUnit.Activex.Javascript.Msxml.XMLDOMNode
   {
      static XMLDOMElement()
      {
         ObjectWrapper.RegisterWrapperCreator((com.gargoylesoftware.htmlunit.activex.javascript.msxml.XMLDOMElement o) =>
            new XMLDOMElement(o));
      }

      public XMLDOMElement(com.gargoylesoftware.htmlunit.activex.javascript.msxml.XMLDOMElement wrappedObject) : base(wrappedObject) {}

      public new com.gargoylesoftware.htmlunit.activex.javascript.msxml.XMLDOMElement WObj
      {
         get { return (com.gargoylesoftware.htmlunit.activex.javascript.msxml.XMLDOMElement)WrappedObject; }
      }

      public XMLDOMElement()
         : this(new com.gargoylesoftware.htmlunit.activex.javascript.msxml.XMLDOMElement()) {}


      public System.String TagName
      {
         get
         {
            return WObj.getTagName();
         }
      }
// Generating method code for removeAttribute
      public virtual void RemoveAttribute(string name)
      {
         WObj.removeAttribute(name);
      }

// Generating method code for getAttribute
      public virtual object GetAttribute(string name)
      {
         var arg = WObj.getAttribute(name);
         return ObjectWrapper.CreateWrapper<object>(arg);
      }

// Generating method code for getAttributeNode
      public virtual object GetAttributeNode(string name)
      {
         var arg = WObj.getAttributeNode(name);
         return ObjectWrapper.CreateWrapper<object>(arg);
      }

// Generating method code for removeAttributeNode
      public virtual NHtmlUnit.Activex.Javascript.Msxml.XMLDOMAttribute RemoveAttributeNode(NHtmlUnit.Activex.Javascript.Msxml.XMLDOMAttribute att)
      {
         var arg = WObj.removeAttributeNode((com.gargoylesoftware.htmlunit.activex.javascript.msxml.XMLDOMAttribute)att.WrappedObject);
         return ObjectWrapper.CreateWrapper<NHtmlUnit.Activex.Javascript.Msxml.XMLDOMAttribute>(arg);
      }

// Generating method code for setAttribute
      public virtual void SetAttribute(string name, string value)
      {
         WObj.setAttribute(name, value);
      }

// Generating method code for setAttributeNode
      public virtual NHtmlUnit.Activex.Javascript.Msxml.XMLDOMAttribute SetAttributeNode(NHtmlUnit.Activex.Javascript.Msxml.XMLDOMAttribute newAtt)
      {
         var arg = WObj.setAttributeNode((com.gargoylesoftware.htmlunit.activex.javascript.msxml.XMLDOMAttribute)newAtt.WrappedObject);
         return ObjectWrapper.CreateWrapper<NHtmlUnit.Activex.Javascript.Msxml.XMLDOMAttribute>(arg);
      }

// Generating method code for getElementsByTagName
      public virtual IList<NHtmlUnit.W3C.Dom.INode> GetElementsByTagName(string tagName)
      {

return new NodeListWrapper<NHtmlUnit.W3C.Dom.INode>(WObj.getElementsByTagName(tagName));
      }

// Generating method code for normalize
      public virtual void Normalize()
      {
         WObj.normalize();
      }

   }


}
