﻿using Autenticacao2.Infra.Data.Interfaces;

namespace Autenticacao2.Application
{
	public class ApplicationService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ApplicationService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void BeginTansaction()
		{
			_unitOfWork.BeginTransaction();
		}

		public void Commit()
		{
			_unitOfWork.Commit();
		}
	}
}