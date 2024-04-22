using MOTC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Repository.Interface
{
    public interface IMovieDetailsRepository<T>
    {
        MovieDetails GetDetailsById(int id);

    }
}
