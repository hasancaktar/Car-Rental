using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    //Bu SecuredOperation JWT için.
    public class SecuredOperation:MethodInterception
    {
        private string[] _roles;
        //jwt göndererek istek yapıyoruz ya. her bir istek için bir httpcontext oluşur. yani her bir kullanıcı için bir thread oluşur. işte bu IHttpContextAccessor bunu yapıyor.
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string role)
        {
            //bana rolleri ver demek, virgüller ayırarak geliyor. çünkü attribute olduğu için
            _roles = role.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.Claims; } } }