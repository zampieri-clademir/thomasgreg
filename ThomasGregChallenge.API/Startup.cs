using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using SimpleInjector;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using ThomasGregChallenge.API.Extensions;
using ThomasGregChallenge.Base.Configuracoes;
using ThomasGregChallenge.Domain;
using ThomasGregChallenge.Migracoes;

namespace ThomasGregChallenge.API
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private static Container Container { get; } = new Container();

        private readonly IConfiguration _configuracoes;

        private readonly GerenciamentoConfiguracoes _configuracoesApi;

        public Startup(IConfiguration configuration)
        {
            _configuracoes = configuration;

            _configuracoesApi = new GerenciamentoConfiguracoes();

            configuration.Bind(_configuracoesApi);

            Container.Options.AllowOverridingRegistrations = true;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddCors();
            services.AddSimpleInjector(Container);
            services.AddMediator(Container);
            services.AddValidators(Container);
            services.AddFilters();
            services.AddSwagger();
            services.AddMVC();
            services.AddHttpClient();
            services.InicializarDomain();
            services.AdicionarDependenciasBanco(_configuracoes);
            services.InicializarMigracoes(_configuracoes);

            services.AddTransient(c => _configuracoes);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuracoes["Jwt:Issuer"],
                    ValidAudience = _configuracoes["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracoes["Jwt:Key"]))
                };
            });

            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            Container.AutoCrossWireAspNetComponents(app);

            app.UseAuthentication();

            app.UseMvc();

            app.ConfigSwagger();

            app.UseStaticFiles();

            Container.RegisterMvcControllers(app);
        }
    }
}
