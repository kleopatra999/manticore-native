using Jint;
using Jint.Native;
using Jint.Native.Object;
using Jint.Native.Function;
using Jint.Runtime.Interop;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Manticore;

/**
 * SDKTest.cs
 * This single file basically fakes the real SDK and exercises the various ways the native engines
 * interact with Javascript.
 * DO NOT EDIT THIS FILE! IT IS AUTOMATICALLY GENERATED AND SHOULD NOT BE CHECKED IN.
 * 
 *
* 
 */
namespace Manticore
{
  public class SDKTest : JsBackedObject {

  /**
   * Callback for fetch method
   */
  public delegate void FetchedDelegate(ManticoreException error, IDictionary<string,object> response);

  /**
   * Callback for echo method
   */
  public delegate void EchoDelegate(ManticoreException error, String arg);

  /**
   * Callback for echo method with return
   */
  public delegate String EchoReturnDelegate();

  /**
   * Simple event
   */
  public delegate void FakeEventDelegate(SDKTest sender, SDKTestDefault item);
  private System.Collections.Generic.Dictionary<FakeEventDelegate,ClrFunctionInstance> fakeEventHandlers;


  internal SDKTest(ObjectInstance value) : base(value) {
  }


  /**
   * Make the class with a particular stringProperty setting
   */
  public SDKTest(String stringProperty) {
    JsValue[] args = new JsValue[] {
      Engine.Converter.AsJsString(stringProperty)
    };
    this.impl = Engine.CreateJsObject("SDKTest", args);
  }

  /**
  * Make subclasses work with classes with non-default constructors
  */
  protected SDKTest() {}


