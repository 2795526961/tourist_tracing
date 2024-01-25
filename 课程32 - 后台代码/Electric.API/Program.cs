using Autofac;
using Autofac.Extensions.DependencyInjection;
using Electric.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

//����host������
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModuleRegister());
    });

//�����������
builder.AddRateLimiter();

//������־
builder.Logging.AddLog4Net();

// ��������ӵ������С�
builder.AddElectricControllers();

// Swagger/OpenAPI ����
builder.AddElectricSwaggerGen();

//���ݿ�������ע��
builder.AddElectricDbContext();

//���jwt��֤
builder.AddElectricJWT();

//���ע��
builder.AddElectricService();

//AutoMapper����ע��
builder.AddElectricAutoMapper();

//��������
var eleAllowSpecificOrigins = "EleAllowSpecificOrigins";
builder.AddElectricCorsOrigins(eleAllowSpecificOrigins);

//������Ԫע��
builder.AddUnitOfWork();

var app = builder.Build();

//API��������
app.UseRateLimiter();

//��������
app.UseCors(eleAllowSpecificOrigins);

// ����HTTP����ܵ���
if (app.Environment.IsDevelopment())
{
    //���������£��ſ���Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//����body����
app.Use(next => context =>
{
    context.Request.EnableBuffering();
    return next(context);
});

app.MapControllers();

app.Run();