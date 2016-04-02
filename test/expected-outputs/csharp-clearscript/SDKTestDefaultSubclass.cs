using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manticore;

/**
 * SDKTestDefaultSubclass.cs
 * 
 *
 * DO NOT EDIT THIS FILE! IT IS AUTOMATICALLY GENERATED AND SHOULD NOT BE CHECKED IN.
 * 
 *
 * 
 */
namespace Manticore
{
  public class SDKTestDefaultSubclass : SDKTestDefault {

      new internal static SDKTestDefaultSubclass NativeInstanceForObject(dynamic value) {
      if (Engine.IsNullOrUndefined(value)) {
        return null;
      }
      
      return new SDKTestDefaultSubclass(new JsValueHolder(value));
    }

    internal SDKTestDefaultSubclass(object value) : base(value) {
    }

    public SDKTestDefaultSubclass() {
      this.impl = Engine.CreateJsObject("SDKTestDefaultSubclass", null);
    }


        /**
         * Test subclass
         */
        public bool IsItDerived()
        {
            return Engine.JsWithReturn(() =>
            {
                dynamic returnValue = this.impl.isItDerived();
              return Engine.Converter.AsNativeBool(returnValue);
            });
        }

        /**
         * Test derived classes
         */
        public static SDKTestDefault GetDerived()
        {
            return Engine.JsWithReturn(() =>
            {
                dynamic returnValue = Engine.GetJsClass("SDKTestDefaultSubclass").getDerived();
              return (Engine.IsNullOrUndefined(returnValue) ? null : SDKTestDefault.NativeInstanceForObject(returnValue));
            });
        }


    }
}
