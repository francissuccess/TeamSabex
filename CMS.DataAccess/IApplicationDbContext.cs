using CMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DataAccess
{
    public interface IApplicationDbContext
    {
        DbSet<Pastor> Pastors { get; set; }
        DbSet<Choir> Choirs { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
