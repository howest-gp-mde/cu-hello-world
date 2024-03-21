using HelloWorld.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Services
{
    // url: https://raw.githubusercontent.com/howest-gp-mde/cu-maui-campusdetector/master/data/campuses.json
    public interface ILocationService
    {
        Task<List<Location>> GetLocations(); 
    }
}
