using SportApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories.Interfaces
{
    public interface IColorRepository : IRepository<Color>
    {
        Task<bool> Create(CreateColorModel request);
    }
    public class CreateColorModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
