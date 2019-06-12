// Generated class v2.19.0.0, don't modify

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace NHtmlUnit.Javascript.Host
{
   public partial class Element : NHtmlUnit.Javascript.Host.Dom.EventNode
   {
      static Element()
      {
         ObjectWrapper.RegisterWrapperCreator((com.gargoylesoftware.htmlunit.javascript.host.Element o) =>
            new Element(o));
      }

      public Element(com.gargoylesoftware.htmlunit.javascript.host.Element wrappedObject) : base(wrappedObject) {}

      public new com.gargoylesoftware.htmlunit.javascript.host.Element WObj
      {
         get { return (com.gargoylesoftware.htmlunit.javascript.host.Element)WrappedObject; }
      }

      public Element()
         : this(new com.gargoylesoftware.htmlunit.javascript.host.Element()) {}


      public System.String TagName
      {
         get
         {
            return WObj.getTagName();
         }
      }

      public System.String BaseURI
      {
         get
         {
            return WObj.getBaseURI();
         }
      }

      public NHtmlUnit.Javascript.Host.ClientRect BoundingClientRect
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.ClientRect>(
               WObj.getBoundingClientRect());
         }
      }


      public System.Int32 ChildElementCount
      {
         get
         {
            return WObj.getChildElementCount();
         }
      }

      public NHtmlUnit.Javascript.Host.Element FirstElementChild
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Element>(
               WObj.getFirstElementChild());
         }
      }


      public NHtmlUnit.Javascript.Host.Element LastElementChild
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Element>(
               WObj.getLastElementChild());
         }
      }


      public NHtmlUnit.Javascript.Host.Element NextElementSibling
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Element>(
               WObj.getNextElementSibling());
         }
      }


      public NHtmlUnit.Javascript.Host.Element PreviousElementSibling
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Element>(
               WObj.getPreviousElementSibling());
         }
      }


      public NHtmlUnit.Javascript.Host.Html.HTMLCollection Children
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Html.HTMLCollection>(
               WObj.getChildren());
         }
      }


      public NHtmlUnit.Javascript.Host.Dom.DOMTokenList ClassList
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Dom.DOMTokenList>(
               WObj.getClassList());
         }
      }


      public NHtmlUnit.Javascript.Host.Css.CSSStyleDeclaration Style
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Css.CSSStyleDeclaration>(
               WObj.getStyle());
         }
      }


      public NHtmlUnit.Javascript.Host.Css.CSSStyleDeclaration RuntimeStyle
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Css.CSSStyleDeclaration>(
               WObj.getRuntimeStyle());
         }
      }


      public NHtmlUnit.Javascript.Host.Css.ComputedCSSStyleDeclaration CurrentStyle
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Css.ComputedCSSStyleDeclaration>(
               WObj.getCurrentStyle());
         }
      }

// Generating method code for selectNodes
      public virtual NHtmlUnit.Javascript.Host.Html.HTMLCollection SelectNodes(string expression)
      {
         var arg = WObj.selectNodes(expression);
         return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Html.HTMLCollection>(arg);
      }

// Generating method code for selectSingleNode
      public virtual object SelectSingleNode(string expression)
      {
         var arg = WObj.selectSingleNode(expression);
         return ObjectWrapper.CreateWrapper<object>(arg);
      }

// Generating method code for getAttribute
      public virtual object GetAttribute(string attributeName, java.lang.Integer flags)
      {
         var arg = WObj.getAttribute(attributeName, flags);
         return ObjectWrapper.CreateWrapper<object>(arg);
      }

// Generating method code for setAttribute
      public virtual void SetAttribute(string name, string value)
      {
         WObj.setAttribute(name, value);
      }

// Generating method code for getElementsByTagName
      public virtual NHtmlUnit.Javascript.Host.Html.HTMLCollection GetElementsByTagName(string tagName)
      {
         var arg = WObj.getElementsByTagName(tagName);
         return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Html.HTMLCollection>(arg);
      }

// Generating method code for getAttributeNode
      public virtual object GetAttributeNode(string name)
      {
         var arg = WObj.getAttributeNode(name);
         return ObjectWrapper.CreateWrapper<object>(arg);
      }

// Generating method code for getElementsByTagNameNS
      public virtual object GetElementsByTagNameNS(object namespaceURI, string localName)
      {
         var arg = WObj.getElementsByTagNameNS(namespaceURI, localName);
         return ObjectWrapper.CreateWrapper<object>(arg);
      }

// Generating method code for hasAttribute
      public virtual bool HasAttribute(string name)
      {
         return WObj.hasAttribute(name);
      }

// Generating method code for removeAttribute
      public virtual void RemoveAttribute(string name)
      {
         WObj.removeAttribute(name);
      }

// Generating method code for getAttributeNS
      public virtual string GetAttributeNS(string namespaceURI, string localName)
      {
         return WObj.getAttributeNS(namespaceURI, localName);
      }

// Generating method code for hasAttributeNS
      public virtual bool HasAttributeNS(string namespaceURI, string localName)
      {
         return WObj.hasAttributeNS(namespaceURI, localName);
      }

// Generating method code for setAttributeNS
      public virtual void SetAttributeNS(string namespaceURI, string qualifiedName, string value)
      {
         WObj.setAttributeNS(namespaceURI, qualifiedName, value);
      }

// Generating method code for removeAttributeNS
      public virtual void RemoveAttributeNS(string namespaceURI, string localName)
      {
         WObj.removeAttributeNS(namespaceURI, localName);
      }

// Generating method code for setAttributeNode
      public virtual NHtmlUnit.Javascript.Host.Dom.Attr SetAttributeNode(NHtmlUnit.Javascript.Host.Dom.Attr newAtt)
      {
         var arg = WObj.setAttributeNode((com.gargoylesoftware.htmlunit.javascript.host.dom.Attr)newAtt.WrappedObject);
         return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Dom.Attr>(arg);
      }

// Generating method code for blur
      public virtual void Blur()
      {
         WObj.blur();
      }

   }


}
