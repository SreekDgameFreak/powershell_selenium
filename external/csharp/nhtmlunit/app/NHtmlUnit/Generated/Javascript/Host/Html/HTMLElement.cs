// Generated class v2.19.0.0, don't modify

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace NHtmlUnit.Javascript.Host.Html
{
   public partial class HTMLElement : NHtmlUnit.Javascript.Host.Element, NHtmlUnit.Javascript.IScriptableWithFallbackGetter
   {
      static HTMLElement()
      {
         ObjectWrapper.RegisterWrapperCreator((com.gargoylesoftware.htmlunit.javascript.host.html.HTMLElement o) =>
            new HTMLElement(o));
      }

      public HTMLElement(com.gargoylesoftware.htmlunit.javascript.host.html.HTMLElement wrappedObject) : base(wrappedObject) {}

      public new com.gargoylesoftware.htmlunit.javascript.host.html.HTMLElement WObj
      {
         get { return (com.gargoylesoftware.htmlunit.javascript.host.html.HTMLElement)WrappedObject; }
      }

      public HTMLElement()
         : this(new com.gargoylesoftware.htmlunit.javascript.host.html.HTMLElement()) {}


      public System.Boolean IsContentEditable
      {
         get
         {
            return WObj.getIsContentEditable();
         }
      }

      public System.Int32 Width
      {
         get
         {
            return WObj.getWidth();
         }
      }

      public System.Int32 Height
      {
         get
         {
            return WObj.getHeight();
         }
      }

      public System.String DefaultStyleDisplay
      {
         get
         {
            return WObj.getDefaultStyleDisplay();
         }
      }

      public System.Int32 PosX
      {
         get
         {
            return WObj.getPosX();
         }
      }

      public System.Int32 PosY
      {
         get
         {
            return WObj.getPosY();
         }
      }

      public NHtmlUnit.Javascript.Host.Html.HTMLElement ParentHTMLElement
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Html.HTMLElement>(
               WObj.getParentHTMLElement());
         }
      }


      public System.Int32 OffsetLeft
      {
         get
         {
            return WObj.getOffsetLeft();
         }
      }

      public System.Int32 OffsetTop
      {
         get
         {
            return WObj.getOffsetTop();
         }
      }

      public System.Int32 ScrollLeft
      {
         get
         {
            return WObj.getScrollLeft();
         }
         set
         {
            WObj.setScrollLeft(value);
         }

      }

      public System.Int32 ScrollTop
      {
         get
         {
            return WObj.getScrollTop();
         }
         set
         {
            WObj.setScrollTop(value);
         }

      }

      public System.Int32 OffsetHeight
      {
         get
         {
            return WObj.getOffsetHeight();
         }
      }

      public System.Int32 OffsetWidth
      {
         get
         {
            return WObj.getOffsetWidth();
         }
      }

      public System.String ContentEditable
      {
         get
         {
            return WObj.getContentEditable();
         }
         set
         {
            WObj.setContentEditable(value);
         }

      }

      public NHtmlUnit.Javascript.Host.Html.HTMLCollection All
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Html.HTMLCollection>(
               WObj.getAll());
         }
      }


      public System.String Id
      {
         get
         {
            return WObj.getId();
         }
         set
         {
            WObj.setId(value);
         }

      }

      public System.String Title
      {
         get
         {
            return WObj.getTitle();
         }
         set
         {
            WObj.setTitle(value);
         }

      }

      public System.Boolean Disabled
      {
         get
         {
            return WObj.getDisabled();
         }
         set
         {
            WObj.setDisabled(value);
         }

      }

      public NHtmlUnit.Javascript.Host.Html.DocumentProxy Document
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Html.DocumentProxy>(
               WObj.getDocument());
         }
      }


      public System.Int32 ClientHeight
      {
         get
         {
            return WObj.getClientHeight();
         }
      }

      public System.Int32 ClientWidth
      {
         get
         {
            return WObj.getClientWidth();
         }
      }

      public System.String InnerText
      {
         get
         {
            return WObj.getInnerText();
         }
         set
         {
            WObj.setInnerText(value);
         }

      }

      public System.Int32 AvailHeight
      {
         get
         {
            return WObj.getAvailHeight();
         }
      }

      public System.Int32 AvailWidth
      {
         get
         {
            return WObj.getAvailWidth();
         }
      }

      public System.Int32 BufferDepth
      {
         get
         {
            return WObj.getBufferDepth();
         }
      }

      public System.Int32 ColorDepth
      {
         get
         {
            return WObj.getColorDepth();
         }
      }

      public System.String ConnectionType
      {
         get
         {
            return WObj.getConnectionType();
         }
      }

      public System.Boolean CookieEnabled
      {
         get
         {
            return WObj.getCookieEnabled();
         }
      }

      public System.String CpuClass
      {
         get
         {
            return WObj.getCpuClass();
         }
      }

      public System.Boolean JavaEnabled
      {
         get
         {
            return WObj.getJavaEnabled();
         }
      }

      public System.String Platform
      {
         get
         {
            return WObj.getPlatform();
         }
      }

      public System.String SystemLanguage
      {
         get
         {
            return WObj.getSystemLanguage();
         }
      }

      public System.String UserLanguage
      {
         get
         {
            return WObj.getUserLanguage();
         }
      }

      public System.Int32 ScrollHeight
      {
         get
         {
            return WObj.getScrollHeight();
         }
      }

      public System.Int32 ScrollWidth
      {
         get
         {
            return WObj.getScrollWidth();
         }
      }

      public System.String ScopeName
      {
         get
         {
            return WObj.getScopeName();
         }
      }

      public System.String TagUrn
      {
         get
         {
            return WObj.getTagUrn();
         }
         set
         {
            WObj.setTagUrn(value);
         }

      }

      public System.Object ClientRects
      {
         get
         {
            return WObj.getClientRects();
         }
      }

      public System.String UniqueID
      {
         get
         {
            return WObj.getUniqueID();
         }
      }

      public System.Object Filters
      {
         get
         {
            return WObj.getFilters();
         }
      }

      public System.Boolean Spellcheck
      {
         get
         {
            return WObj.getSpellcheck();
         }
         set
         {
            WObj.setSpellcheck(value);
         }

      }

      public System.String Lang
      {
         get
         {
            return WObj.getLang();
         }
         set
         {
            WObj.setLang(value);
         }

      }

      public System.String Language
      {
         get
         {
            return WObj.getLanguage();
         }
         set
         {
            WObj.setLanguage(value);
         }

      }

      public System.String Dir
      {
         get
         {
            return WObj.getDir();
         }
         set
         {
            WObj.setDir(value);
         }

      }

      public System.Int32 TabIndex
      {
         get
         {
            return WObj.getTabIndex();
         }
         set
         {
            WObj.setTabIndex(value);
         }

      }

      public System.String AccessKey
      {
         get
         {
            return WObj.getAccessKey();
         }
         set
         {
            WObj.setAccessKey(value);
         }

      }

      public System.Int32 ClientLeft
      {
         get
         {
            return WObj.getClientLeft();
         }
      }

      public System.Int32 ClientTop
      {
         get
         {
            return WObj.getClientTop();
         }
      }

      public System.Object OffsetParent_js
      {
         get
         {
            return WObj.getOffsetParent_js();
         }
      }

      public NHtmlUnit.Javascript.Host.Dom.DOMStringMap Dataset
      {
         get
         {
            return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Dom.DOMStringMap>(
               WObj.getDataset());
         }
      }


      public System.Object Onsubmit
      {
         get
         {
            return WObj.getOnsubmit();
         }
         set
         {
            WObj.setOnsubmit(value);
         }

      }