  internal static SDKTest NativeInstanceForObject(ObjectInstance value) {
    if (value == null) {
      return null;
    }

    return new SDKTest(value);
  }
  /**
   * Echo the argument via the callback
   */
  public void Echo(String arg, EchoDelegate callback) {
    JsValue[] args = new JsValue[] {
      Engine.Converter.AsJsString(arg),
    WrapDelegate(callback)
    };
    
    var func = this.impl.Get("echo").As<FunctionInstance>();
    Engine.Js(() => {
      func.Call(this.impl, args);
    
    });
  }  /**
   * Echo the argument via return value from a callback
   */
  public void EchoReturn(String arg, EchoReturnDelegate callback) {
    JsValue[] args = new JsValue[] {
      Engine.Converter.AsJsString(arg),
    WrapDelegate(callback)
    };
    
    var func = this.impl.Get("echoReturn").As<FunctionInstance>();
    Engine.Js(() => {
      func.Call(this.impl, args);
    
    });
  }  /**
   * Echo the argument via the callback after setTimeout(10)
   */
  public void EchoWithSetTimeout(String arg, EchoDelegate callback) {
    JsValue[] args = new JsValue[] {
      Engine.Converter.AsJsString(arg),
    WrapDelegate(callback)
    };
    
    var func = this.impl.Get("echoWithSetTimeout").As<FunctionInstance>();
    Engine.Js(() => {
      func.Call(this.impl, args);
    
    });
  }  /**
   * Fire an event
   */
  public void TriggerFakeAfterTimeout() {
    JsValue[] args = new JsValue[] {};
    
    var func = this.impl.Get("triggerFakeAfterTimeout").As<FunctionInstance>();
    Engine.Js(() => {
      func.Call(this.impl, args);
    
    });
  }  /**
   * Return a complex object.
   */
  public SDKTestDefault ReturnAnObject() {
    JsValue[] args = new JsValue[] {};
    
    var func = this.impl.Get("returnAnObject").As<FunctionInstance>();
    return Engine.JsWithReturn(() => {
      var returnValue = func.Call(this.impl, args);
    return ((returnValue.IsNull()||returnValue.IsUndefined()) ? null : SDKTestDefault.NativeInstanceForObject(returnValue.AsObject()));
    });
  }  /**
   * Return a derivative of SDKTestDefault
   */
  public SDKTestDefault ReturnADerivedObject() {
    JsValue[] args = new JsValue[] {};
    
    var func = this.impl.Get("returnADerivedObject").As<FunctionInstance>();
    return Engine.JsWithReturn(() => {
      var returnValue = func.Call(this.impl, args);
    return ((returnValue.IsNull()||returnValue.IsUndefined()) ? null : SDKTestDefault.NativeInstanceForObject(returnValue.AsObject()));
    });
  }  /**
   * Return one SDKTestDefault and one derived
   */
  public List<SDKTestDefault> ReturnBaseAndDerived() {
    JsValue[] args = new JsValue[] {};
    
    var func = this.impl.Get("returnBaseAndDerived").As<FunctionInstance>();
    return Engine.JsWithReturn(() => {
      var returnValue = func.Call(this.impl, args);
    return Engine.Converter.ToNativeArray(returnValue, new Func<JsValue,SDKTestDefault>((element) => ((element.IsNull()||element.IsUndefined()) ? null : SDKTestDefault.NativeInstanceForObject(element.AsObject()))));
    });
  }  /**
   * Pre decrement within an indexer --j.
         * Create array c= [a,b], set j=1, set c[--j] = c[j]+add
         * push j to c and return c
         * expected result: c[0] is set to c[0]+add, so, [a+add,b,0]
   */
  public List<int> PreDecrement(int a, int b, int add) {
    JsValue[] args = new JsValue[] {
      Engine.Converter.AsJsInt(a),
    Engine.Converter.AsJsInt(b),
    Engine.Converter.AsJsInt(add)
    };
    
    var func = this.impl.Get("preDecrement").As<FunctionInstance>();
    return Engine.JsWithReturn(() => {
      var returnValue = func.Call(this.impl, args);
    return Engine.Converter.ToNativeArray(returnValue, new Func<JsValue,int>((element) => Engine.Converter.AsNativeInt(element)));
    });
  }  /**
   * Post decrement within an indexer j--.
         * Create array c= [a,b], set j=1, set c[j--] = c[j]+add
         * push j to c and return c
         * expected result: c[1] is set to c[0]+add, so, [a,a+add, 0]
   */
  public List<int> PostDecrement(int a, int b, int add) {
    JsValue[] args = new JsValue[] {
      Engine.Converter.AsJsInt(a),
    Engine.Converter.AsJsInt(b),
    Engine.Converter.AsJsInt(add)
    };
    
    var func = this.impl.Get("postDecrement").As<FunctionInstance>();
    return Engine.JsWithReturn(() => {
      var returnValue = func.Call(this.impl, args);
    return Engine.Converter.ToNativeArray(returnValue, new Func<JsValue,int>((element) => Engine.Converter.AsNativeInt(element)));
    });
  }  /**
   * Return a JS dictionary
   */
  public IDictionary<string,object> ReturnAMixedType() {
    JsValue[] args = new JsValue[] {};
    
    var func = this.impl.Get("returnAMixedType").As<FunctionInstance>();
    return Engine.JsWithReturn(() => {
      var returnValue = func.Call(this.impl, args);
    return Engine.Converter.AsNativeObject(returnValue);
    });
  }  /**
   * Take a JS dictionary and return it
   */
  public IDictionary<string,object> TakeAMixedType(IDictionary<string,object> stuff) {
    JsValue[] args = new JsValue[] {
      Engine.Converter.AsJsObject(stuff)
    };
    
    var func = this.impl.Get("takeAMixedType").As<FunctionInstance>();
    return Engine.JsWithReturn(() => {
      var returnValue = func.Call(this.impl, args);
    return Engine.Converter.AsNativeObject(returnValue);
    });
  }  /**
   * Throw an exception
   */
  public void ThrowOne() {
    JsValue[] args = new JsValue[] {};
    
    var func = this.impl.Get("throwOne").As<FunctionInstance>();
    Engine.Js(() => {
      func.Call(this.impl, args);
    
    });
  }  /**
   * Fetch some JSON from httpbin.org
   */
  public void GoFetch(FetchedDelegate callback) {
    JsValue[] args = new JsValue[] {
      WrapDelegate(callback)
    };
    
    var func = this.impl.Get("goFetch").As<FunctionInstance>();
    Engine.Js(() => {
      func.Call(this.impl, args);
    
    });
  }  /**
   * Fetch some JSON with promise style interface
   */
  public async Task<IDictionary<string,object>> GoFetchP() {
    var _completer = new TaskCompletionSource<IDictionary<string,object>>();
    JsValue[] args = new JsValue[] {};
    
    var func = this.impl.Get("goFetchP").As<FunctionInstance>();
    Engine.Js(() => {
      var returnValue = func.Call(this.impl, args);
    var _callback = Engine.AsJsFunction(new Func<JsValue,JsValue[],JsValue>((thisObject, cbArgs) => {
        if (cbArgs.Length > 0 && !cbArgs[0].IsNull() && !cbArgs[0].IsUndefined()) {
            _completer.TrySetException(new ManticoreException(cbArgs[0].AsObject()));
        } else {
          if (cbArgs.Length > 1 && !cbArgs[1].IsNull() && !cbArgs[1].IsUndefined()) {
            _completer.TrySetResult(Engine.Converter.AsNativeObject(cbArgs[1]));
          }
        }
        return JsValue.Undefined;
      }));
      Engine.ResolvePromise(returnValue, _callback);
    
    });
    return await _completer.Task;
  }
  /**
   * Returns a new instance of this class
   */
  public static SDKTest StaticMethod() {
    JsValue[] args = new JsValue[] {};
    var jsClass = Engine.GetJsClass("SDKTest");
    var func = jsClass.Get("staticMethod").As<FunctionInstance>();
    return Engine.JsWithReturn(() => {
      var returnValue = func.Call(jsClass, args);
    return ((returnValue.IsNull()||returnValue.IsUndefined()) ? null : SDKTest.NativeInstanceForObject(returnValue.AsObject()));
    });
  }


  public int ItsOne {
    get {
      return Engine.JsWithReturn(() => {
        var itsOne = this.impl.Get("itsOne");
        return Engine.Converter.AsNativeInt(itsOne);
      });
    }
    
    set {
      var jsValue = Engine.Converter.AsJsInt(value);
      Engine.Js(() => {
        this.impl.Put("itsOne", jsValue, true);
      });
    }
    
  }

