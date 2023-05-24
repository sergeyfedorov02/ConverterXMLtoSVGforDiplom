// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace WebApplication.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\RiderProjects\Diploma_Project\WebApplication\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\RiderProjects\Diploma_Project\WebApplication\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\RiderProjects\Diploma_Project\WebApplication\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\RiderProjects\Diploma_Project\WebApplication\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\RiderProjects\Diploma_Project\WebApplication\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\RiderProjects\Diploma_Project\WebApplication\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\RiderProjects\Diploma_Project\WebApplication\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\RiderProjects\Diploma_Project\WebApplication\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\RiderProjects\Diploma_Project\WebApplication\_Imports.razor"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\RiderProjects\Diploma_Project\WebApplication\_Imports.razor"
using WebApplication.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\RiderProjects\Diploma_Project\WebApplication\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\RiderProjects\Diploma_Project\WebApplication\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\RiderProjects\Diploma_Project\WebApplication\Pages\Plans.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\RiderProjects\Diploma_Project\WebApplication\Pages\Plans.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\RiderProjects\Diploma_Project\WebApplication\Pages\Plans.razor"
using SvgConverter;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/plans")]
    public partial class Plans : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 36 "D:\RiderProjects\Diploma_Project\WebApplication\Pages\Plans.razor"
       
        private const long MaxFileSize = long.MaxValue;
        private const int MaxAllowedFiles = 1;
    private readonly List<string> _errors = new();
    private readonly List<string> _fileNames = new();
    private readonly List<string> _fileContentsList = new();

    private async Task LoadFiles(InputFileChangeEventArgs entry)
    {
        _errors.Clear();

    // Количество одновременно загружаемых файлов должно быть не больше maxAllowedFiles
        if (entry.FileCount > MaxAllowedFiles)
        {
            _errors.Add($"Error: Вы пытаетесь загрузить {entry.FileCount} файлов, " +
                        $"когда максимум разрешено загружать {MaxAllowedFiles} файл !");
            return;
        }

        if (_fileNames.Count == 1)
        {
            _errors.Add($"Error: Вы пытаетесь загрузить более {MaxAllowedFiles} файла для конвертации !");
            return;
        }

        foreach (var file in entry.GetMultipleFiles(MaxAllowedFiles))
        {
            
            if (!file.Name.Split(".")[1].Equals("chr"))
            {
                _errors.Add($"Error: Файл с именем \"{file.Name}\" имеет недопустимое расширение " +
                            $", используйте только тип \".chr\" !");
                continue;
            }

            var buffer = new byte[file.Size];
            await file.OpenReadStream(MaxFileSize).ReadAsync(buffer);
            var fileContent = Encoding.UTF8.GetString(buffer);

            _fileContentsList.Add(fileContent);
            _fileNames.Add(file.Name);
        }
    }

    private async void StartConvert()
    {
        if (_errors.Count == 0)
        {
            var file = _fileContentsList[0];

            var convertResult = Converter.FromXml(file, null);

            var newConvertResult = convertResult.Split("<svg");
            var fullSvg = "<svg " + newConvertResult[1];

            await Js.InvokeVoidAsync("SetSvg", fullSvg);

            _fileNames.Clear();
            _fileContentsList.Clear();
        }
    }
    
    private Timer _blinkTimer;
    
    protected override async Task OnInitializedAsync()
    {

        async void Callback(object _)
        {
            await Js.InvokeVoidAsync("ChangeBlinkState");
        }

        _blinkTimer = new Timer(Callback, new AutoResetEvent(false), 1000, 1000);
    }

    public void Dispose()
    {
        _blinkTimer?.Dispose();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime Js { get; set; }
    }
}
#pragma warning restore 1591