// Generating method code for setActive
      public virtual void SetActive()
      {
         WObj.setActive();
      }

// Generating method code for addBehavior
      public virtual int AddBehavior(string behavior)
      {
         return WObj.addBehavior(behavior);
      }

// Generating method code for removeBehavior
      public virtual void RemoveBehavior(int id)
      {
         WObj.removeBehavior(id);
      }

// Generating method code for getWithFallback
      public virtual object GetWithFallback(string name)
      {
         var arg = WObj.getWithFallback(name);
         return ObjectWrapper.CreateWrapper<object>(arg);
      }

// Generating method code for clearAttributes
      public virtual void ClearAttributes()
      {
         WObj.clearAttributes();
      }

// Generating method code for mergeAttributes
      public virtual void MergeAttributes(NHtmlUnit.Javascript.Host.Html.HTMLElement source, object preserveIdentity)
      {
         WObj.mergeAttributes((com.gargoylesoftware.htmlunit.javascript.host.html.HTMLElement)source.WrappedObject, preserveIdentity);
      }

// Generating method code for getAttributeNodeNS
      public virtual object GetAttributeNodeNS(string namespaceURI, string localName)
      {
         var arg = WObj.getAttributeNodeNS(namespaceURI, localName);
         return ObjectWrapper.CreateWrapper<object>(arg);
      }

// Generating method code for removeAttributeNode
      public virtual void RemoveAttributeNode(NHtmlUnit.Javascript.Host.Dom.Attr attribute)
      {
         WObj.removeAttributeNode((com.gargoylesoftware.htmlunit.javascript.host.dom.Attr)attribute.WrappedObject);
      }

// Generating method code for removeNode
      public virtual NHtmlUnit.Javascript.Host.Html.HTMLElement RemoveNode(bool removeChildren)
      {
         var arg = WObj.removeNode(removeChildren);
         return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Html.HTMLElement>(arg);
      }

// Generating method code for getElementsByClassName
      public virtual NHtmlUnit.Javascript.Host.Html.HTMLCollection GetElementsByClassName(string className)
      {
         var arg = WObj.getElementsByClassName(className);
         return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Html.HTMLCollection>(arg);
      }

