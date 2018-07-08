using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Blazor.Components;
using Sotsera.Blazor.Toaster.Core;
using Sotsera.Blazor.Toaster.Core.Models;

namespace Sotsera.Blazor.Toaster
{
    public class ToastContainerModel : BlazorComponent, IDisposable
    {
        [Inject]
        private IToaster Toaster { get; set; }

        public IList<Toast> Toasts => Toaster.Toasts;
        public string Class => Toaster.Configuration.PositionClass;

        protected override void OnInit()
        {
            base.OnInit();
            Toaster.OnToastsUpdated += StateHasChanged;
        }

        public void Dispose()
        {
            Toaster.OnToastsUpdated -= StateHasChanged;
        }
    }
}