using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
	{
		protected readonly MyContext _context;
		private DbSet<T> _dataset;
		public BaseRepository(MyContext context)
		{
			_context = context;
			_dataset = _context.Set<T>();
		}
		public async Task<bool> DeleteAsync(int id)
		{
			try
			{
				var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

				if (result == null)
					return false;

				_dataset.Remove(result);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<T> InsertAsync(T item)
		{
			try
			{
				if (item.Id == int.MinValue)
				{
					item.Id = int.MinValue;
				}

				_dataset.Add(item);

				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return item;
		}

		public async Task<T> SelectAsync(int id)
		{
			try
			{
				return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<IEnumerable<T>> SelectAsync()
		{
			try
			{
				return await _dataset.ToListAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<T> UpdateAsync(T item)
		{
			try
			{
				var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

				if (result == null)
					return null;

				_context.Entry(result).CurrentValues.SetValues(item);

				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return item;
		}
	}
}