  public int CantTouchThis {
    get {
      return Engine.JsWithReturn(() => {
        var cantTouchThis = this.impl.Get("cantTouchThis");
        return Engine.Converter.AsNativeInt(cantTouchThis);
      });
    }
    
  }

  public String StringProperty {
    get {
      return Engine.JsWithReturn(() => {
        var stringProperty = this.impl.Get("stringProperty");
        return Engine.Converter.AsNativeString(stringProperty);
      });
    }
    
    set {
      var jsValue = Engine.Converter.AsJsString(value);
      Engine.Js(() => {
        this.impl.Put("stringProperty", jsValue, true);
      });
    }
    
  }

  public String AccessorString {
    get {
      return Engine.JsWithReturn(() => {
        var accessorString = this.impl.Get("accessorString");
        return Engine.Converter.AsNativeString(accessorString);
      });
    }
    
    set {
      var jsValue = Engine.Converter.AsJsString(value);
      Engine.Js(() => {
        this.impl.Put("accessorString", jsValue, true);
      });
    }
    
  }

  public SDKTestDefault ComplexType {
    get {
      return Engine.JsWithReturn(() => {
        var complexType = this.impl.Get("complexType");
        return ((complexType.IsNull()||complexType.IsUndefined()) ? null : SDKTestDefault.NativeInstanceForObject(complexType.AsObject()));
      });
    }
    
    set {
      var jsValue = Engine.Converter.AsJs(value);
      Engine.Js(() => {
        this.impl.Put("complexType", jsValue, true);
      });
    }
    
  }

  public SDKTestStatuses MyStatus {
    get {
      return Engine.JsWithReturn(() => {
        var myStatus = this.impl.Get("myStatus");
        return ((SDKTestStatuses)Engine.Converter.AsNativeInt(myStatus));
      });
    }
    
    set {
      var jsValue = (int)value;
      Engine.Js(() => {
        this.impl.Put("myStatus", jsValue, true);
      });
    }
    
  }

  public bool NoSsl {
    get {
      return Engine.JsWithReturn(() => {
        var noSsl = this.impl.Get("noSsl");
        return Engine.Converter.AsNativeBool(noSsl);
      });
    }
    
    set {
      var jsValue = Engine.Converter.AsJsBool(value);
      Engine.Js(() => {
        this.impl.Put("noSsl", jsValue, true);
      });
    }
    
  }


  private ClrFunctionInstance WrapDelegate(FetchedDelegate _delegate) {
    return Engine.AsJsFunction(new Func<JsValue,JsValue[],JsValue>((thisObject, args) => {
      _delegate(((args[0].IsNull()||args[0].IsUndefined()) ? null : ManticoreException.NativeInstanceForObject(args[0].AsObject())), Engine.Converter.AsNativeObject(args[1]));
      return JsValue.Undefined;
    }));
  }
  private ClrFunctionInstance WrapDelegate(EchoDelegate _delegate) {
    return Engine.AsJsFunction(new Func<JsValue,JsValue[],JsValue>((thisObject, args) => {
      _delegate(((args[0].IsNull()||args[0].IsUndefined()) ? null : ManticoreException.NativeInstanceForObject(args[0].AsObject())), Engine.Converter.AsNativeString(args[1]));
      return JsValue.Undefined;
    }));
  }
  private ClrFunctionInstance WrapDelegate(EchoReturnDelegate _delegate) {
    return Engine.AsJsFunction(new Func<JsValue,JsValue[],JsValue>((thisObject, args) => {
      var returnValue = _delegate();
      return Engine.Converter.AsJsString(returnValue);
    }));
  }

  public event FakeEventDelegate FakeEvent
  {
    add
    {
      var _wrapped = WrapDelegate(value);
      if (fakeEventHandlers == null) {
        fakeEventHandlers = new System.Collections.Generic.Dictionary<FakeEventDelegate,ClrFunctionInstance>();
      }
      this.impl.Get("on").As<FunctionInstance>().Call(this.impl, new JsValue[] {
        "fakeEvent",
        _wrapped
      });
      fakeEventHandlers[value] = _wrapped;
    }
    remove
    {
      if (fakeEventHandlers != null) {
        var _wrapped = fakeEventHandlers[value];
        if (_wrapped != null) {
          this.impl.Get("removeListener").As<FunctionInstance>().Call(this.impl, new JsValue[] {
            "fakeEvent",
            _wrapped
          });
          fakeEventHandlers.Remove(value);
        }
      }
    }
  }

  private ClrFunctionInstance WrapDelegate(FakeEventDelegate _delegate) {
    return Engine.AsJsFunction(new Func<JsValue,JsValue[],JsValue>((thisObject, args) => {
      _delegate(this, ((args[0].IsNull()||args[0].IsUndefined()) ? null : SDKTestDefault.NativeInstanceForObject(args[0].AsObject())));
      return JsValue.Undefined;
      }));
    }
  }
}
