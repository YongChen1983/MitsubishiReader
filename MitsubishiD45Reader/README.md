# 三菱 MX Component 读取 D45 - C# 示例

使用三菱 **MX Component** 连接 PLC 并读取 **D45** 寄存器值的 Windows 窗体程序。

## 环境要求

- Windows 系统
- **已安装三菱 MX Component**（请从三菱官网或代理商获取并安装）
- Visual Studio 2017 或更高版本（.NET Framework 4.7.2）
- 在 MX Component 的 **Communication Setup Utility** 中已配置好逻辑站号（如 1、99 等）

## MX Component 配置简要步骤

1. 以管理员身份运行 **Communication Setup Utility**
2. 添加逻辑站号（Logical Station Number），例如 **1** 或 **99**
3. 选择通信方式（如 GX Simulator2 仿真、以太网、串口等）
4. 完成配置后可用“测试”确认连接成功

## 项目配置（重要）

### 1. 添加 ActUtlTypeLib 引用

若打开或编译项目时提示找不到 `ActUtlType` / `ActUtlTypeLib`，请手动添加 COM 引用：

1. 在 Visual Studio 中右键项目 **“引用”** → **“添加引用”**
2. 选择 **“COM”** 选项卡
3. 在列表中找到并勾选 **“ActUtlTypeLib”**（或 “MELSEC ACT Controls” 下的对应项）
4. 确定添加后，在“引用”中选中 **ActUtlTypeLib**
5. 在属性窗口中将 **“嵌入互操作类型”** 设为 **False**

### 2. 平台目标

本项目已设置为 **x86（32 位）**，因为 MX Component 通常为 32 位组件。若使用 64 位 MX Component，需改为 x64 并引用 64 位控件（如 ActUtlType64Lib）。

### 3. 若使用 ActUtlTypeClass

少数环境下 COM 生成的类名为 `ActUtlTypeClass`。若编译报错“无法创建 ActUtlType 的实例”，请将 `Form1.cs` 中的：

```csharp
_plc = new ActUtlType();
```

改为：

```csharp
_plc = new ActUtlTypeClass();
```

## 使用说明

1. 打开解决方案 `MitsubishiD45Reader.sln`，编译运行
2. 在界面中设置 **逻辑站号**（须与 MX Component 中配置的一致）
3. 点击 **“连接”**，状态显示“已连接”后即可操作
4. 点击 **“读取 D45”**，在文本框中查看 D45 的当前值（16 位有符号整数）
5. 使用完毕后点击 **“断开”** 或直接关闭窗口

## 说明

- D45 读取结果为 **16 位有符号整数**（short），范围 -32768 ~ 32767
- 若需读取 32 位或浮点数，需连续读取两个 D 寄存器并自行转换
- 连接或读取失败时，程序会显示 MX Component 返回的错误码（十六进制），便于排查
