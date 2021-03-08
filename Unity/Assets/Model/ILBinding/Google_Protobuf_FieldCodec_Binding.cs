using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class Google_Protobuf_FieldCodec_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(Google.Protobuf.FieldCodec);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("ForInt32", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ForInt32_0);
            args = new Type[]{typeof(System.UInt32)};
            method = type.GetMethod("ForFloat", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ForFloat_1);


        }


        static StackObject* ForInt32_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @tag = (uint)ptr_of_this_method->Value;


            var result_of_this_method = Google.Protobuf.FieldCodec.ForInt32(@tag);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* ForFloat_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.UInt32 @tag = (uint)ptr_of_this_method->Value;


            var result_of_this_method = Google.Protobuf.FieldCodec.ForFloat(@tag);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }



    }
}
