using DayX.Infrastructure.Contexts; // Подключаем пространство имён с нашим DbContext
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Регистрируем DbContext в контейнере зависимостей (DI),
/// используя строку подключения из appsettings.json.
/// Это позволяет инжектить MarketplaceDbContext в сервисы, страницы и контроллеры.
/// </summary>
builder.Services.AddDbContext<MarketplaceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/// <summary>
/// Регистрируем поддержку Razor Pages в приложении.
/// </summary>
builder.Services.AddRazorPages();

/// <summary>
/// Строим объект приложения на основе настроек и зарегистрированных сервисов.
/// </summary>
var app = builder.Build();

/// <summary>
/// Конфигурация конвейера обработки HTTP-запросов.
/// Если среда не Development — включаем обработчик ошибок и HSTS.
/// </summary>
if (!app.Environment.IsDevelopment())
{
    /// <summary>
    /// Перенаправление на страницу /Error при необработанных исключениях.
    /// </summary>
    app.UseExceptionHandler("/Error");

    /// <summary>
    /// Включаем HTTP Strict Transport Security (HSTS) на 30 дней по умолчанию.
    /// </summary>
    app.UseHsts();
}

/// <summary>
/// Перенаправляем все HTTP-запросы на HTTPS.
/// </summary>
app.UseHttpsRedirection();

/// <summary>
/// Включаем маршрутизацию для обработки запросов.
/// </summary>
app.UseRouting();

/// <summary>
/// Подключаем middleware авторизации (проверка прав доступа).
/// </summary>
app.UseAuthorization();

/// <summary>
/// Регистрируем маршруты для Razor Pages.
/// </summary>
app.MapRazorPages();

/// <summary>
/// Запускаем приложение и начинаем обработку входящих HTTP-запросов.
/// </summary>
app.Run();

