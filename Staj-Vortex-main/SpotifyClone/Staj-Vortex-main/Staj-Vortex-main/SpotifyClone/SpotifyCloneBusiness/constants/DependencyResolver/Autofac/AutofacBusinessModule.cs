using System;
using Autofac;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Business.concretes;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;

namespace SpotifyClone.Business.constants.DependencyResolver.Autofac
{
	public class AutofacBusinessModule : Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
        }
    }
}

