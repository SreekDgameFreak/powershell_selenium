// Generated class v2.19.0.0, don't modify

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace NHtmlUnit
{
   public partial class PluginConfiguration : ObjectWrapper
   {
      static PluginConfiguration()
      {
         ObjectWrapper.RegisterWrapperCreator((com.gargoylesoftware.htmlunit.PluginConfiguration o) =>
            new PluginConfiguration(o));
      }

      public PluginConfiguration(com.gargoylesoftware.htmlunit.PluginConfiguration wrappedObject) : base(wrappedObject) {}

      public com.gargoylesoftware.htmlunit.PluginConfiguration WObj
      {
         get { return (com.gargoylesoftware.htmlunit.PluginConfiguration)WrappedObject; }
      }

      public PluginConfiguration(string name, string description, string version, string filename)
         : this(new com.gargoylesoftware.htmlunit.PluginConfiguration(name, description, version, filename)) {}


      public System.String Name
      {
         get
         {
            return WObj.getName();
         }
      }

      public System.String Description
      {
         get
         {
            return WObj.getDescription();
         }
      }

      public System.String Version
      {
         get
         {
            return WObj.getVersion();
         }
      }

      public System.String Filename
      {
         get
         {
            return WObj.getFilename();
         }
      }
// Generating method code for clone
      public virtual NHtmlUnit.PluginConfiguration Clone()
      {
         var arg = WObj.clone();
         return ObjectWrapper.CreateWrapper<NHtmlUnit.PluginConfiguration>(arg);
      }

   }


}
