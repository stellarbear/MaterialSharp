using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace MaterialSharp.Controls
{
    public class TemplateBindingExtension : MarkupExtension
    {
        public string Path { get; set; }
        public string Template { get; set; }
        public IValueConverter Converter { get; set; }

        public TemplateBindingExtension() { }
        public TemplateBindingExtension(string template, string path, IValueConverter converter = null)
        {
            Path = path;
            Template = template;
            Converter = converter;
        }

        // Here be dirty hack.
        internal static string TagPath { get; private set; }
        internal static IValueConverter TagConverter { get; private set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            TagPath = Path;
            TagConverter = Converter;

            var resourceExt = new StaticResourceExtension(Template);
            // This line causes the evaluation of the Tag as the resource is loaded.
            var baseTemplate = resourceExt.ProvideValue(serviceProvider) as DataTemplate;
            return baseTemplate;
        }
    }

    public class TemplateBindingTagExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            Binding binding =
                new Binding(TemplateBindingExtension.TagPath);

            if (TemplateBindingExtension.TagConverter != null)
                binding.Converter = TemplateBindingExtension.TagConverter;

            return binding;
        }
    }

    /* Do you want some sort?
     * public static void MySort<TSource,TKey>(this ObservableCollection<TSource> observableCollection, Func<TSource, TKey> keySelector)
    {
        var a = observableCollection.OrderBy(keySelector).ToList();
        observableCollection.Clear();
        foreach(var b in a)
        {
            observableCollection.Add(b);
        }
    }
     */
}
