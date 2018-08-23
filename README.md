# MaterialSharp
Custom wpf styling that looks a bit like material. [Nuget package](https://www.nuget.org/packages/MaterialSharp/) provided. Readme will be filled with examples soon, right now investigate source code.

# Super quick start
Append this to your App.xaml
```C#
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/MaterialSharp;component/Colors.xaml" />
            <ResourceDictionary Source="pack://application:,,,/MaterialSharp;component/Defaults.xaml" />

        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```
