﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Calculator.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Calculator.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {
        ///  &quot;AED&quot;: &quot;United Arab Emirates Dirham&quot;,
        ///  &quot;AFN&quot;: &quot;Afghan Afghani&quot;,
        ///  &quot;ALL&quot;: &quot;Albanian Lek&quot;,
        ///  &quot;AMD&quot;: &quot;Armenian Dram&quot;,
        ///  &quot;ANG&quot;: &quot;Netherlands Antillean Guilder&quot;,
        ///  &quot;AOA&quot;: &quot;Angolan Kwanza&quot;,
        ///  &quot;ARS&quot;: &quot;Argentine Peso&quot;,
        ///  &quot;AUD&quot;: &quot;Australian Dollar&quot;,
        ///  &quot;AWG&quot;: &quot;Aruban Florin&quot;,
        ///  &quot;AZN&quot;: &quot;Azerbaijani Manat&quot;,
        ///  &quot;BAM&quot;: &quot;Bosnia-Herzegovina Convertible Mark&quot;,
        ///  &quot;BBD&quot;: &quot;Barbadian Dollar&quot;,
        ///  &quot;BDT&quot;: &quot;Bangladeshi Taka&quot;,
        ///  &quot;BGN&quot;: &quot;Bulgarian Lev&quot;,
        ///  &quot;BHD&quot;: &quot;Bahraini Dinar&quot;,
        ///  &quot;BIF&quot;: &quot;Burundian Franc&quot;,
        ///  &quot;BMD [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string currencies {
            get {
                return ResourceManager.GetString("currencies", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap tyzh {
            get {
                object obj = ResourceManager.GetObject("tyzh", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.IO.UnmanagedMemoryStream, аналогичного System.IO.MemoryStream.
        /// </summary>
        internal static System.IO.UnmanagedMemoryStream tz {
            get {
                return ResourceManager.GetStream("tz", resourceCulture);
            }
        }
    }
}
