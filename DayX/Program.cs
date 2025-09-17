using DayX.Infrastructure.Contexts; // ���������� ������������ ��� � ����� DbContext
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// ������������ DbContext � ���������� ������������ (DI),
/// ��������� ������ ����������� �� appsettings.json.
/// ��� ��������� ��������� MarketplaceDbContext � �������, �������� � �����������.
/// </summary>
builder.Services.AddDbContext<MarketplaceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/// <summary>
/// ������������ ��������� Razor Pages � ����������.
/// </summary>
builder.Services.AddRazorPages();

/// <summary>
/// ������ ������ ���������� �� ������ �������� � ������������������ ��������.
/// </summary>
var app = builder.Build();

/// <summary>
/// ������������ ��������� ��������� HTTP-��������.
/// ���� ����� �� Development � �������� ���������� ������ � HSTS.
/// </summary>
if (!app.Environment.IsDevelopment())
{
    /// <summary>
    /// ��������������� �� �������� /Error ��� �������������� �����������.
    /// </summary>
    app.UseExceptionHandler("/Error");

    /// <summary>
    /// �������� HTTP Strict Transport Security (HSTS) �� 30 ���� �� ���������.
    /// </summary>
    app.UseHsts();
}

/// <summary>
/// �������������� ��� HTTP-������� �� HTTPS.
/// </summary>
app.UseHttpsRedirection();

/// <summary>
/// �������� ������������� ��� ��������� ��������.
/// </summary>
app.UseRouting();

/// <summary>
/// ���������� middleware ����������� (�������� ���� �������).
/// </summary>
app.UseAuthorization();

/// <summary>
/// ������������ �������� ��� Razor Pages.
/// </summary>
app.MapRazorPages();

/// <summary>
/// ��������� ���������� � �������� ��������� �������� HTTP-��������.
/// </summary>
app.Run();