// Generating method code for insertAdjacentHTML
      public virtual void InsertAdjacentHTML(string position, string text)
      {
         WObj.insertAdjacentHTML(position, text);
      }

// Generating method code for insertAdjacentElement
      public virtual object InsertAdjacentElement(string whereArg, object insertedElement)
      {
         var arg = WObj.insertAdjacentElement(whereArg, insertedElement);
         return ObjectWrapper.CreateWrapper<object>(arg);
      }

// Generating method code for insertAdjacentText
      public virtual void InsertAdjacentText(string whereArg, string text)
      {
         WObj.insertAdjacentText(whereArg, text);
      }

// Generating method code for addComponentRequest
      public virtual void AddComponentRequest(string id, string idType, string minVersion)
      {
         WObj.addComponentRequest(id, idType, minVersion);
      }

// Generating method code for clearComponentRequest
      public virtual void ClearComponentRequest()
      {
         WObj.clearComponentRequest();
      }

// Generating method code for compareVersions
      public virtual int CompareVersions(string v1, string v2)
      {
         return WObj.compareVersions(v1, v2);
      }

// Generating method code for doComponentRequest
      public virtual bool DoComponentRequest()
      {
         return WObj.doComponentRequest();
      }

// Generating method code for getComponentVersion
      public virtual string GetComponentVersion(string id, string idType)
      {
         return WObj.getComponentVersion(id, idType);
      }

// Generating method code for isComponentInstalled
      public virtual bool IsComponentInstalled(string id, string idType, string minVersion)
      {
         return WObj.isComponentInstalled(id, idType, minVersion);
      }

// Generating method code for startDownload
      public virtual void StartDownload(string uri, net.sourceforge.htmlunit.corejs.javascript.Function callback)
      {
         WObj.startDownload(uri, callback);
      }

// Generating method code for isHomePage
      public virtual bool IsHomePage(string url)
      {
         return WObj.isHomePage(url);
      }

// Generating method code for navigateHomePage
      public virtual void NavigateHomePage()
      {
         WObj.navigateHomePage();
      }

// Generating method code for scrollIntoView
      public virtual void ScrollIntoView()
      {
         WObj.scrollIntoView();
      }

// Generating method code for setExpression
      public virtual void SetExpression(string propertyName, string expression, string language)
      {
         WObj.setExpression(propertyName, expression, language);
      }

// Generating method code for removeExpression
      public virtual bool RemoveExpression(string propertyName)
      {
         return WObj.removeExpression(propertyName);
      }

// Generating method code for createTextRange
      public virtual object CreateTextRange()
      {
         var arg = WObj.createTextRange();
         return ObjectWrapper.CreateWrapper<object>(arg);
      }

// Generating method code for focus
      public virtual void Focus()
      {
         WObj.focus();
      }

// Generating method code for querySelectorAll
      public virtual NHtmlUnit.Javascript.Host.Dom.StaticNodeList QuerySelectorAll(string selectors)
      {
         var arg = WObj.querySelectorAll(selectors);
         return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Dom.StaticNodeList>(arg);
      }

// Generating method code for querySelector
      public virtual NHtmlUnit.Javascript.Host.Dom.Node QuerySelector(string selectors)
      {
         var arg = WObj.querySelector(selectors);
         return ObjectWrapper.CreateWrapper<NHtmlUnit.Javascript.Host.Dom.Node>(arg);
      }

// Generating method code for click
      public virtual void Click()
      {
         WObj.click();
      }

// Generating method code for doScroll
      public virtual void DoScroll(string scrollAction)
      {
         WObj.doScroll(scrollAction);
      }

// Generating method code for releaseCapture
      public virtual bool ReleaseCapture()
      {
         return WObj.releaseCapture();
      }

// Generating method code for getOuterHTML
      public virtual string GetOuterHTML()
      {
         return WObj.getOuterHTML();
      }

// Generating method code for setOuterHTML
      public virtual void SetOuterHTML(object value)
      {
         WObj.setOuterHTML(value);
      }

// Generating method code for getClassName_js
      public virtual object GetClassName_js()
      {
         var arg = WObj.getClassName_js();
         return ObjectWrapper.CreateWrapper<object>(arg);
      }

// Generating method code for setClassName_js
      public virtual void SetClassName_js(string className)
      {
         WObj.setClassName_js(className);
      }

// Generating method code for getInnerHTML
      public virtual string GetInnerHTML()
      {
         return WObj.getInnerHTML();
      }

// Generating method code for setInnerHTML
      public virtual void SetInnerHTML(object value)
      {
         WObj.setInnerHTML(value);
      }

// Generating method code for getOnchange
      public virtual net.sourceforge.htmlunit.corejs.javascript.Function GetOnchange()
      {
         return WObj.getOnchange();
      }

// Generating method code for setOnchange
      public virtual void SetOnchange(object onchange)
      {
         WObj.setOnchange(onchange);
      }

   }


}
