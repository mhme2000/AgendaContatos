using AgendaContatos.Data;
using AgendaContatos.Data.Interfaces;
using AgendaContatos.Data.Repositories;
using AgendaContatos.Model;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AgendaContatoContext>();
builder.Services.AddScoped<IAgendaContatoRepository, AgendaContatoRepository>();


builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy",
       builder => builder
       .WithOrigins("http://localhost:3000")
       .AllowAnyMethod()
       .AllowAnyHeader());
});

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<AgendaContatoModel, AgendaContatoDTO>()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.AgendaContatoId));
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
var app = builder.Build();

app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
