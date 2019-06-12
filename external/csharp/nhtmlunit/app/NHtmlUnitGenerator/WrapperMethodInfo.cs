﻿#region License

// --------------------------------------------------
// Copyright © OKB. All Rights Reserved.
// 
// This software is proprietary information of OKB.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion

using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NHtmlUnit.Generator
{
    public class WrapperMethodInfo : IWrapperMethodBase
    {
        private readonly WrapperClassInfo classInfo;
        private readonly MethodInfo targetMethodInfo;


        public WrapperMethodInfo(WrapperClassInfo classInfo, MethodInfo targetMethodInfo)
        {
            this.targetMethodInfo = targetMethodInfo;
            this.classInfo = classInfo;
        }


        public WrapperClassInfo ClassInfo
        {
            get { return this.classInfo; }
        }

        public WrapperRepository Repository
        {
            get { return ClassInfo.Repository; }
        }

        public MethodInfo TargetMethodInfo
        {
            get { return this.targetMethodInfo; }
        }


        internal void GenerateMethodCode(StringBuilder sb)
        {
            var methodName = TargetMethodInfo.Name;
            sb.AppendLine("// Generating method code for " + methodName);

            var returnType = TargetMethodInfo.ReturnType;
            var validListMapping = WrapperRepository.GetValidMapping(returnType);
            var returnValueIsWrappedList = validListMapping != null;

            string returnTypeName = null;
            bool returnTypeIsWrapped = false;
            Type listElementType = null;
            bool listElementsAreWrapped = false;

            if (returnValueIsWrappedList)
            {
                listElementType = Repository.GetMethodReturnListType(TargetMethodInfo);

                if (listElementType == null)
                    listElementType = typeof(object);

                listElementsAreWrapped =
                    Repository.TypeIsWrapped(listElementType);

                var genericParameter =
                    listElementsAreWrapped
                        ? Repository.GetTargetFullName(listElementType)
                        : listElementType.FullName;

                returnTypeName = string.Format("{0}<{1}>", validListMapping.ToTypeName, genericParameter);
            }
            else
            {
                returnTypeIsWrapped = Repository.TypeIsWrapped(returnType);

                returnTypeName = returnTypeIsWrapped
                    ? Repository.GetTargetFullName(returnType)
                    : returnType.FullName;

                if (!returnTypeIsWrapped)
                {
                    string nativeTypeName = Repository.TranslateToNativeTypeName(returnType);

                    if (!string.IsNullOrEmpty(nativeTypeName))
                        returnTypeName = nativeTypeName;
                }
                else
                    Repository.MarkUsageOfType(returnType);
            }

            // Change from camelCase to UpperCamelCase

            string origName = methodName;
            string transformedName = origName.Substring(0, 1).ToUpper() + origName.Substring(1);

            // Check for condition where a method name has same name as property
            if (transformedName == ClassInfo.TargetNameWithoutNamespace)
            {
                if (transformedName == "Cache")
                    transformedName = "AddToCache";
            }

            // No "public" prefix on interface definition
            var publicStr = ClassInfo.IsInterface ? "" : "public ";

            var virtualStr = (!ClassInfo.IsInterface && TargetMethodInfo.IsVirtual) ? "virtual " : string.Empty;

            sb.AppendFormat("      {0}{1}{2} {3}(", publicStr, virtualStr, returnTypeName, transformedName);

            bool firstParameter = true;

            var parameters =
                TargetMethodInfo.GetParameters().Select(pi => (new WrapperParameterInfo(this, pi))).ToArray();

            foreach (var mp in parameters)
            {
                if (Repository.TypeIsWrapped(mp.ParameterType))
                    Repository.MarkUsageOfType(mp.ParameterType);
            }

            foreach (var mp in parameters)
            {
                if (!firstParameter)
                    sb.Append(", ");
                firstParameter = false;

                var parameterTypeName = mp.ParameterTypeName.Replace('+', '.');
                sb.AppendFormat("{0} {1}", parameterTypeName, mp.ParameterName);
            }
            sb.Append(")");

            if (ClassInfo.IsInterface)
                sb.Append(";\r\n");
            else
            {
                sb.Append("\r\n      {\r\n");

                // Generate function call
                var functionCallSb = new StringBuilder();

                functionCallSb.AppendFormat("WObj.{0}(", methodName);

                firstParameter = true;
                foreach (var mp in parameters)
                {
                    if (!firstParameter)
                        functionCallSb.Append(", ");
                    firstParameter = false;

                    if (mp.IsWrapped)
                    {
                        functionCallSb.AppendFormat(
                            "({0}){1}.WrappedObject", ClassInfo.SanitizeTypeName(mp.ParameterType.FullName), mp.ParameterName);
                    }
                    else
                        functionCallSb.Append(mp.ParameterName);
                }

                functionCallSb.Append(")");

                if (returnType != typeof(void))
                {
                    if (returnValueIsWrappedList)
                    {
                        sb.AppendLine();
                        sb.AppendFormat("return new {0}<{1}>({2});",
                            listElementsAreWrapped
                                ? validListMapping.FullWrapperName
                                : validListMapping.ShallowWrapperName,
                            listElementsAreWrapped
                                ? Repository.GetTargetFullName(listElementType)
                                : listElementType.FullName,
                            functionCallSb);

                        sb.AppendLine();
                    }
                    else
                    {
                        // Try to wrap returned objects, since they may be anything.
                        if (returnTypeIsWrapped || returnType == typeof(object))
                        {
                            sb.AppendFormat(
                                "         var arg = {1};\r\n" +
                                "         return ObjectWrapper.CreateWrapper<{0}>(arg);\r\n",
                                returnTypeName,
                                functionCallSb);
                        }
                        else
                            sb.AppendFormat("         return {0};\r\n", functionCallSb);
                    }
                }
                else
                    sb.AppendFormat("         {0};\r\n", functionCallSb);

                sb.Append("      }\r\n\r\n");
            }
        }


        internal void GenerateMethodCode2(StringBuilder sb)
        {
        }


        internal void GenerateMethodCodeForInterface(StringBuilder sb)
        {
            throw new NotImplementedException();
        }
    }
}