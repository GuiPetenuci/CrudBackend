using System;
using Confitec.Domain.Entities.Base;
namespace Confitec.Domain.Entities
{

	public enum Escolaridade
	{
		Infantil,
		Fundamental,
		Medio,
		Superior
	}

	public class Usuario : BaseEntity
	{

		public string Nome { get; set; } = string.Empty;

		public string Sobrenome { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public DateTime DataNascimento { get; set; }

		public Escolaridade Escolaridade { get; set; }
	}
}

