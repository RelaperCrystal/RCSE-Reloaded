# 代码样式

为保持代码的连续性和整洁性，特编写此文。

## 总体风格

### 缩进

每级代码由一个 `tab` 进行缩进。

```c#
public class RandomClass
{
    public string RandomProp
    {
        get
        {
            something...
            return something;
        }
        set
        {
            something...
            something = value;
        }
    }
}
```

### 表达式

单行处理的事件处理程序或代码，请使用表达式处理。

```csharp
// 错误示范
public void SomethingwithDelegate(EventArgs someValue)
{
    SomeObject.SomeMethod(somethingVar);
}

// 正确示范
public void SomethingwithDelegate(EventArgs someValue) => SomeObject.SomeMethod(somethingVar);
```

### `#region`

大量的事件处理程序请使用 Region 处理。

### 方法调用

请勿直接在参数中不带空格。

```csharp
public void SomethingwithDelegate(EventArgs someValue) => SomeObject.SomeMethod(somethingVar);

public void ProcessRightNow(Obj1 someObj, Obj2 somearg, Obj3 something)
{
    ...code...
}
class SomeClass
{
    static void Somemethod()
    {
        SomethingwithDelegate(new EventArgs());
        ProcessRightNow(new Obj1(), new Obj2(), new Obj3());
    }
}
```

