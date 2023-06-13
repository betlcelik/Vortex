
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Spotify.core.DbConnection.EntityFramework;
using Spotify.core.dtos.AlbumDto;
using Spotify.core.dtos.ArtistDto;
using Spotify.core.dtos.CountryDto;
using Spotify.core.dtos.GenreDto;
using Spotify.core.dtos.MembershipDto;
using Spotify.core.dtos.PlaylistDto;
using Spotify.core.dtos.SongDto;
using Spotify.core.dtos.UserDto;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Business.concretes;
using SpotifyClone.Business.constants.DependencyResolver.Autofac;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.AutoMapper;
using SpotifyClone.Core.concretes;
using SpotifyClone.Core.dtos.LikedSongsDto;
using SpotifyClone.Core.dtos.MembershipDto;
using SpotifyClone.Core.dtos.PlaylistSongDto;
using SpotifyClone.Core.dtos.SavedAlbumsDto;
using SpotifyClone.Core.dtos.SavedSongsDto;
using SpotifyClone.Core.Validation;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataBaseConnection>(options => options.UseNpgsql("User ID=postgres;Password=12345;Host=localhost;Port=5432;Database=Vortex;Pooling=true;Connection Lifetime=0;", b => b.MigrationsAssembly("SpotifyClone.API")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<ISongService, SongManager>();
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddScoped<IPlaylistService, PlaylistManager>();
builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
builder.Services.AddScoped<IMembershipService, MembershipManager>();
builder.Services.AddScoped<IMembershipTypeRepository, MembershipTypeRepository>();
builder.Services.AddScoped<IMembershipTypeService, MembershipTypeManager>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreManager>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryManager>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IArtistService, ArtistManager>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IAlbumService, AlbumManager>();
builder.Services.AddScoped<ISavedSongsRepository, SavedSongsRepository>();
builder.Services.AddScoped<ISavedSongsService, SavedSongsManager>();
builder.Services.AddScoped<ISavedAlbumsRepository, SavedAlbumsRepository>();
builder.Services.AddScoped<ISavedAlbumsService, SavedAlbumsManager>();
builder.Services.AddScoped<ILikedSongsRepository, LikedSongsRepository>();
builder.Services.AddScoped<ILikedSongsService, LikedSongsManager>();
builder.Services.AddScoped<IPlaylistSongRepository, PlaylistSongRepository>();
builder.Services.AddScoped<IPlaylistSongService, PlaylistSongManager>();

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddTransient<IValidator<UserAddDto>, UserValidator>();
builder.Services.AddTransient<IValidator<SongAddDto>, SongValidator>();
builder.Services.AddTransient<IValidator<SavedSongsDto>, SavedSongsValidator>();
builder.Services.AddTransient<IValidator<SavedAlbumsDto>, SavedAlbumsValidator>();
builder.Services.AddTransient<IValidator<PlaylistSongDto>, PlaylistSongValidator>();
builder.Services.AddTransient<IValidator<PlaylistAddDto>, PlaylistValidator>();
builder.Services.AddTransient<IValidator<MembershipAddDto>, MembershipValidator>();
builder.Services.AddTransient<IValidator<LikedSongsDto>, LikedSongsValidator>();
builder.Services.AddTransient<IValidator<GenreAddDto>, GenreValidator>();
builder.Services.AddTransient<IValidator<CountryAddDto>, CountryValidator>();
builder.Services.AddTransient<IValidator<ArtistAddDto>, ArtistValidator>();
builder.Services.AddTransient<IValidator<AlbumAddDto>, AlbumValidator>();
builder.Services.AddTransient<IValidator<MembershipPaymentDto> , MembershipPaymentValidator>();


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

