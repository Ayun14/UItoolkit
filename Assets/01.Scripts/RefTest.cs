using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RefTest : MonoBehaviour
{
    private TestScript _test;

    private void Start()
    {
        _test = new TestScript(10, 20);

        var type = _test.GetType();

        //MethodInfo[] methods =  type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        MethodInfo printAbcMethod = type.GetMethod("PrintABC");
        FieldInfo field = type.GetField("def");

        field.SetValue(_test, 100);

        TestScript b = new TestScript(15, 25);
        if (printAbcMethod != null)
        {
            //ParameterInfo[] paramInfos = printAbcMethod.GetParameters(); 파라미터 가져오기
            printAbcMethod.Invoke(_test, null);
            printAbcMethod.Invoke(b, null);
        }

        //foreach(MemberInfo m in methods)
        //{
        //    Debug.Log(m.Name);
        //}
    }
}
