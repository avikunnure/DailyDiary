using Microsoft.Extensions.DependencyInjection;
using SavuDiary.UI.Common.ComponentsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary
{
    public static class DependencyInjectionCommonUI
    {
        public static void AddCommonUIServices(this IServiceCollection services)
        {
            services.AddTransient<ISweetAlert, SweetAlert>();
        }
    }
}
