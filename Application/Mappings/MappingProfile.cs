using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Application.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile() => ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

		private void ApplyMappingsFromAssembly(Assembly assembly)
		{
			List<Type> types = assembly.GetExportedTypes()
				.Where(t => t.GetInterfaces().Any(i =>
					i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
				.ToList();

			foreach (Type type in types)
			{
				object? instance = Activator.CreateInstance(type);

				MethodInfo? methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1")?.GetMethod("Mapping") ?? null;

				object? result = methodInfo?.Invoke(instance, new object[] { this }) ?? null;
			}
		}
	}
}